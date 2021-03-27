using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use Physics.RayCastAll for detecting collisions . Then, on button up, trigger the related colliders

public class PlayerScript : MonoBehaviour
{
    public Camera mainCamera;
    public float normal_speed;
    public float slow_speed;
    public Color c1 = Color.blue;
    public Color c2 = Color.red;
    public float maxDash;

    private GameObject dashRangeChild;
    private LineRenderer dashRange;
    private Rigidbody2D RB;
    private LineRenderer LR;
    private SpriteRenderer spriteR;
    
    private float dashLength;
    private int segments = 50;
    void Start()
    {
	RB = GetComponent<Rigidbody2D>();
	LR = gameObject.AddComponent<LineRenderer>();
	dashRange = new GameObject().AddComponent<LineRenderer>();
        dashRange.gameObject.transform.parent = transform;
        // just to be sure reset position and rotation as well

	//dashRange = dashRangeChild.gameObject.AddComponent<LineRenderer>();	
	spriteR = GetComponent<SpriteRenderer>();

	float alpha = 1.0f;
	
        dashRange.material = new Material(Shader.Find("Sprites/Default"));
	dashRange.SetWidth(0.15f, 0.15f);
        Gradient gradient1 = new Gradient();
        gradient1.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(Color.white, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
	dashRange.enabled = false;
	dashRange.positionCount = segments + 1;
	dashRange.useWorldSpace = false;
	dashRange.colorGradient = gradient1;	
	
        LR.material = new Material(Shader.Find("Sprites/Default"));
        Gradient gradient2 = new Gradient();
        gradient2.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        LR.sortingLayerName = "Background";
        LR.sortingOrder = 0;
        LR.colorGradient = gradient2;
        LR.SetWidth(0.15f, 0.15f);
        LR.enabled = false;
        LR.SetPosition(0, RB.position);
        LR.SetPosition(1, RB.position + (new Vector2(0f,5f)));
        LR.positionCount = 2;
        

        normal_speed = 5f;
	slow_speed = 0.3f;
        
        spriteR.sortingOrder = 1;
        maxDash = 10f;
	dashLength = 0f;
    }

    void CreatePoints ()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = UnityEngine.Mathf.Sin (UnityEngine.Mathf.Deg2Rad * angle) * maxDash;
            y = UnityEngine.Mathf.Cos (UnityEngine.Mathf.Deg2Rad * angle) * maxDash;

            dashRange.SetPosition (i, new Vector2(x,y) );

            angle += (360f / segments);
        }
    } 
    void fixed_update(){

    }
    void Update()
    {
	float speed = normal_speed;
        Vector2 newVel = new Vector2(0f, 0f);
        if (Input.GetKey(KeyCode.W)) newVel.y += 1f;
        if (Input.GetKey(KeyCode.S)) newVel.y -= 1f;
        if (Input.GetKey(KeyCode.D)) newVel.x += 1f;
        if (Input.GetKey(KeyCode.A)) newVel.x -= 1f;
        if (Input.GetMouseButton(0))
        {
		dashLength += 0.1f;
                speed = slow_speed;
                Vector3 mousept = Input.mousePosition;
                mousept.z = Camera.main.nearClipPlane;
                Vector2 worldpos = Camera.main.ScreenToWorldPoint(mousept);
                Vector2 mouseDir = worldpos - RB.position;
		float orig_dist = mouseDir.magnitude;
		mouseDir.Normalize();
		newVel = mouseDir;
		float min_dist = System.Math.Min(orig_dist, System.Math.Min(maxDash, dashLength));
		mouseDir *= min_dist;
                LR.SetPosition(0, RB.position + new Vector2(0f,0.5f));
                LR.SetPosition(1, RB.position + mouseDir);
                LR.enabled = true;
		spriteR.material.SetColor("_Color", Color.black);
		CreatePoints();
		dashRange.enabled = true;
		
        }
        if (Input.GetMouseButtonUp(0))
        {
		dashLength = 0f;
                RB.position = LR.GetPosition(1);
                LR.enabled = false;       
		dashRange.enabled = false;
		spriteR.material.SetColor("_Color", Color.white); 
        } 
        newVel.Normalize(); newVel *= speed;
        RB.velocity = newVel; 
    }
}
