using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    Color originalColor;

    float Flashtime = .15f;

    // Start is called before the first frame update

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void DamageFlashStart()

    {
        spriteRenderer.color = Color.white;

        Invoke("DamageFlashStop", Flashtime);
    }



    void DamageFlashStop()
    {
        spriteRenderer.color = originalColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player Projectile")
        {
            Debug.Log("Player shot square");

            DamageFlashStart();
        }
    }
}
