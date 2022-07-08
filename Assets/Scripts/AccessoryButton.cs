using TMPro;
using UnityEngine;

public class AccessoryButton : MonoBehaviour
{
    [SerializeField] GameObject accessoryVariantsList;
    [SerializeField] GameObject accessoriesList;
    [SerializeField] GameObject accessoryVariantButton;
    [SerializeField] string spritesResourcesName;

    private Transform Scroll;
    private Transform Scrollbar;
    private Transform Panel;

    private void Start()
    {
        // Getting reference to UI elements
        Scroll = accessoryVariantsList.transform.Find("Scroll");
        Scrollbar = Scroll.Find("Scrollbar");
        Panel = Scroll.Find("Panel");
    }

    public void onClick()
    {
        accessoryVariantsList.transform.Find("Accessory_name").GetComponent<TextMeshProUGUI>().text = spritesResourcesName;

        // Instantis accessory variant buttons as many as in sprite sheet

        accessoriesList.SetActive(false);
        accessoryVariantsList.SetActive(true);
    }
}
