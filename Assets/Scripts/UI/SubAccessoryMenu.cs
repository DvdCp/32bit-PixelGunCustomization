using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class SubAccessoryMenu : MonoBehaviour
{
    [SerializeField] string accessoryName;
    [SerializeField] SpriteRenderer accessorySpriteRenderer;
    [SerializeField] GameObject accessoryVariantButton;
    [SerializeField] SpriteLoader spriteLoader;

    private GameObject accessoryButtons;
    private Transform Scroll;
    private Transform Panel;

    void Awake()
    {
        accessoryButtons = GameObject.Find("AccessoriesButtonGroup");
        Scroll = transform.Find("Scroll");
        Panel = Scroll.Find("Panel");

        // Setting accessories list name
        transform.Find("Accessory_name").GetComponent<TextMeshProUGUI>().text = accessoryName;

        List<Sprite[]> accessoryLists = spriteLoader.getAccessoriesByName(accessoryName);

        foreach (Sprite[] accessories in accessoryLists)
        {
            var newAccessory = Instantiate(accessoryVariantButton);
            newAccessory.transform.SetParent(Panel);

            newAccessory.GetComponent<SubAccessoryButton>().setVariantImage(accessories[0]);
            newAccessory.GetComponent<SubAccessoryButton>().setVariantList(accessories);
        }
    }

    public void ActvivateSubAccessoryMenu(string name)
    { 
        gameObject.SetActive(true);
        accessoryButtons.SetActive(false);
    }
    public void DeactvivateSubAccessoryMenu(string name)
    {
        gameObject.SetActive(false);
        accessoryButtons.SetActive(true);
    }

}
