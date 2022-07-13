using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class SubAccessoryMenu : MonoBehaviour
{
    [SerializeField] GameObject accessoryVariantButton;

    private SpriteLoader spriteLoader;
    private GameObject accessoryButtons;
    private Transform Scroll;
    private Transform Panel;

    private string _accessoryName;
    public string AccessoryName { set => _accessoryName = value; }

    private SpriteRenderer _accessorySpriteRenderer;
    public SpriteRenderer AccessorySpriteRenderer { set => _accessorySpriteRenderer = value; }

    void Awake()
    {
        CreateVariantsMenu();
    }

    private void CreateVariantsMenu()
    {
        spriteLoader = GameObject.Find("SpriteLoader").GetComponent<SpriteLoader>();

        accessoryButtons = GameObject.Find("AccessoriesButtonGroup");
        Scroll = transform.Find("Scroll");
        Panel = Scroll.Find("Panel");

        // Setting accessories list name
        transform.Find("Accessory_name").GetComponent<TextMeshProUGUI>().text = _accessoryName;

        List<Sprite[]> accessoryLists = spriteLoader.getAccessoriesByName(_accessoryName);

        foreach (Sprite[] accessories in accessoryLists)
        {

            var newAccessory = Instantiate(accessoryVariantButton);
            newAccessory.transform.SetParent(Panel);

            newAccessory.GetComponent<SubAccessoryButton>().setVariantImage(accessories[0]);
            newAccessory.GetComponent<SubAccessoryButton>().setVariantList(accessories);
            newAccessory.GetComponent<SubAccessoryButton>().setAccessoryRenderer(_accessorySpriteRenderer);
        }
    }

    public void ActvivateSubAccessoryMenu()
    { 
        gameObject.SetActive(true);
        accessoryButtons.SetActive(false);
    }
    public void DeactvivateSubAccessoryMenu()
    {
        gameObject.SetActive(false);
        accessoryButtons.SetActive(true);
    }

    public void applyVariantToWeapon(Sprite variatToApply)
    { 
        _accessorySpriteRenderer.sprite = variatToApply;
    }

}
