using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    private AudioSource combatLoop;
    private float musicSlowDownFactor = 0.5f;
    // Use this for initialization

    public SoundManager(GameObject go)
    {
        combatLoop = go.AddComponent<AudioSource>();
        combatLoop.clip = Resources.Load("Dash_cats_synthwave") as AudioClip;
        combatLoop.loop = true;
        combatLoop.volume = 0.2f;
        
    }

    public void startCombatLoop()
    {
        combatLoop.Play(0);
    }

    public void slowDownCombatLoop()
    { 
        combatLoop.pitch *= musicSlowDownFactor;
        combatLoop.volume = 0.09f;
    }

    public void defaultCombatLoop()
    {
        combatLoop.pitch *= 1/musicSlowDownFactor;
        combatLoop.volume = 0.2f;
    }
}
