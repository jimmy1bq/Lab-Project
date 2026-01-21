using UnityEngine;

public class CharController : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float sensitivty;
    [SerializeField] float sprintSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float gravity;

    private float moveFr;
    private float moveLr;

    private float rotX;
    private float rotY;

    private Vector3 jumpVelocity = Vector3.zero;

    private Camera playerCam;

    private CharacterController cc;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cc = GetComponent<CharacterController>();

        playerCam = transform.GetChild(0).GetComponent<Camera>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float movementSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = sprintSpeed;
        }
        else
        {
            movementSpeed = speed;
        }
        //just maps the keyCode input to up and down
        moveFr = Input.GetAxis("Vertical") * movementSpeed;
        //just maps the keyCode input to left and right
        moveLr = Input.GetAxis("Horizontal") * movementSpeed;
        //maps mouse movement right and left
        rotX = Input.GetAxis("Mouse X") * sensitivty;
        //maps mouse movement up and down
        rotY += Input.GetAxis("Mouse Y") * sensitivty;
        //clamps just makes it so you can't go past certain values
        rotY -= Mathf.Clamp(rotY, -90f, 90f);

        Vector3 combineMovementVector = new Vector3(moveLr, 0, moveFr).normalized * movementSpeed;
        transform.Rotate(0, rotX, 0);
        playerCam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
        combineMovementVector = transform.rotation * combineMovementVector;
        if (cc.isGrounded)
        {
            if (jumpVelocity.y < 0)
            {
                jumpVelocity.y = -2f;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity.y = jumpForce;
            }
        }
        if (!cc.isGrounded)
        {
            jumpVelocity.y -= gravity * Time.deltaTime;
        }
        cc.Move((combineMovementVector + jumpVelocity) * Time.deltaTime);
    }
}