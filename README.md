# HaloOnlineTagTool
Low-level Halo Online tags.dat editor and research project

[Compiled Application](https://www.dropbox.com/s/bv52d1ry2dhqslr/HaloOnlineTagTool.zip?dl=1).

The command 'phmotest' has been added to load phmo models into Halo Online. The command accepts a JSON file that contains the physics object definitions. Currently only polyhedra are supported.

Use Blender to create and export multiple polyhedra into the JSON format. Find the .blend file in the top directory of the repo. After opening the .blend file, follow the instructions in the text editor window.

Currently, the only spatial optimisation for the models are the bounding-boxes for individual polyhedra. MOPP is not yet supported. If you're interested in MOPP, see file <host> 
