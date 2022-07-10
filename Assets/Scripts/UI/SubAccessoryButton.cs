using UnityEngine;
using UnityEngine.UI;

public class SubAccessoryButton : MonoBehaviour
{
    private SpriteRenderer accessoryRenderer;
    private Image variantImage;
    private Sprite[] variantList;
    private int variantSize;
    private int variantIndex = 0;

    private void Awake()
    {
        variantImage = gameObject.transform.Find("AccessoryTypeButton").Find("VariantImage").GetComponent<Image>();
    }

    public void setVariantList(Sprite[] variantList)
    { 
        this.variantList = variantList;
        variantSize = variantList.Length;
    }

    public void setVariantImage(Sprite sprite)
    {
        variantImage.sprite = sprite;
    }

    public void setAccessoryRenderer(SpriteRenderer renderer)
    { 
        accessoryRenderer = renderer;
    }

    public void nextVariant()
    {
        // go to next variant
        variantIndex++;

        if (variantIndex % variantSize == 0)
            variantIndex = 0;

        // update sprite in button and on weapon
        variantImage.sprite = variantList[variantIndex];
        accessoryRenderer.sprite = variantList[variantIndex];
    }

    public void prevVariant()
    {
        // go to prev variant
        variantIndex--;

        // update sprite button
        if (variantIndex == -1)
            variantIndex = variantSize - 1;

        // update sprite in button and on weapon
        variantImage.sprite = variantList[variantIndex];
        accessoryRenderer.sprite = variantList[variantIndex];
    }
}
