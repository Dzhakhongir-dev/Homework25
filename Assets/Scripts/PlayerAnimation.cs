using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private InputManager inputManager;
    private Animator animator;

    private string currentState;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (inputManager.inputAlpha1)
        {
            ChangeAnimationState(StringVariables.Salute);
        }
        else if (inputManager.inputAlpha2)
        {
            ChangeAnimationState(StringVariables.SwingDancing);
        }
        else if (inputManager.inputAlpha3)
        {
            ChangeAnimationState(StringVariables.HipHopDancing);
        }
        else if (inputManager.inputAlpha4)
        {
            ChangeAnimationState(StringVariables.TutHipHopDancing);
        }
        else if (inputManager.inputAlpha5)
        {
            ChangeAnimationState(StringVariables.ThrillerDancing);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeAnimationState(StringVariables.BaseState);
        }

    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }
}
