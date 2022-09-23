using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    private Controls controls;
    private float h = 0f;
    private float v = 0f;

    [Header("Movement Variable")]
    [SerializeField] private float movementSpeed;
    [Header("Jump Forces Reference")]
    [SerializeField] private float jumpForce = 3f, highJumpForce = 1f;
    [Header("Can Movement Container")]
    [SerializeField] private bool canMove;
    [Header("Rigidbody Container")]
    [SerializeField] private Rigidbody rb;

    public enum PlayerState { WALKING, FALLING }
    [Header("Player State Reference")]
    public PlayerState state = PlayerState.WALKING;

    private bool jumpDown = false, highJumpDown = false;
    private float jumpForceBackup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
        jumpForceBackup = jumpForce;
        controls = new Controls();
        controls.Gameplay.Enable();
        controls.Gameplay.Jump.performed += JumpPerformed;
        controls.Gameplay.HighJump.performed += HighJump;
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        //.performed è quando premiamo il tasto
        if (!jumpDown)
        {
            jumpDown = true;
        }
    }

    public void HighJump(InputAction.CallbackContext context)
    {
        if (!highJumpDown)
        {
            highJumpDown = true;
        }
    }

    private void Update()
    {
        if (canMove)
        {
            // Input happens per-frame not in the Physics Loop
            h = controls.Gameplay.Move.ReadValue<Vector2>().x;
            v = controls.Gameplay.Move.ReadValue<Vector2>().y;
        }
        else
        {
            h = 0;
            v = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector2 input = SquareToCircle(new Vector2(h, v));

        Transform cam = Camera.main.transform;
        Vector3 moveDirection = Quaternion.FromToRotation(cam.up, Vector3.up)
            * cam.TransformDirection(new Vector3(input.x, 0f, input.y));

        switch (state)
        {
            case PlayerState.WALKING: { HandleWalking(moveDirection); } break;
            case PlayerState.FALLING: { HandleFalling(moveDirection); } break;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            state = PlayerState.WALKING;
        }
        //passa a falling dopo walking se saltiamo una volta, eliminarlo per fare il doppio salto
        else if (state == PlayerState.WALKING)
        {
            state = PlayerState.FALLING;
        }

        //Reset input
        jumpDown = false;
        highJumpDown = false;
        jumpForce = jumpForceBackup;
    }

    public void HandleWalking(Vector3 moveDirection)
    {
        if (jumpDown)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            state = PlayerState.FALLING;
        }
        else if (highJumpDown)
        {
            rb.AddForce(Vector3.up * (jumpForce + highJumpForce), ForceMode.Impulse);
            state = PlayerState.FALLING;
        }

        rb.velocity = new Vector3(moveDirection.x * movementSpeed, rb.velocity.y, moveDirection.z * movementSpeed);

        //fa ruotare il personaggio, e la condizione è la sensibilità
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            transform.forward = Vector3.Lerp(transform.forward,
                                            moveDirection,
                                            10f * Time.fixedDeltaTime);
        }
    }

    public void HandleFalling(Vector3 moveDirection)
    {
        rb.velocity = new Vector3(moveDirection.x * movementSpeed, rb.velocity.y, moveDirection.z * movementSpeed);
        //fa ruotare il personaggio, e la condizione è la sensibilità
        if (moveDirection.sqrMagnitude > 0.01f)
        {
            transform.forward = Vector3.Lerp(transform.forward,
                                            moveDirection,
                                            10f * Time.fixedDeltaTime);
        }
    }

    Vector2 SquareToCircle(Vector2 input)
    {
        return (input.sqrMagnitude >= 1f) ? input.normalized : input;
    }
}
