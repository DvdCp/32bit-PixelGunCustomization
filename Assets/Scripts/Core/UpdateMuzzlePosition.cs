using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMuzzlePosition : MonoBehaviour
{
    Sprite barrel;

    void Update()
    {
        barrel = transform.parent.GetComponent<SpriteRenderer>().sprite;

        var newX = barrel.bounds.center.x + barrel.bounds.size.x / 2;
        transform.localPosition = new Vector3(newX, 0f, 0f);
    }

}
