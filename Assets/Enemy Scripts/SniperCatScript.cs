using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCatScript : MonoBehaviour
{
    public GameObject Player;

    public GameObject BulletPF;

    private Rigidbody2D RB;
    private SpriteRenderer spriteR;

    private float speed;

    bool WithinRange()
    {
        Vector3 displacement = transform.position - Player.transform.position;
        return (displacement.magnitude > 20);
    }

    void Patterns()
    {
        Vector3 displacement = transform.position - Player.transform.position;
        if (displacement.magnitude < 20)
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

        speed = 3.5f;

        StartCoroutine(MakeBullet());
    }

    void Update()
    {
        Patterns();
    }

    IEnumerator MakeBullet()
    {
        while (true)
        {
            if(WithinRange())
            {
                GameObject bullet = Instantiate(BulletPF);
                bullet.GetComponent<BulletScript>().Player = Player;
                bullet.transform.position = transform.position;
            }
            yield return new WaitForSeconds(0.8f);
        }
    }

    public void Death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        Destroy(gameObject);
    }
}
