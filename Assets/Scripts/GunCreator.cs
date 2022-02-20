using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunCreator : MonoBehaviour
{
    private Sprite[] _bodies;
    private Sprite[] _stocks;
    private Sprite[] _barrels;
    private Sprite[] _grips;
    private Sprite[] _mags;
    private Sprite[] _silencers;

    public SpriteRenderer body;
    public SpriteRenderer stock;
    public SpriteRenderer barrel;
    public SpriteRenderer grip;
    public SpriteRenderer mag;
    public SpriteRenderer silencer;

    // Start is called before the first frame update
    void Start()
    {
        _bodies = Resources.LoadAll<Sprite>("bodies");
        _stocks = Resources.LoadAll<Sprite>("stocks");
        _barrels = Resources.LoadAll<Sprite>("barrels");
        _grips = Resources.LoadAll<Sprite>("grips");
        _mags = Resources.LoadAll<Sprite>("mags");
        //_silencers = Resources.LoadAll<Sprite>("silencers");
    }

    // Update is called once per frame

    public void keyPressed(InputAction.CallbackContext context)
    {   
        if(context.performed)
        {
            body.sprite = _bodies[Random.Range(0,_bodies.Length)];
            stock.sprite = _stocks[Random.Range(0,_stocks.Length)];
            barrel.sprite = _barrels[Random.Range(0,_barrels.Length)];
            grip.sprite = _grips[Random.Range(0,_grips.Length)];
            mag.sprite = _mags[Random.Range(0,_mags.Length)];
            //silencer.sprite = _silencers[Random.Range(0,_silencers.Length)];
        }

    }

}
