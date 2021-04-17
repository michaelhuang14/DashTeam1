using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCatScript : MonoBehaviour, Enemy
{
    public GameObject Player;
    public List<GameObject> activeEnemies = new List<GameObject>();

    private Rigidbody2D RB;
    private List<Vector2> velQ = new List<Vector2>();

    private float speed;

    public bool isDead { get; set; }

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

        speed = 4f;
    }


    public void death()
    {
        isDead = true;
    }

    public void step()
    {
        Vector2 currVel = (Vector2)(Player.transform.position - transform.position);
        currVel.Normalize();
        currVel *= speed;
        for(int i = 0; i < activeEnemies.Count -1; i++)
        {
            GameObject currE = activeEnemies[i];
            if (currE.transform.position == transform.position)
                continue;
            Vector3 displacement = currE.transform.position - transform.position;
            if (displacement.magnitude <= 2)
            {
                currVel -= (Vector2) displacement.normalized * 4f;
            }
        }
        currVel.Normalize();
        velQ.Add(currVel);
        if (velQ.Count > 50) velQ.RemoveAt(0);
        Vector2 sum = Vector2.zero;
        for(int i = 0; i < velQ.Count; i++)
        {
            sum += velQ[i];
        }
        sum /= 50;
        RB.velocity = sum * speed;
    }
}
