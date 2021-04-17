using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCatScript : MonoBehaviour, Enemy
{
    public GameObject Player;
    public GameObject BulletPF;
    public bool isDead { get; set; }

    private int ctr;

    private SpriteRenderer spriteR;

    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.red);
        isDead = false;
        StartCoroutine(MakeBullet());
    }


    IEnumerator MakeBullet()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            GameObject bullet = Instantiate(BulletPF);
            bullet.GetComponent<BulletScript>().Player = Player;
            bullet.transform.position = transform.position;
        }
    }

    public void death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        isDead = true;
        Debug.Log("Shooter Cat Death");
    }

    public void step()
    {

    }
}
