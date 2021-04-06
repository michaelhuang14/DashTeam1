using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCatScript : MonoBehaviour
{
    public GameObject Player;

    private SpriteRenderer spriteR;
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.white);
    }

    private void FixedUpdate()
    {
        
    }

    public void Death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        Destroy(gameObject);
    }
}
