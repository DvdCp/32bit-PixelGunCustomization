using UnityEngine;

public class UpdateMuzzlePosition : MonoBehaviour
{
    Sprite barrel;
    Transform muzzleFlash;

    private void Start()
    {
        muzzleFlash = transform.Find("muzzleFlash");
    }

    void Update()
    {
        barrel = transform.parent.GetComponent<SpriteRenderer>().sprite;

        var newX = barrel.bounds.center.x + barrel.bounds.size.x / 2;
        var newY = barrel.bounds.center.y - barrel.bounds.size.y / 3;
        transform.localPosition = new Vector3(newX, newY, 0f);

        // Try to get silencer sprite
        var silencerSprite = GetComponent<SpriteRenderer>().sprite;
        if (silencerSprite != null)
        {
            var shiftedX = silencerSprite.bounds.center.x + silencerSprite.bounds.size.x / 2;
            muzzleFlash.localPosition = new Vector3(shiftedX, 0f, 0f);
        }

    }

}
