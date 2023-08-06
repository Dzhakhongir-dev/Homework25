using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Variables")]
    [SerializeField] private float AnimationBlendSpeed = 10f;
    [SerializeField] private float walkSpeed = 3f;
    [SerializeField] private float runSpeed = 6f;

    [Header("Camera Variables")]
    [SerializeField] private float UpperLimit;
    [SerializeField] private float BottomLimit;
    [SerializeField] private float mouseSensitivity = 22f;
    [SerializeField] private Transform CameraRoot;
    [SerializeField] private Transform Camera;

    public bool isInverted;

    private bool hasAnimator;

    private Vector2 currentVelocity;
    private Rigidbody playerRigidbody;
    private InputManager inputManager;
    private Animator animator;
    private PlayerAnimation playerAnimation;

    private int xVelocityHash;
    private int yVelocityHash;

    private float cameraXRotation;

    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        hasAnimator = TryGetComponent(out animator);
        playerRigidbody = GetComponent<Rigidbody>();
        inputManager = GetComponent<InputManager>();

        xVelocityHash = Animator.StringToHash(StringVariables.X_Velocity);
        yVelocityHash = Animator.StringToHash(StringVariables.Y_Velocity);

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraMovement();
    }

    private void Move()
    {
        if (!hasAnimator) return;
        float targetSpeed = inputManager.Run ? runSpeed : walkSpeed;
        if (inputManager.Move == Vector2.zero) targetSpeed = 0f;

        currentVelocity.x = Mathf.Lerp(currentVelocity.x, inputManager.Move.x * targetSpeed, AnimationBlendSpeed * Time.fixedDeltaTime);
        currentVelocity.y = Mathf.Lerp(currentVelocity.y, inputManager.Move.y * targetSpeed, AnimationBlendSpeed * Time.fixedDeltaTime);

        var xVelocityDifference = currentVelocity.x - playerRigidbody.velocity.x;
        var zVelocityDifference = currentVelocity.y - playerRigidbody.velocity.z;

        playerRigidbody.AddForce(transform.TransformVector(new Vector3(xVelocityDifference, 0, zVelocityDifference)), ForceMode.VelocityChange);

        animator.SetFloat(xVelocityHash, currentVelocity.x);
        animator.SetFloat(yVelocityHash, currentVelocity.y);
    }

    private void CameraMovement()
    {
        if (!hasAnimator) return;

        var Mouse_X = inputManager.Look.x;
        var Mouse_Y = inputManager.Look.y;

        Camera.position = CameraRoot.position;
        cameraXRotation -= Mouse_Y * mouseSensitivity * Time.smoothDeltaTime;
        cameraXRotation = Mathf.Clamp(cameraXRotation, UpperLimit, BottomLimit);

        Camera.localRotation = Quaternion.Euler(cameraXRotation, 0, 0);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * Quaternion.Euler(0, Mouse_X * mouseSensitivity * Time.smoothDeltaTime, 0));
    }
}

