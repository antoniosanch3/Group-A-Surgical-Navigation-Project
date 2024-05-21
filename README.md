# Surgical Navigation Final Project
This Github Repostory constitutes the presentation of the Final Project for the Surgical Navigation and Imaging class of the Master in Machine Learning for Health, UC3M. 
The following README provides an explanation to the user in case they want to implement a version of this project. 

## PelviAR 
This Unity project demonstrates an Augmented Reality (AR) application (*PelviAR*) that overlays different tumor models on a pelvis bone model. The application allows users to select different tumor models through a dropdown menu, toggle the visibility of a bounding sphere around the tumors, and adjust the margings based on tumor size. Additionally, it allows the user to overlay a 3D virtual model of the pelvic bone of the patient to visualize both 

## Features
- Visualization of pelvis bone and tumor models using Vuforia AR markers.
- Dropdown menu to switch between different tumor models.
- Toggle buttons to show/hide pelvic model. 
- Toggle buttons to show/hide bounding spheres around tumors.
- Optional plane markers around tumors for surgical resection guidance.

## Instructions - Setting Up the Unity Project

### Open the Project

Open Unity Hub and click 'Add'.
Select the correct folder to open the project.

### Importing 3D Models
1. Vuforia Marker (*renfe_card*)

Place the Vuforia marker image (*renfe_card*) in the Assets folder.
Ensure it is correctly set up in the Vuforia Image Target.

2. Pelvis Bone Model

Place the pelvis bone model file (*bone_model.obj*) in the Assets folder.
Drag and drop the pelvis bone model into the Unity scene hierarchy.

3. Tumor Models

Place the tumor model files (*tumor_model1.obj*, *tumor_model2.obj*, *tumor_model3.obj*) in the Assets folder.
Ensure that the models are correctly imported and visible in the Unity editor.

### Scene Setup
1. Vuforia Configuration

Set up Vuforia in your Unity project by going to Window > Vuforia Configuration.
Add the *renfe_card* as an Image Target in your AR Camera setup.

2. Adding Models to the Scene

Drag the *pelvis bone model* from the Assets folder into the scene.
Adjust the position, scale, and rotation as needed.
Drag each *tumor model* into the scene and position them relative to the pelvis bone model.

### UI Setup
1. Dropdown Menu

Create a Dropdown UI element in the Canvas and populate it with options for each tumor model (e.g., Patient 1, Patient 2, Patient 3).
Link the dropdown to a script that handles switching between tumor models.

2. Toggle Buttons

Create buttons for toggling the visibility of the bounding sphere and the surgical resection planes.
Link these buttons to their respective functions in your script.

2. Scripts
Ensure that your main script (TumorBoxGenerator.cs) is properly linked to the UI elements and game objects in the scene.


### Final Steps
1. Build and Run

Build the project for your target platform (e.g., Android, iOS).
Deploy and test the application on your AR device to ensure everything functions as expected.

