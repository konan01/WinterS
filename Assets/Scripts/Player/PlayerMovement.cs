using Photon.Pun;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 4f;            // The speed that the player will move at.

    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.

    private PhotonView photonView;
    private JoyCon joystik;
    private JoyCon joystik1;
    void Awake()
    {
        // Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask("Floor");
        joystik = GameObject.FindGameObjectWithTag("joistik").GetComponent<JoyCon>();
        joystik1 = GameObject.FindGameObjectWithTag("Joystik1").GetComponent<JoyCon>();
        // Set up references.
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
    }
    
    void FixedUpdate()
    {
        // Store the input axes.
        float h = joystik.Horizon();
        float v =joystik.Vertical();
        float h1 = joystik1.Horizon();
        float v1 = joystik1.Vertical();
       // print(h+" "+v);

       if(photonView.IsMine)
        {
            // Move the player around the scene.
            Move(h, v);

            // Turn the player to face the mouse cursor.
            Turning(h1, v1);

            // Animate the player.
            //Animating(h, v);
        }

    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        playerRigidbody.MovePosition(transform.position + movement);
    }
    Vector3 playerToMouse;
    void Turning(float h, float v)
    {
        
         if(h!=0 || v!=0)
        {
            playerToMouse.Set(h, 0f, v);
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        //bool walking = h != 0 || v != 0;
        if(h!=0 || v!=0)
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWlaking", true);
        else anim.SetBool("IsWlaking", false);
    }
}
