using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private SpriteRenderer spriteR;
    Color lightbrown = new Color(0.26f, 0.16f, 0.05f, 1f);

    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
	spriteR.sortingOrder = 0;
    	spriteR.material.SetColor("_Color", lightbrown);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
                spriteR.material.SetColor("_Color", Color.black);
        }else
	{
		spriteR.material.SetColor("_Color", lightbrown);
	}

    }
}
