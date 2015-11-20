dp_epsilon = 6 #decimal point epsilon to distinguish vertices from each other
#regular epsilon for equalities
epsilon = 0.0001

#The minimum magnitude for a vector. Any smaller is considered useless.
min_mag = 0.01

#The smallest area for a triangle used to define a plane
min_area = 0.005

import json
# rigid bodies have mass and radius and a 'havok type'.

# havok types are (Polyhedra|List) , to be expanded later

#Polyhedra is 'planes' , 'vertices' , 'mass' , 'radius', 'friction', 'restitution'

#List is [Polyhedra], to be expanded later
def do_stuff():
    objs = [o for o in bpy.context.selected_objects]
    if len(objs) == 0:
        print("No objects selected, using all scene objects instead.")
        objs = [o for o in bpy.data.objects]
    if len(objs ) == 0:
        print("No objects in scene, quitting")
        #quit
    objs.sort(key = lambda x: x.name) # expand this later to put separate lists into buckets
    output = [] # list of rigid-bodies
    for o in objs:
        name =  o.name.lower()
        if True: #'phmo' == name[:4]: # starts with 'phmo'
            if o.type == "MESH":
                output.append(serialisePolyhedron(o))
            else:
                print("object: \"%s\" has invalid type" % name)
    return output  
    
# Calculates a key for the coordinate. 
# Older text-based methods were succeptible to problems with positive and negative
# zero.
# Better method: create a key-creator for coordinates, and planes.
# Coordinates: add MAX_WORLD_COORD to xyz
# Planes: add 1 to ijk, add MAX_WORLD_COORD to dist.
def keyForCoords(v, dp):
    return tuple([round(c, dp) for c in v]) #numbers around 0 cause problems due to sign

def areaOfTris(p):
    vec1 = p[0]- p[1]
    vec2 = p[2]- p[1]
    vec1.normalize()
    vec2.normalize()
    return 0.5 * (vec1.cross(vec2)).magnitude
    

#returns a correct plane definition.
def faceToPlane(p):
    vec1 = p[0]- p[1]
    vec2 = p[2]- p[1]
    vec1.normalize()
    vec2.normalize()
    norm = vec1.cross(vec2)
    norm.normalize()
    dist = (norm * p[0])
    return ([-norm[0], -norm[1], -norm[2], -dist]) 

def serialisePolyhedron(obj):
    verts = {}
    for v in obj.data.vertices:
        key = keyForCoords(v.co, dp_epsilon)
        verts[key] = v.co
    planes = {}
    #this really should only be for triangles
    for p in obj.data.polygons:
        points = [obj.data.vertices[i].co for i in p.vertices] # the vertices of the face in the order of the winding
        if areaOfTris(points) < min_area:
            continue
        plane = faceToPlane(points)
        key = keyForCoords(plane, 3)
        planes[key] = plane
    
    # Check each vertex lies on 3 planes or more. 
    # Cone-like shapes can have much more planes for the point.
    extreme_pts = []
    for v in verts.values():
        nplanes = 0
        for p in planes.values():
            norm = Vector((p[0], p[1], p[2]))
            mag = (v * norm)- p[3]
            if -epsilon < mag and epsilon > mag:
                nplanes += 1
        if nplanes >= 3:
            extreme_pts.append(v)
    
    # The following is to calculate AABB center and extents.
    # Without axis-aligned center and extents, the engine
    # will not attempt to do any further checks against the
    # geometry inside. 
    
    # Two 3D points to represent an AABB
    mins, maxs = getAABB(verts.values())
    
    # The engine prefers an encoding for AABB with a center-point
    # and half-extents 
    center = [(maxs[i] + mins[i])/2.0 for i in range(3)]
    half_extents = [abs(maxs[i] - center[i]) for i in range(3)]
    
    # A python dict is almost 1-1 with the JSON format.
    return {"Type" : "Polyhedron",
            
            # Flip the 'dist' of the plane. Unusual, but needed for the engine.
            
            "Data" : {"Planes" : [[p[0], p[1], p[2], -p[3]] for p in list(planes.values())], 
            
            # Write the vertices.
            
            "Vertices" : [[c for c in vecs] for vecs in extreme_pts], 
            
            # The center-point of the AABB
            
            "Center" : center,
            
            # The half-extents of the bounding box. 
            
            "Extents" : half_extents,
            
            # A garbage value for 'Mass' 
            
            "Mass" : 100,
            
            # A moderately standard value for 'Friction' according to other tags
            
            "Friction" : 0.85,
            
            # A garbage value for 'Mass'  
            
            "Restitution" : 0.3} }


def getAABB(points):
    mins = [1e9, 1e9, 1e9]; maxs = [-1e9, -1e9, -1e9]
    for v in points:
        if v.x > maxs[0]:
            maxs[0] = v.x
        if v.x < mins[0]:
            mins[0] = v.x
        if v.y > maxs[1]:
            maxs[1] = v.y
        if v.y < mins[1]:
            mins[1] = v.y
        if v.z > maxs[2]:
            maxs[2] = v.z
        if v.z < mins[2]:
            mins[2] = v.z
    return mins, maxs

def test():
    return do_stuff()

def write_json(fpath):
    out = open(fpath, "w")
    x = json.dumps(do_stuff())
    out.write(x)
    out.close()
