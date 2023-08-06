using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput PlayerInput;

    public bool inputAlpha1 { get; private set; } 
    public bool inputAlpha2 { get; private set; } 
    public bool inputAlpha3 { get; private set; } 
    public bool inputAlpha4 { get; private set; } 
    public bool inputAlpha5 { get; private set; } 

    public Vector2 Move { get; private set; }
    public Vector2 Look { get; private set; }
    public bool Run { get; private set; }
    public static InputManager Instance { get; internal set; }

    public InputActionMap currentMap;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction runAction;

    private void Awake()
    {
        //HideCursor();
        

        currentMap = PlayerInput.currentActionMap;
        moveAction = currentMap.FindAction(StringVariables.Move);
        lookAction = currentMap.FindAction(StringVariables.Look);
        runAction = currentMap.FindAction(StringVariables.Run);

        moveAction.performed += OnMove;
        lookAction.performed += OnLook;
        runAction.performed += OnRun;

        moveAction.canceled += OnMove;
        lookAction.canceled += OnLook;
        runAction.canceled += OnRun;

    }

    private void Update()
    {
        inputAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        inputAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        inputAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        inputAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        inputAlpha5 = Input.GetKeyDown(KeyCode.Alpha5);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>().normalized;
    }
    private void OnRun(InputAction.CallbackContext context)
    {
        Run = context.ReadValueAsButton();
    }
    private void OnLook(InputAction.CallbackContext context)
    {
        Look = context.ReadValue<Vector2>();
    }
    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
