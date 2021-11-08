## Organizational list
1. Unity 2020.3.14f1 (https://unity3d.com/get-unity/download/archive)
2. Clone this repo (how to use git: https://www.youtube.com/watch?v=RPagOAUx2SQ&ab_channel=EXPLOI.T.)
3. To submit a task please send git repo (from your account) or just a zip file of project
4. You can ask questions in our chat group

## Start to OOP
- Encapsulation => Reference to decomposition
- Inheritance => Copy/Paste
- Polymorphism => In next lessons

## Single responsobility 
- One class should be responsible to only one thing

## Decomposition of Helix Jump
Gameplay video: https://www.youtube.com/watch?v=SNbzevhRBNk&ab_channel=AaronHuggett
### Rendering
   - Show 3d Model
   - Change color of 3d model
   - Show line
   - Making bounce effect
   - Show splash effect

### Movement
   - Bounce move (physics)
   - Rotate obstacles
   - Obstacle physics

### Animation
   - Squash effect

### GamePlay
   - Lose on enter trigger
   - Change color on moving faster

### UI
   - Show points
   - Show progress
   - Next level on win
   - Restart on lose

## Implementation
### Rendering
- You can import FBX/Blender files into Unity. It will be 3d models
- MeshRenderer is resposible to show 3d Model into Unity
- MeshRenderer can be attached to GameObject
- Material is resposible for coloring MeshRenderer
  
> At this point you should be able to create a static level

### Movement
#### RigidBody (non kenimatic)
- AddForce to jump (https://www.youtube.com/watch?v=MBDWTjn05eg&ab_channel=Unity)
- Set velocity to Vector3.zero (https://www.youtube.com/watch?v=zN7K9FTleCU&ab_channel=CodeWithMir)
#### Input.GetMouseButtonDown and Input.GetMouseButton()
 - https://docs.unity3d.com/ScriptReference/Input.GetMouseButtonDown.html
 - https://docs.unity3d.com/ScriptReference/Input.GetMouseButton.html
#### Input.mousePosition is the position of mouse.
- https://docs.unity3d.com/ScriptReference/Input-mousePosition.html
#### Transform for rotation

- Detect when mouse was first clicked => This is start point
- Detect if it's clicking => This is currentPoint
- Compare the difference => difference show how to rotate
> At this point you should be able to rotate obstacles

### Obstacle physics 

> Try your self to google your self, in case you face a problem feel free to ask in chat group

### Animation
- Coroutines (https://www.youtube.com/watch?v=5L9ksCs6MbE&ab_channel=Unity)
- Scale Animation (https://www.youtube.com/watch?v=ZEWr7B8MZas&ab_channel=neenaw) or you can do it via code with Cooroutines.


### GamePlay
- Trigger -> Lose
- RigidBody.velocity.magnitude => checks for speed (https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html)
- Material.color => changes color (https://www.youtube.com/watch?v=VEAU95v5MO8&ab_channel=SpeedTutor)
- Color.Lerp // https://docs.unity3d.com/ScriptReference/Color.Lerp.html

### UI
- Vector3.Distance(), show distance bettween 2 points (https://docs.unity3d.com/ScriptReference/Vector3.Distance.html)
    > You have start (where player starts), end (where finish), current show current
 totalDistance = Distance(start, end). currentDistance = (current, end).
  progress = 1 - totalDistance / currentDistance;

- Canvas with 2 gameObjects. One is to show Win, other is to show Lose.

## Additional tasks:
- Trail
- Point system
- Save system (PlayerPrefs)

## Homework:
- Project should contain 5 levels. If you win one level you player should go to the next one. If player is on last level => should go to the first one.
- Controls should be done via mouse
