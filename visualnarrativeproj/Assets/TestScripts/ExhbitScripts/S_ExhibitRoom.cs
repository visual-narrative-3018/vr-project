using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class S_ExhibitRoom : MonoBehaviour {

    int currentActiveExhbit;

    public string id;

    // Number of Exhibits in this room
    public int numberOfExhibits;
    // make sure that numberOfExhbits and the size of this array match
    public GameObject[] exhibits;

    public GameObject door;
    public GameObject spawner;

    // Use this for initialization
    void Start () {
        currentActiveExhbit = 0;

        // de-activate all but the first exhibit
        if ( exhibits.Length >= 1 )
        {
            exhibits[0].GetComponent<S_Exhibit>().activate();
        }
        for( int i = 1; i < exhibits.Length; ++i )
        {
            exhibits[0].GetComponent<S_Exhibit>().deactivate();
        }
    }

    void updateActiveExhibit()
    {
        ++currentActiveExhbit;

        // all exhbitis have been completed - woo!!!
        if( currentActiveExhbit >= exhibits.Length )
        {
            door.GetComponent<OpenDoor>().startRotaion();
            spawner.GetComponent<Spawner>().updateState();
        }

        // activate the next exhibit
        exhibits[currentActiveExhbit].GetComponent<S_Exhibit>().activate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void notify()
    {
        updateActiveExhibit();
    }

    // collistion detection for when the player enters the room -> shut the door
    void OnTriggerEnter( Collider collider )
    {
        if ( collider.gameObject.name == "player" )
        {
            door.GetComponent<OpenDoor>().close();
        }
    }

}
