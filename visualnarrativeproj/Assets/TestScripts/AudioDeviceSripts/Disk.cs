using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VRTK;

public class Disk : MonoBehaviour {

    // audio that plays when insterted into the player
    public AudioClip m_clip;
    public AudioSource m_AudioSource;

    public float audioFadeRate;
    public float audioInitialVolume;
    // the position the disk snaps to upon entering the disk player
    public Vector3 snapPosition;

    bool isPlayerHolding = false;
    bool canPlayerInteractWith = true;

    GameObject player;
    

    // Use this for initialization
    void Start () {
        m_AudioSource.clip = m_clip;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public AudioSource getAudio()
    {
        return m_AudioSource;
    }
    
    // start playing the audio
    public void playAudio()
    {
        m_AudioSource.volume = audioInitialVolume;
        m_AudioSource.Play();
    }

    // Clamp the values - probably a little for efficient than calling the Math Library clamp
    float Clamp( float value, float lower, float upper )
    {
        if (value < lower)
            return lower;
        else if (value > upper)
            return upper;
        else
            return value;
    }

    // Fade out the audio 
    IEnumerator FadeAudioOut()
    {
        while(m_AudioSource.volume > 0.0f )
        {
            if (!m_AudioSource.isPlaying)
                break;

            m_AudioSource.volume = Clamp(m_AudioSource.volume - audioFadeRate, 0.0f, 1.0f);
        }
        m_AudioSource.Stop();
        yield return null;
    }

    // Fade in the audio 
    IEnumerator FadeAudioIn()
    {
        while (m_AudioSource.volume < 1.0f)
        {
            if (!m_AudioSource.isPlaying)
                break;

            m_AudioSource.volume = Clamp(m_AudioSource.volume + audioFadeRate, 0.0f, 1.0f);
        }
        m_AudioSource.Stop();
        yield return null;
    }

    // called when the player enters the ranger of hearing - don't think I will need this
    public void StartAudioBasedOnPlayerPosition()
    {
    }

    public void StartAudio()
    {
        if ( !m_AudioSource.isPlaying )
        {
            m_AudioSource.Play();
        }
    }

    // Stop the current audio track
    public void StopAudio()
    {
        if(m_AudioSource.isPlaying )
        {
            // change this to a fade coroutine
            StartCoroutine("FadeAudioOut");
        }
    }

    // called when the disk is ejected from the audio player
    public void ResetState()
    {
        Debug.Log("Reset called");
        GetComponent<VRTK_InteractableObject>().enabled = true;
        canPlayerInteractWith = true;
        m_AudioSource.volume = audioInitialVolume;
    }

    // Check if the disk collided with the player or audio player
    private void OnCollisionEnter(Collision collision)
    {
        /*
        if( collision.gameObject.name.Equals( player.name ) )
        {
            // it is the player
            // audio is probably in the disk player - don't want the player to grab the disk
            if (!canPlayerInteractWith)
                return;
            // player is already holding it - no need to update anything
            else if (isPlayerHolding)
                return;
            else
            {
                isPlayerHolding = true;
                // do I need to update antything else?
            }
        }
        */
        if ( collision.gameObject.name.Equals( "AudioPlayer" ) )
        {
            // player is trying to insert the disk into the disk player
            isPlayerHolding = false;
            canPlayerInteractWith = false;
            //GetComponent<VRTK_InteractableObject>().
            GetComponent<VRTK_InteractableObject>().enabled = false; ;
           Debug.Log("Collided with AudioPlayer");

            // a disk is already playing in the disk player
            if (!collision.gameObject.GetComponent<Player>().OnDiskEnter(gameObject))
            {
                GetComponent<VRTK_InteractableObject>().enabled = true;
                return;
            }

            
            //Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider); // turn off collision between player and disk
        }

        Debug.Log("Collided with " + collision.gameObject.name);
    }
}
