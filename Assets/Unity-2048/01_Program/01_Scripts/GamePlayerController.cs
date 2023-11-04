using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace hyhy.game
{
    public enum PlayerInput
    {
        Up, Down, Left, Right
    }

    public class GamePlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset gameCtrl;
        [SerializeField] private Text t;
        private void Awake()
        {
            gameCtrl.FindActionMap("game").FindAction("up").performed += (o) => OnPressUp(o, PlayerInput.Up);
            gameCtrl.FindActionMap("game").FindAction("down").performed += (o) => OnPressUp(o, PlayerInput.Down);
            gameCtrl.FindActionMap("game").FindAction("left").performed += (o) => OnPressUp(o, PlayerInput.Left);
            gameCtrl.FindActionMap("game").FindAction("right").performed += (o) => OnPressUp(o, PlayerInput.Right);
        }

        private void OnPressUp(InputAction.CallbackContext context, PlayerInput playerInput)
        {
            t.text = playerInput.ToString();
            Debug.Log(playerInput.ToString());
        }
    }
}
