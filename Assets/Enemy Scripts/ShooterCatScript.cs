using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCatScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPF;

    private int ctr;

    private SpriteRenderer spriteR;
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.red);

        StartCoroutine(MakeBullet());
    }

    void Update()
    {

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

    public void Death()
    {
        // after boom boom effects are finished by artists, instantiate boom boom effects here
        Destroy(gameObject);
    }
}
