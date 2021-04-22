using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public GameObject Player;

    private Rigidbody2D RB;
    private SpriteRenderer spriteR;

    private float velX;
    private float velY;
    private float speed;
    Vector3 displacement;

    private int ctr;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.yellow);
        displacement = Player.transform.position - transform.position;
        speed = 5f;
        RB.velocity = Vector3.Normalize(displacement) * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
