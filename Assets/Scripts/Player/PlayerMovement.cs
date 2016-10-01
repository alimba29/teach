using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigitBody;
    int floorMask;
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = transform.root.GetComponent<Animator>();
        playerRigitBody = transform.root.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);

    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed*Time.deltaTime;
        
        playerRigitBody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength))
        {
            
            Vector3 playerToMouse = floorHit.point - transform.position;
            //float angle = Mathf.Atan2(playerToMouse.x, playerToMouse.z);
           
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //Quaternion newRotation = Quaternion.EulerRotation(new Vector3(0f, angle, 0f));
            playerRigitBody.MoveRotation(newRotation);
           
        }
    }

    void Animating(float h, float v)
    {
        bool walking = Mathf.Abs(h + v) > 0f;
        anim.SetBool("isWalking", walking);
    }
}
