using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Audio : MonoBehaviour {

    public AudioClip m_clip;
    public AudioSource m_AudioSource;

    // play music
    bool m_Play;
    // detect toggle
    bool m_toggle;
    // detect if event has triggered
    bool hasEventTriggered;
	// Use this for initialization
	void Start () {
        m_AudioSource.clip = m_clip;
        //m_AudioSource = GetComponent<AudioSource>();
        m_Play = true;
        //m_toggle = false;
        Debug.Log("Audio source is playing");
        m_AudioSource.Play();

        hasEventTriggered = false;

    }
	
	// Update is called once per frame
	void Update () {
        if( !m_AudioSource.isPlaying && !hasEventTriggered)
        {
            Debug.Log("Audio source has stopped playing");
            hasEventTriggered = true;
            EventManager.TriggerEvent("rotate");
            //EventManager.TriggerEvent("mainroomLeadingLights");
            Debug.Log("track ended! and triggered events");
        }
	}
}
