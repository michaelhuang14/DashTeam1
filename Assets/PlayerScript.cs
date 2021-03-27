using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera mainCamera;

    private Rigidbody2D RB;
    private LineRenderer LR;
    private SpriteRenderer spriteR;
    public float normal_speed;
    public float slow_speed;
    public Color c1 = Color.blue;
    public Color c2 = Color.red;
    public float maxDash;
 
    void Start()
    {
        LR = gameObject.AddComponent<LineRenderer>();
        LR.material = new Material(Shader.Find("Sprites/Default"));
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        LR.sortingLayerName = "Background";
        LR.sortingOrder = 0;
        LR.colorGradient = gradient;
        RB = GetComponent<Rigidbody2D>();
        LR.SetWidth(0.2f, 0.2f);
        LR.enabled = false;
        LR.SetPosition(0, RB.position);
        LR.SetPosition(1, RB.position + (new Vector2(0f,5f)));
        LR.positionCount = 2;
        normal_speed = 5f;
	slow_speed = 0.3f;
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sortingOrder = 1;
        maxDash = 10f;
    }

    private void FixedUpdate()
    {
    }

    void Update()
    {
	float speed = normal_speed;
        Vector2 newVel = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W)) newVel.y += 1f;
        if (Input.GetKey(KeyCode.S)) newVel.y -= 1f;
        if (Input.GetKey(KeyCode.D)) newVel.x += 1f;
        if (Input.GetKey(KeyCode.A)) newVel.x -= 1f;
        if (Input.GetKey(KeyCode.Space))
        {
                speed = slow_speed;
                Vector3 mousept = Input.mousePosition;
                mousept.z = Camera.main.nearClipPlane;
                Vector2 worldpos = Camera.main.ScreenToWorldPoint(mousept);
                Vector2 mouseDir = worldpos - RB.position;
               	if (mouseDir.magnitude > maxDash)
		{
			mouseDir.Normalize();
			mouseDir *= maxDash;
		}
		newVel = mouseDir;	
                LR.SetPosition(0, RB.position + new Vector2(0f,0.5f));
                LR.SetPosition(1, RB.position + mouseDir);
                LR.enabled = true;
		spriteR.material.SetColor("_Color", Color.black);
        }
        if (Input.GetKeyUp("space"))
        {
                RB.position = LR.GetPosition(1);
                LR.enabled = false;       
		spriteR.material.SetColor("_Color", Color.white); 
        } 
        newVel.Normalize(); newVel *= speed;
        RB.velocity = newVel;
        
    }
}
