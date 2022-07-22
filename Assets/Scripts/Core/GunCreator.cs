using UnityEngine;
using UnityEngine.InputSystem;

public class GunCreator : MonoBehaviour
{
    [SerializeField] string weaponName;

    private SpriteLoader spriteLoader;

    [Header("ACCESSORIES SPRITE RENDERERS")]
    public SpriteRenderer body;
    public SpriteRenderer stock;
    public SpriteRenderer barrel;
    public SpriteRenderer grip;
    public SpriteRenderer mag;
    public SpriteRenderer muzzle;
    public SpriteRenderer aim;
    public SpriteRenderer handgrip;
    public Transform firePoint;

    private void Start()
    {
        spriteLoader = GameObject.Find("SpriteLoader").GetComponent<SpriteLoader>();
    }

    public void randomSetup()
    {
        body.sprite =       spriteLoader.getRandomAccessory("Body");
        stock.sprite =      spriteLoader.getRandomAccessory("Stock");
        barrel.sprite =     spriteLoader.getRandomAccessory("Barrel");
        grip.sprite =       spriteLoader.getRandomAccessory("Grip");
        mag.sprite =        spriteLoader.getRandomAccessory("Mag");
        aim.sprite =        spriteLoader.getRandomAccessory("Aim");
        handgrip.sprite =   spriteLoader.getRandomAccessory("Handgrip");
    }

}
