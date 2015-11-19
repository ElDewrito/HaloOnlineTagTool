# HaloOnlineTagTool
Low-level Halo Online tags.dat editor and research project
Find the original HaloOnlineTagTool [here](https://github.com/ElDewrito/HaloOnlineTagTool).

The 'phmotest' command has been added to load phmo models into Halo Online's tag.dat. The command accepts a JSON file that contains the physics object definitions. Currently only static polyhedra and polyhedra lists are supported.

[Compiled Application](https://www.dropbox.com/s/bv52d1ry2dhqslr/HaloOnlineTagTool.zip?dl=1).

Use the [Blender Scene](https://github.com/Gurten/HaloOnlineTagTool/blob/master/phmoExportBase.blend?raw=true) to create and export multiple polyhedra into the JSON format. Open the .blend file and follow the instructions in the text editor window.

Currently, the only spatial optimisation for the models are the bounding-boxes for individual polyhedra. MOPP is not yet supported. If you're interested in MOPP, see [this file](https://github.com/Gurten/HaloOnlineTagTool/blob/master/mopp_research.txt).
