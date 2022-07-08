using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToAccessories : MonoBehaviour
{
    [SerializeField] GameObject accessoryVariantsList;
    [SerializeField] GameObject accessoriesList;

    public void onClick()
    {
        accessoryVariantsList.SetActive(false);
        accessoriesList.SetActive(true);
    }
}
