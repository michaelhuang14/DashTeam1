using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    private AudioSource combatLoop;
    private float musicSlowDownFactor = 0.9f;
    private AudioLowPassFilter filt;
    private float fac;
    private float slowFac;
    private int slow;
    // Use this for initialization

    public SoundManager(GameObject go)
    {
        combatLoop = go.AddComponent<AudioSource>();
        combatLoop.clip = Resources.Load("Dash_cats_synthwave") as AudioClip;
        combatLoop.loop = true;
        combatLoop.volume = 0.2f;
        filt = Camera.main.GetComponent<AudioLowPassFilter>();
        filt.cutoffFrequency = 22000;
        fac = combatLoop.pitch;
        slowFac = combatLoop.pitch * musicSlowDownFactor;
    }

    public void startCombatLoop()
    {
        combatLoop.Play(0);
    }

    public void spin()
    {
        if (slow == 1)
        {
            // combatLoop.pitch = Mathf.Lerp(combatLoop.pitch, slowFac, Time.deltaTime);
            // combatLoop.volume = Mathf.Lerp(combatLoop.volume, 0.01f, Time.deltaTime);
            // filt.cutoffFrequency = Mathf.Lerp(filt.cutoffFrequency, 3000, Time.deltaTime);
            combatLoop.pitch -= 0.01f;
            // combatLoop.volume -= 0.001f;
            filt.cutoffFrequency -= 950;
            if (combatLoop.pitch < slowFac || combatLoop.volume < 0.01f || filt.cutoffFrequency < 3000)
            {
                combatLoop.pitch = slowFac;
                // combatLoop.volume = 0.09f;
                filt.cutoffFrequency = 3000;
                slow = 0;
            }   
        } 
        else if (slow == -1)
        {
            // combatLoop.pitch = Mathf.Lerp(combatLoop.pitch, fac, Time.deltaTime);
            // combatLoop.volume = Mathf.Lerp(combatLoop.volume, 0.02f, Time.deltaTime);
            // filt.cutoffFrequency = Mathf.Lerp(filt.cutoffFrequency, 22000, Time.deltaTime);
            combatLoop.pitch += 0.01f;
            // combatLoop.volume += 0.001f;
            filt.cutoffFrequency += 950;
            if (combatLoop.pitch > fac || combatLoop.volume > 0.2f || filt.cutoffFrequency > 22000)
            {
                combatLoop.pitch = fac;
                // combatLoop.volume = 0.2f;
                filt.cutoffFrequency = 22000;
                slow = 0;
            }
        }
    }

    public void slowDownCombatLoop()
    {
        slow = 1;
        // combatLoop.pitch *= musicSlowDownFactor;
        // combatLoop.volume = 0.09f;
    }

    public void defaultCombatLoop()
    {
        slow = -1;
        // combatLoop.pitch *= 1 / musicSlowDownFactor;
        // combatLoop.volume = 0.2f;
    }
}