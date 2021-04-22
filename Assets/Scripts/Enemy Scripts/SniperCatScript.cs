using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCatScript : MonoBehaviour, Enemy
{
    public GameObject Player;
    public bool isDead { get; set; }
    public GameObject BulletPF;

    private Rigidbody2D RB;
    private SpriteRenderer spriteR;

    private float speed;

    bool WithinRange()
    {
        Vector3 displacement = transform.position - Player.transform.position;
        return (displacement.magnitude > 10);
    }

    void pattern()
    {
        Vector3 displacement = transform.position - Player.transform.position;
        if (!WithinRange())
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
        isDead = false;
        speed = 3.5f;

        StartCoroutine(MakeBullet());
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

    public void death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        isDead = true;
    }
    public void step()
    {
        pattern();
    }
}
