using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCatScript : MonoBehaviour
{
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 2;
        spriteR.material.SetColor("_Color", Color.white);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    { 
        Debug.Log("Dash hit detected");
    }
}
