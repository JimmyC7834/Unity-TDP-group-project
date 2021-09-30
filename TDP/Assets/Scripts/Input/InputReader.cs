using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

using TDP.Input;

// TODO: complete InputReader
[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject //, GameInput.IPointerActions, GameInput.IMenusActions
{
    // Pointer
    public event UnityAction<Vector2> moveEvent = delegate { };
    public event UnityAction confirmEvent = delegate { };
    public event UnityAction cancelEvent = delegate { };

    // Menus
    public event UnityAction<Vector2> menuMoveSelectionEvent = delegate { };
    public event UnityAction menuConfirmEvent = delegate { };
    public event UnityAction menuCancelEvent = delegate { };

    // !!! Remember to edit Input Reader functions upon updating the input map !!!
    private GameInput gameInput;

    private void OnEnable() {
        if (gameInput == null) {
            gameInput = new GameInput();

            // gameInput.Pointer.SetCallbacks(this);
            // gameInput.Menus.SetCallbacks(this);
        }

        // EnablePointerInput();
    }

    private void OnDisable() {

    }

    // -----POINTER-----
    public void OnMove(InputAction.CallbackContext context)
    {
        moveEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnConfirm(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            confirmEvent.Invoke();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            cancelEvent.Invoke();
    }

    // -----MENUS-----
    public void OnMenuMoveSelection(InputAction.CallbackContext context)
    {
        menuMoveSelectionEvent.Invoke(context.ReadValue<Vector2>());
    }

    public void OnMenuConfirm(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            menuConfirmEvent.Invoke();
    }

    public void OnMenuCancel(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            menuCancelEvent.Invoke();
    }

    // Input Reader
    // public void EnablePointerInput() {
    //     gameInput.Menus.Disable();

    //     gameInput.Pointer.Enable();
    // }

    // public void EnableMenusInput() {
    //     gameInput.Pointer.Disable();

    //     gameInput.Menus.Enable();
    // }

    // public void DisableAllInput() {
    //     gameInput.Pointer.Disable();
    //     gameInput.Menus.Disable();
    // }
}
