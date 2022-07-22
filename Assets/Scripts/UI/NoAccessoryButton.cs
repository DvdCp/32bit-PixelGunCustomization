using UnityEngine;

public class NoAccessoryButton : MonoBehaviour
{
    private SpriteRenderer accessoryRenderer;

    public void removeAccessory()
    {
        accessoryRenderer.sprite = null;
    }

    public void setAccessoryRenderer(SpriteRenderer renderer)
    {
        accessoryRenderer = renderer;
    }

}
