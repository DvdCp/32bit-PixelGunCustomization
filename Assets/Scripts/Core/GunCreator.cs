using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunCreator : MonoBehaviour
{
    [SerializeField] string weaponName;

    //private Sprite[] _bodies;
    //private Sprite[] _stocks;
    //private Sprite[] _barrels;
    //private Sprite[] _grips;
    //private Sprite[] _mags;
    //private Sprite[] _muzzles;
    //private Sprite[] _aims;
    //private Sprite[] _handgrips;

    public SpriteRenderer body;
    public SpriteRenderer stock;
    public SpriteRenderer barrel;
    public SpriteRenderer grip;
    public SpriteRenderer mag;
    public SpriteRenderer muzzle;
    public SpriteRenderer aim;
    public SpriteRenderer handgrip;
    public Transform firePoint;

    void Start()
    {
        //_bodies =       Resources.LoadAll<Sprite>("bodies");
        //_stocks =       Resources.LoadAll<Sprite>("stocks");
        //_barrels =      Resources.LoadAll<Sprite>("barrels");
        //_grips =        Resources.LoadAll<Sprite>("grips");
        //_mags =         Resources.LoadAll<Sprite>("mags");
        //_muzzles =      Resources.LoadAll<Sprite>("silencers");
        //_aims =         Resources.LoadAll<Sprite>("reflexs");
        //_handgrips =    Resources.LoadAll<Sprite>("handgrips");

    }

    // Update is called once per frame
    private void Update()
    {
        // In this case Input is used because PlayerController is inactive until game mode is turned off
        if (Input.GetKeyDown(KeyCode.R))
            randomSetup();
    }

    public void keyPressed(InputAction.CallbackContext context)
    {
        if(context.started)
            randomSetup();
    }

    public void randomSetup()
    {
        //body.sprite = _bodies[Random.Range(0,_bodies.Length)];
        //stock.sprite = _stocks[Random.Range(0,_stocks.Length)];
        //barrel.sprite = _barrels[Random.Range(0,_barrels.Length)];
        //grip.sprite = _grips[Random.Range(0,_grips.Length)];
        //mag.sprite = _mags[Random.Range(0,_mags.Length)];

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

        //updateVisual();
        print("Random setup");

    }

    private void updateVisual()
    {
        Destroy(barrel.gameObject.GetComponent<BoxCollider2D>());
        BoxCollider2D barrelCollider = barrel.gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        var barrelBox = barrelCollider.size;

        Destroy(muzzle.gameObject.GetComponent<BoxCollider2D>());
        BoxCollider2D muzzleCollider = muzzle.gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        muzzle.transform.localPosition = new Vector3(barrelBox.x, 0f, 0f);
        // muzzle.transform.position.x = barrelCenter.x + coords.x / 2;

        // Updating firePoint position
        var muzzleBox = muzzleCollider.size;
        firePoint.localPosition = new Vector3(muzzleBox.x, muzzleBox.y / 2, 0f);
    }

}
