using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D RB;

    public float speed;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        speed = 1f;
    }

    private void FixedUpdate()
    {
        Vector2 newVel = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W)) newVel.y += 1f;
        if (Input.GetKey(KeyCode.S)) newVel.y -= 1f;
        if (Input.GetKey(KeyCode.D)) newVel.x += 1f;
        if (Input.GetKey(KeyCode.A)) newVel.x -= 1f;
        newVel.Normalize(); newVel *= speed;
        RB.velocity = newVel;
    }

    void Update()
    {
        
    }
}
