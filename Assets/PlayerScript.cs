using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Use Physics.RayCastAll for detecting collisions . Then, on button up, trigger the related colliders

public class PlayerScript : MonoBehaviour
{
    public Camera mainCamera;
    public float normal_speed;
    public Color dashColor1 = Color.blue;
    public Color dashColor2 = Color.red;
    public float maxDashLength;

    private LineRenderer dashRangeR;
    private Rigidbody2D RB;
    private LineRenderer dashLineR;
    private SpriteRenderer spriteR;
    
    
    private float dashLength;
    private int segments = 50;
    private int dashLayerMask = 1 << 6; // during dash, ignore colliders on all objects except those of the 6th layer
    void Start()
    {
	    RB = GetComponent<Rigidbody2D>();
	    dashLineR = gameObject.AddComponent<LineRenderer>();
	    dashRangeR = new GameObject().AddComponent<LineRenderer>();
        dashRangeR.gameObject.transform.parent = transform;
	    spriteR = GetComponent<SpriteRenderer>();
	
	    float alpha = 1.0f;
	
        dashRangeR.material = new Material(Shader.Find("Sprites/Default"));
        AnimationCurve dashRangeCurve = new AnimationCurve();
        dashRangeCurve.AddKey(0, 0.15f);
        dashRangeCurve.AddKey(1, 0.15f);
        dashRangeR.widthCurve = dashRangeCurve;
	    dashRangeR.enabled = false;
	    dashRangeR.positionCount = segments + 1;
	    dashRangeR.useWorldSpace = false;
	    dashRangeR.material.SetColor("_Color", Color.white);
	    dashRangeR.sortingOrder = 1;
	
        dashLineR.material = new Material(Shader.Find("Sprites/Default"));
        Gradient gradient2 = new Gradient();
        gradient2.SetKeys(
            new GradientColorKey[] { new GradientColorKey(dashColor1, 0.0f), new GradientColorKey(dashColor2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
	    dashLineR.sortingOrder = 1;
        dashLineR.colorGradient = gradient2;
        AnimationCurve dashCurve = new AnimationCurve();
        dashCurve.AddKey(0, 0.15f);
        dashCurve.AddKey(1, 0.15f);
        dashLineR.widthCurve = dashCurve;
        dashLineR.enabled = false;
        dashLineR.SetPosition(0, RB.position);
        dashLineR.SetPosition(1, RB.position + (new Vector2(0f,5f)));
        dashLineR.positionCount = 2;
        
	    normal_speed = 10f;
        
        spriteR.sortingOrder = 2;
	    spriteR.material.SetColor("_Color", Color.black);
        maxDashLength = 10f;
	    dashLength = 0f;
    }

    void DrawDashRangeCirc ()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = UnityEngine.Mathf.Sin (UnityEngine.Mathf.Deg2Rad * angle) * maxDashLength;
            y = UnityEngine.Mathf.Cos (UnityEngine.Mathf.Deg2Rad * angle) * maxDashLength;

            dashRangeR.SetPosition (i, new Vector2(x,y) );

            angle += (360f / segments);
        }
	    dashRangeR.enabled = true;
    } 
   
    void PlanDash()
    {
        spriteR.material.SetColor("_Color", Color.white);
        Vector2 lineDir = new Vector2(0f, 0f);
        Vector3 mousept = Input.mousePosition;
        mousept.z = Camera.main.nearClipPlane;
        Vector2 mouseVec = Camera.main.ScreenToWorldPoint(mousept);
        lineDir = mouseVec - RB.position;
	    float orig_dist = lineDir.magnitude;
	    float min_dist = System.Math.Min(orig_dist, System.Math.Min(maxDashLength, dashLength));
        lineDir.Normalize();
        lineDir *= min_dist;
        dashLineR.SetPosition(0, RB.position + new Vector2(0f,0.5f));
        dashLineR.SetPosition(1, RB.position + lineDir);
	    DrawDashRangeCirc();
        dashLength += 0.2f;
        dashLineR.enabled = true;
    }

    void ExecuteDash()
    {

        RaycastHit2D[] hits;

        Vector2 dashLine = dashLineR.GetPosition(1) - dashLineR.GetPosition(0);
        float max_dist = dashLine.magnitude;
        dashLine.Normalize();
        hits = Physics2D.RaycastAll(dashLineR.GetPosition(0), dashLine, max_dist, dashLayerMask);
        Debug.Log("detected " + hits.Length.ToString() + " hits");
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit2D hit = hits[i];
            hit.transform.gameObject.SendMessage("Death", SendMessageOptions.RequireReceiver);
        }
        spriteR.material.SetColor("_Color", Color.black);
        dashLength = 0f;
        RB.position = dashLineR.GetPosition(1);
        dashLineR.enabled = false;
        dashRangeR.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected Player Hit!");
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
            PlanDash();
            speed = 0;
        }
        if (Input.GetMouseButtonUp(0))
        {
            ExecuteDash();
        }
        
        newVel.Normalize(); newVel *= speed; RB.velocity = newVel; 
    }

}
