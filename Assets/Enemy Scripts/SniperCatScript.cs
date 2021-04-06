using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCatScript : MonoBehaviour
{
    public GameObject Player;

    private Rigidbody2D RB;
    private SpriteRenderer spriteR;

    private float speed;

    void Patterns()
    {
        Vector3 displacement = transform.position - Player.transform.position;
        if (displacement.magnitude < 9)
        {
            RB.velocity = Vector3.Normalize(displacement) * speed;
        }
        else
        {
            RB.velocity = Vector2.zero;
        }
    }

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.gray);
        RB = GetComponent<Rigidbody2D>();

        speed = 7f;
    }

    private void FixedUpdate()
    {
        Patterns();
    }

    public void Death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        Destroy(gameObject);
    }
}
