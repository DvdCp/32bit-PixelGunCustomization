using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlaymodeScript : MonoBehaviour
{
    [SerializeField] private Button _TryGunButton;
    [SerializeField] private GameObject ExitHintLabel;
    [SerializeField] private GameObject _AccessioriesButtonGroup;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GunController _gunController;

    private bool isPlaymode;

    private void Awake()
    {
        PlayerController playerController = new PlayerController();
        playerController.Player.ExitPlayMode.performed += exitTryGunMode;

        isPlaymode = false;

        // Enabling playerController
        playerController.Player.Enable();
    }

    void Start()
    {
        // Setting buttons state
        _TryGunButton.gameObject.SetActive(true);
        ExitHintLabel.SetActive(false);
        _playerInput.enabled = false;
    }

    public void enterTryGunMode()
    {
        isPlaymode = true;

        // Enabling "Exit" button
        ExitHintLabel.SetActive(true);
        // Disabling accessories button group
        _AccessioriesButtonGroup.SetActive(false);
        // Enabling "Try Gun" button (disabling itself)
        _TryGunButton.gameObject.SetActive(false);

        _playerInput.enabled = true;
    }

    public void exitTryGunMode(InputAction.CallbackContext context)
    {
        if (context.performed && isPlaymode)
        { 
            isPlaymode = false;

            // Enabling "Try Gun" button
            _TryGunButton.gameObject.SetActive(true);
            // Enabling accessories button group
            _AccessioriesButtonGroup.SetActive(true);
            // Disabling "Exit" button (disabling itself)
            ExitHintLabel.SetActive(false);

            _playerInput.enabled = false;

            _gunController.resetPosition();

        }
    }
}
