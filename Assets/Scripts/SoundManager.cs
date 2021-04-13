using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    private AudioSource combatLoop;
    private UnityEngine.Audio.AudioMixerGroup pitchBendGroup;
    // Use this for initialization

    public SoundManager(GameObject go)
    {
        combatLoop = go.AddComponent<AudioSource>();
        combatLoop.clip = Resources.Load("Dash_cats_synthwave") as AudioClip;
        pitchBendGroup = Resources.Load<UnityEngine.Audio.AudioMixerGroup>("Combat Audio Mixer");
        combatLoop.outputAudioMixerGroup = pitchBendGroup;
        combatLoop.loop = true;
        combatLoop.volume = 0.2f;
    }

    public void startCombatLoop()
    {
        combatLoop.Play(0);
    }

    public void slowDownCombatLoop()
    {
        Debug.Log("dash planning recieved");
        combatLoop.pitch = 0.5f;
        combatLoop.volume = 0.09f;
    }

    public void defaultCombatLoop()
    {
        combatLoop.pitch = 1f;
        combatLoop.volume = 0.2f;
    }
}
