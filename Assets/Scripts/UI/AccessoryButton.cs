using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryButton : MonoBehaviour
{
    [SerializeField] string accessoryName;
    [SerializeField] SpriteRenderer spriteRenderer;


    private void Start()
    {

    }

    public void onClick()
    {


        //for (int i = 0; i < directoryCount; i++)
        //{
        //    GameObject newAccessoryButton = Instantiate(accessoryVariantButton);
        //    Image accessoryImage = newAccessoryButton.transform.Find("AccessoryTypeButton").Find("AccessoryImage").GetComponent<Image>();
        //    accessoryImage.sprite = 
        //    newButton.transform.SetParent(Panel);
        //}

        //gunCreator.ActivateSubAccessoryMenu();
    }
}
