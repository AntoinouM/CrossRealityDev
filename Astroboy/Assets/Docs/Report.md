# Code Review Report
Course: CCL4 SS 2023 (5 ECTS, 3 SWS)

Student ID:
cc211019
cc211036
cc211032

BCC Group: GroupB4

Name:
Alon Ishay
Antoine Muneret
Patrick Pitterle

Your Project Name: **AstroBoy**

### A Short Summary to Promote the Project:
We wanted to create a 3D game that would differ from what we did in class to extend our knowledge and challenge ourselves. We all like the Space theme so after very short talking we fixated on doing a landed astronauts. The change we did implement is having a round planet as ground instead of a regular plane. This pushed us to not use the default gravity system of Unity and to readapt everything we learn to match the gravity system we implemented.

### Key Features and Implementation Detail

- 3D Modeling
    1. Characters
       - Main character: Our Astronauts
       ![AstroModel](./Model%20images/Astro.png)
         - Our main character is a cute Astronaut. We wanted to get a 'goofy' look and Alon went overboard to get a model that have a 'soul'. Our character got 4 animations: Idle, Walking and Walking with tilt and a Jump animation split into 3 different states.
       - Enemy 1: Our Boxy-guy.
       ![Enemy1Model](./Model%20images/Enemy.png)
         - In the same spirit of our Astronaut we wanted a character that fit the atmosphere of our game but still gives the impression that he is an enemy at first glance. This enemy has been rigged and has an Idle and a Walk animation.
       - Enemy 2: Mr. Poulpos
       ![Enemy2Model](./Model%20images/Poulp.png)
         - We wanted a fixed enemy. Alon came up with the idea of having an octopuss and created an animation with a lot of movement (due to the tentacles).
    2. Props
       - Alon modeled, unwrapped and textured 3 props (more props have been modeled but not unwrap). Alon did model our planet, which with the size why already a challenge to have the right geometry, a rocket and a tombstone for one of our easter egg: Laika last home.
       ![Rocket and planet](./Model%20images/Planet.png)
       ![Tombstone](./Model%20images/Tombstone.png)
       
- Game Audio
    1. Item
    2. Item, and so forth
- Unity Coding
    1. Scenes
  Our games is composed by 5 scenes. 2 main scenes playable: Moon and Rocket that allow our player to move from inside and outside.We also have 3 scenes for UI and UX with Menu and 2 different screens for Winning and game over.
  ![Scenes](./Unity%20structure/Scenes.png)
    2. GameObjects
  We structured our game objects and organize way to facilitate scripts deployments. Most of our objects are linked to Monobehavior scripts in order to be interactive or moving.
  ![GameObjectTree](./Unity%20structure/GameObjects.png)
  ![Scripts files](./Unity%20structure/Scripts.png)
    3. Animation / Animator
  Alon created a lot of animations in order to have a visual queues when our main character have different states. For example if the oxygen level of our character is below 50%, the walk animation with switch to a walk animation with tilting. The jump is also a mix of 3 animations that represents a state of the jump (rising, falling, landing). Patrick went crazy with a crazy amount of entangled transitions.
  ![Animator](./Unity%20structure/Animator.png)
    4. Input system
  In order to move our main character we used the Input from unity. Allowing us to move on keydown.
  ![Input](./Unity%20structure/Input%20system.png)
  This input system coupled to our scripts allow us to move around our plant.
    5. Particule System
  We used the Particle system from Unity in order to create some nice effect and give a special feeling to our game.
- C# & Theory of CG&A
    1. Rotating satellite around the planet

       The implemented feature is a spaceship that orbits the planet in the shape of an ellipse.

       Based on the center of the planet, rotation speed of the spaceship and min- and maxRadius around the planet, the script calculates the position of the spaceship along the orbit at a given time using Quaternion.Euler.

       By using Quaternion.LookRotation, the script can then apply the correct rotation of the spaceship, taking the desired forwards and upwards vector.

       The script finally interpolates between minimum radius and maximum radius, based on the distance between spaceship and planet.

    2. Gravity system
  
        Choosing a planet as base structure brings a lot to the game but also some challenges. This will be explained further down in that report.

    3. Random Scripts

        In order to decorate our planet, we handplaced some assets but also used scripts in order to rotate and scale this item.
        A script is attached to a parent object that contain all the objects that need to be scale or rotated. Then all the child object are rotated to the center of the moon.
  ```csharp
                // rotate
            Quaternion rotation = child.rotation;
            Vector3 gravityUp = (child.position - moonTransform.transform.position).normalized;
            Vector3 bodyUp = child.up;

            Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * rotation;
            rotation = Quaternion.Slerp(rotation, targetRotation, 1);
            child.rotation = rotation;
    ```
  The object are then scaled based on a random range between serializable inputs.
    ```csharp
            // scale
            float rdmSize = Random.Range(minSize, maxSize);
            child.localScale = new Vector3(rdmSize, rdmSize, rdmSize);
  ```

#### Implementation Logic Explanation:
Our basic idea was an Astronaut character wandering around a planet and collecting materials to repair his rocket.
- The first step was to create a planet (Sphere primitive) and to create attraction between this planet and the different objects wandering on it. This point is explained in more detailed in the next part. We have a script attached to the planet that define it as an attractor object with an attract method. We then apply a script to all objects that we want attracted to it aso they stuck to it.
- We then created a player to move around the planet with an input system.
- After making sure our player was correctly moving around, we implemented a camera to follow him in a 3rd person style in order to see the great animations from Alon. This was actually tricky as the system we saw in class was a camera movement based on 2 axes. But our planet choice made this unusable. We opted then for a Cinemachine implemented by Patrick that would lock on the player and use the mouse to rotate it around the up direction vector3 of the player.
- It was now time to implement a different scene. A Rocket modeled by Alon is accessible by the player and allow you to access a different scene, with different atmosphere and camera system. This scene was created by Patrick and give more depth to the game.
- We implemented enemies outside. Our enemies are not attacking the Player but move on their own. They always advance and rotate to a random direction at a random interval. There is also a BoxCast in front of them to make them turn 90 degree (or -90 degree) if they are in front of an obstacle.
- We added the possibility to stomp the enemy. With different trigger and conditional check, if the feet of the player collide with the head of the enemy (a feet emptyGameObject and a head emptyGameObject, both with a box collider have been added to Player and the enemies). By jumping on the enemy the player 'destroy' him.
- Oxygen system: We wanted to add a time constraint to the character. An oxygen bar is being reduced overtime and killing the player if reach 0. This oxygen is getting regenerated in the rocket.
- We added a health system to our player, every collision with the enemy make you lose one of your 5 hearts, dying at 0.
- In order to keep some data from one scene to the other, Patrick implemented a DataStorage global object that is not destroyed on load.
- A few other props have been added to the scene with different scripts to make the game prettier.

#### Three Important Achievements:
1. Gravity System:
The use of a planet as a base structure was a total agreement between us -little we know-. The gravity consist of 2 scripts: 
> GravityAttraction &&
> GravityBody

The first script ```GravityAttraction``` is placed on the planet. It is the object where the pull comes from.
```csharp
public class GravityAttractor : MonoBehaviour
{
    
    private float _gravity;

    public void Attract(Transform body, Rigidbody rb, float smoothInterpolator)
    {
        Quaternion rotation = body.rotation;
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;
        
        rb.AddForce(gravityUp * (_gravity * rb.mass));
        
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * rotation;
        rotation = Quaternion.Slerp(rotation, targetRotation, smoothInterpolator);
        body.rotation = rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        _gravity = DataStorage.instance.Gravity;
    }
}
```
This script is attach to our planet and have an *Attract* method. This method rotate the connected object so the bottom is in contact with the planet and apply a force that pulls this object towards the center.
The connected object has its own ```GravityBody``` attached to it.
```csharp
[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    [SerializeField] private GravityAttractor attractor;
    [SerializeField] [Range(0, 1)] private float smoothInterpolationParam = 1f;
    [SerializeField][Range(1, 1000)] private float objectMass = 500f;
    [Space(10)]

    private Rigidbody _myRigidBody;
    private Transform _myTransform;

    private void Awake()
    {

    }

    void Start()
    {
        if (attractor == null)
        {
            attractor = transform.GetComponentInParent<GravityAttractor>();
        }
        
        // set RigidBody parameters
        _myRigidBody = GetComponent<Rigidbody>();
        _myRigidBody.constraints = RigidbodyConstraints.FreezeRotation;
        _myRigidBody.useGravity = false;
        _myRigidBody.mass = objectMass;
        _myRigidBody.interpolation = RigidbodyInterpolation.Extrapolate;
        _myRigidBody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        _myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        attractor.Attract(_myTransform, _myRigidBody, smoothInterpolationParam);
    }
}
```
This script requires a RigidBody component on the object and changes its parameters. On the update function, we call attract from the Attractor object so the object is always pulled toward the planet.
These 2 scripts might not seem like much but the entire logic it brings was totally different from what we saw in class. Succeeding in having a planet and a Player that behave logically (not rotating the planet on movement) is a great satisfaction.


2. Sound System
The sound system was tricky to create. We wanted sound to have feedback and create an atmosphere but our game is in space, a silent place.
Finding and collecting sounds to match our atmosphere was a long task that required a lot of patience from Alon. The most complicated part was to get the right sound at the right volume and mostly, at the right place.

We wanted to showcase what we learned in our course, we used buses, Spatialization, and triggers. But because our atmosphere is specific, we need the right amount of sounds and effects.
Looking back at the quality of the work of Alon, I think the sound system is not a requirement anymore but a real asset to our game.

3. Camera system
The camera system the Patrick did give some really 'good and smooth' feelings to the game.
Due to the particular system we chose, Patrick I to learn and fight with Cinemachines. 
the results is really great, with damping and recentering, the outside camera follow the player and allow you to rotate to explore a world and assets we put a lot of effort into. Additionally, using static and virtual cameras, Patrick created this awesome scene inside that really give you the instant feeling of being in the rocket. The virtual camera allows you to zoom in and transition into the computer, making some small assets a master part of the scene.

### Learned Knowledge from the Project

#### Major Challenges and Solutions:
(List down and explain the major challenges. Did you solve it? How? Please explain in detail.)
1. Understanding and creating our own gravity system.
As said multiple time in that report, This sphere and this gravity system were really hard to implement. What we thought would take one day took 3 days in total and bring challenges afterwards.
2. Working on the same project, even with GitHub was hard to do on such a small project. As most a the thing are connected, it was really hard to work simultaneously on the project without creating huge merging conflict.
We came up with more regular meeting and merging session in order to make sure all the progress were always pushed.

#### Minor Challenges and Solutions:
(List down and explain the minor challenges. Did you solve it? How? Please explain in detail.)
1. Camera movement. The thing that gave us the worst time was the camera movement around the player. Using a sphere and rotating our player around made the system used in class obsolete. The camera would indeed go into the sphere when the player reached a certain position. We decided to use Cinemachine and to simplify the camera system.
2. Implementing the asset. Alon worked really hard on modeling and animating our assets. Everything were done good on his side but the implementation in Unity always came with difficulty. We ended up integrating the asset under the supervision of Alon, checking if the behavior were the expected one.

### Reflections on the Own Project:
(List down and explain what you could improve and add if you have more time.)
1. more movement mechanics (fly, drive etc.)
2. more game mechanics (fulfilling quests, building different things with different items etc.)
3. improve enemies: hit detection & more of a threat 
4. improved version of our visuals (planet with more assets?)
