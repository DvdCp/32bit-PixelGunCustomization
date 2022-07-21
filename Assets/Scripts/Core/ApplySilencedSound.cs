using UnityEngine;

public class ApplySilencedSound : MonoBehaviour
{
    [SerializeField] private ShootingController controller;
    [SerializeField] private AudioClip silencedShot;

    private SpriteRenderer renderer;


    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (renderer.sprite != null)
            controller.ActualShotSound = silencedShot;
        else
            controller.ActualShotSound = null;
        
    }

}
