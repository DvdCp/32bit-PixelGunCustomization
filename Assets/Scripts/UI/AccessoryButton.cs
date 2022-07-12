using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryButton : MonoBehaviour
{
    [SerializeField] string accessoryName;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SubAccessoryMenu subMenu;


    private void Start()
    {
        // Setting accessoryName and spriteRenderer to subMenu
        subMenu.AccessoryName = accessoryName;
        subMenu.AccessorySpriteRenderer = spriteRenderer;
    }

    public void onClickActvivateSubMenu()
    {
        subMenu.ActvivateSubAccessoryMenu();
    }
}
