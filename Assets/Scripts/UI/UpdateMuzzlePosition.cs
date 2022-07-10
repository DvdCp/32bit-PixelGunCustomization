using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMuzzlePosition : MonoBehaviour
{
    Sprite barrel;
    GameObject firePoint;

    void Update()
    {
        barrel = transform.parent.GetComponent<SpriteRenderer>().sprite;

        var newX = barrel.bounds.center.x + barrel.bounds.size.x / 2;
        transform.localPosition = new Vector3(newX, 0f, 0f);

        //// Updating firePoint position
        var firePointX = transform.GetComponent<SpriteRenderer>().sprite.bounds.center.x;
        var firePointY = transform.GetComponent<SpriteRenderer>().sprite.bounds.center.y;

        firePoint.transform.localPosition = new Vector3(firePointX, firePointY / 2, 0f);
    }
}
