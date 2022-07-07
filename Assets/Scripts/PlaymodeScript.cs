using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlaymodeScript : MonoBehaviour
{
    [SerializeField] private Button _TryGunButton;
    [SerializeField] private Button _ExitButton;
    [SerializeField] private GameObject _AccessioriesButtonGroup;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private GunController _gunController;

    // Start is called before the first frame update
    void Start()
    {
        // Setting buttons state
        _TryGunButton.gameObject.SetActive(true);
        _ExitButton.gameObject.SetActive(false);
        _playerInput.enabled = false;
    }

    public void enterTryGunMode()
    {
        // Enabling "Exit" button
        _ExitButton.gameObject.SetActive(true);
        // Disabling accessories button group
        _AccessioriesButtonGroup.SetActive(false);
        // Enabling "Try Gun" button (disabling itself)
        _TryGunButton.gameObject.SetActive(false);

        _playerInput.enabled = true;
    }

    public void exitTryGunMode()
    {
        // Enabling "Try Gun" button
        _TryGunButton.gameObject.SetActive(true);
        // Enabling accessories button group
        _AccessioriesButtonGroup.SetActive(true);
        // Disabling "Exit" button (disabling itself)
        _ExitButton.gameObject.SetActive(false);

        _playerInput.enabled = false;

        print("marona");
        _gunController.resetPosition();
    }
}
