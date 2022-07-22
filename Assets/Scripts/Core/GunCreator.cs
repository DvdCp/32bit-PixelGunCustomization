using UnityEngine;
using UnityEngine.InputSystem;

public class GunCreator : MonoBehaviour
{
    [SerializeField] string weaponName;

    private SpriteLoader spriteLoader;

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

        //// Accessories that could be not equipped on gun
        //int randomMuzzle = Random.Range(0, _muzzles.Length + 1);
        //if(randomMuzzle == _muzzles.Length)
        //    muzzle.sprite = null;
        //else
        //    muzzle.sprite = _muzzles[randomMuzzle];

        //int randomAim = Random.Range(0, _aims.Length + 1);
        //if(randomAim  == _aims.Length)
        //    aim.sprite = null;
        //else
        //    aim.sprite = _aims[randomAim];

        //int randomHandgrip = Random.Range(0, _handgrips.Length + 1);
        //if(randomHandgrip  == _handgrips.Length)
        //    handgrip.sprite = null;
        //else
        //    handgrip.sprite = _handgrips[randomHandgrip];

    }

}
