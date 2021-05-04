using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraScript : MonoBehaviour
{
    public Text text1; 
    // Start is called before the first frame update
    void Start()
    {
        
        text1.text = "Don't get hit and survive The Apocalypse!\n WASD for movement \n Click for dash";       
    }
 
    public void setText(string t){
        text1.text = t;
	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
