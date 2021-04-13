using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    private AudioSource combatLoop;
    private UnityEngine.Audio.AudioMixerGroup pitchBendGroup;
    private AudioSource zawarudo;
    // Use this for initialization

    public SoundManager(GameObject go)
    {
        combatLoop = go.AddComponent<AudioSource>();
        combatLoop.clip = Resources.Load("Dash_cats_synthwave") as AudioClip;
        pitchBendGroup = Resources.Load<UnityEngine.Audio.AudioMixerGroup>("Combat Audio Mixer");
        combatLoop.outputAudioMixerGroup = pitchBendGroup;
        combatLoop.loop = true;
        combatLoop.volume = 0.2f;
        zawarudo = go.AddComponent<AudioSource>();
        zawarudo.clip = Resources.Load("Za Warudo Sound Effect") as AudioClip;
        zawarudo.pitch = 1.5f;
        zawarudo.volume = 0.2f;
    }

    public void startCombatLoop()
    {
        combatLoop.Play(0);
    }

    public void slowDownCombatLoop()
    {
        zawarudo.Play(0);
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
