using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessoryButton : MonoBehaviour
{
    [SerializeField] GameObject accessoryVariantsList;
    [SerializeField] GameObject accessoriesList;
    [SerializeField] GameObject accessoryVariantButton;
    [SerializeField] string spritesResourcesName;

    
    public void onClick()
    {
        accessoryVariantsList.transform.Find("Accessory_name").GetComponent<TextMeshProUGUI>().text = spritesResourcesName;

        // Instantiating this new button in Panel gameObject in invisible menu
        var button = Instantiate(accessoryVariantButton);
        var button1 = Instantiate(accessoryVariantButton);
        var button2 = Instantiate(accessoryVariantButton);
        var button3 = Instantiate(accessoryVariantButton);
        button.transform.SetParent(accessoryVariantsList.transform.Find("Scroll").Find("Panel"));
        button1.transform.SetParent(accessoryVariantsList.transform.Find("Scroll").Find("Panel"));
        button2.transform.SetParent(accessoryVariantsList.transform.Find("Scroll").Find("Panel"));
        button3.transform.SetParent(accessoryVariantsList.transform.Find("Scroll").Find("Panel"));

        accessoryVariantsList.transform.Find("Scrollbar").GetComponent<Scrollbar>().value = .5f;

        accessoriesList.SetActive(false);
        accessoryVariantsList.SetActive(true);
    }
}
