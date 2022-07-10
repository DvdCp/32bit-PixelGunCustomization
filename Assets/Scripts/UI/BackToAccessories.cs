using UnityEngine;

public class BackToAccessories : MonoBehaviour
{
    [SerializeField] GameObject accessoryVariantsList;
    [SerializeField] GameObject accessoriesList;

    private Transform Scroll;
    private Transform Panel;

    private void Start()
    {
        // Getting reference to UI elements
        Scroll = accessoryVariantsList.transform.Find("Scroll");
        Panel = Scroll.Find("Panel");
    }

    public void onClick()
    {
        accessoryVariantsList.SetActive(false);
        accessoriesList.SetActive(true);

        // Removing all accessories except the first (No_Accessory button)
        for (int i = 1; i < Panel.childCount; i++)
            Destroy(Panel.GetChild(i).gameObject);
    }
}
