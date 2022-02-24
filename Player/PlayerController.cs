using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // audio variables //

    public AudioSource footWalk;
    public AudioSource Light;
    // Variable for camera shake with footstep //
    [SerializeField] private bool headBobEnable = true;
    [SerializeField][Range(0.0f, 0.1f)] float amplitude = 0.015f;
    [SerializeField][Range(0.0f, 30f)]float frequency = 10.0f;
    float defaultYPos = 0.0f;
    float timer;



    // variable for movement and mouse look //
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensivity = 10.0f;
    [SerializeField] float walkSpeed = 5.0f;
    [SerializeField] bool lockCursor = true;
    [SerializeField] [Range(0.0f, 100.0f)] float gravity = 10.0f;

    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.23f;
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f;



    float cameraPitch = 0.0f;
    float velocityY = 0.0f;  
    CharacterController controller = null;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        defaultYPos = playerCamera.transform.localPosition.y;
        if(lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        ManageCharacterFX();



    }

    void ManageCharacterFX()
    {
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            footWalk.Play();
        }
        if (Input.GetButtonDown("FlashLight"))
        {
            Light.Play();
        }

        if(Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            footWalk.Stop();
        }
        

 



    }

    void UpdateMovement()
    {
        

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if(controller.isGrounded)
        {
            velocityY = 0.0f;
        }
        velocityY -= gravity * Time.deltaTime;


        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
        // test headBob
        if (headBobEnable)
        {
            HeadBobEffect(velocity);
        }
        // end headbob
        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);


        cameraPitch -= currentMouseDelta.y * mouseSensivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensivity);
    }

    void HeadBobEffect(Vector3 velocity)
    {
        if(!controller.isGrounded)
        {
            return;
        }

        if(Mathf.Abs(velocity.x) >0.1f || Mathf.Abs(velocity.z) > 0.1f)
        {
            playerCamera.transform.localPosition = new Vector3(
                playerCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(Time.time * frequency) * amplitude,
                playerCamera.transform.localPosition.z);
        }
    }

    
       
}
