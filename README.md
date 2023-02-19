# Cat Box Redux
A repo for extending and reinventing Play / Die / Repeat's Ludum Dare 47 entry.

## Project Folder Structure
I've implemented the same project folder structure I used on a previous project.  We can make changes as necessary throughout development, but I thought it would be useful to start us out withg a basic framework.

#### 0_Scenes
 - Scenes are stored in this folder
 - Subfolders exist for each scene for scene specifc resources like terrain
 - A shared subfolder exists for scene specific resources that are used in multiple scenes.
#### 1_Scripts
 - C# Scripts are store here
 - Subfolders should be used for breaking up code by namespace
#### 2_Game
 - Game Design resources are stored here, primarily prefabs
 - Subfolders should be created for different prefab types (eg. characters, weapons, etc)
 - A Core subfolder exists for things like main Camera, Directional light, etc.
#### 3_UI
 - UI elements are stored here, primarily prefabs
 - Subfolders should be created for different elemtns of UI (eg. menus, healthbars, etc)
#### 4_Art
 - Visual art components are stored here
 - Subfolders exist for textures, materials, and models
#### 5_Audio
 - All audio components are stored here
 - Subfolders exist for sound FX, music, and voice over.
 
## Project Best Practices
 
 
## Coding / Style Standards
 
