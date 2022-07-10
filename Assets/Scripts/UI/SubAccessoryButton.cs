using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubAccessoryButton : MonoBehaviour
{
    [SerializeField] Image variantImage;

    private Sprite[] variantList;
    private int variantSize;
    private int variantIndex = 0;

    public void setVariantList(Sprite[] variantList)
    { 
        this.variantList = variantList;
        variantSize = variantList.Length;
    }

    public void setVariantImage(Sprite sprite)
    {
        variantImage.sprite = sprite;
        
    }

    public void nextVariant()
    {
        // go to next variant
        variantIndex++;

        if (variantIndex % variantSize == 0)
            variantIndex = 0;

        // update sprite in button
        variantImage.sprite = variantList[variantIndex];
    }

    public void prevVariant()
    {
        // go to prev variant
        variantIndex--;

        // update sprite button
        if (variantIndex == -1)
            variantIndex = variantSize - 1;

        // update sprite in button
        variantImage.sprite = variantList[variantIndex];
    }
}
