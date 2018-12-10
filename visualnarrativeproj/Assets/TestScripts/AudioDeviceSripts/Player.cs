using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // current disk playing
    GameObject currentDisk;
    public bool hasDiskInserted = false;

    public string[] disk_names;

    Vector3 lastSnappedPosition;
    public GameObject DiskSpawner;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if ( hasDiskInserted && !currentDisk.GetComponent<Disk>().m_AudioSource.isPlaying)
            OnDiskExit();
    }

    // snaps the disk into position in front of the player and then starts the coroutine of the disk going into the player
    void SnapToPosition()
    {
        currentDisk.transform.position = currentDisk.GetComponent<Disk>().snapPosition;
        Debug.Log("Snapped to position: " + currentDisk.transform.position);
        StartCoroutine("MoveDiskIntoPlayer", 10.0f);
    }

    // moves the disk into the disk player and then starts the audio
    IEnumerator MoveDiskIntoPlayer(float duration)
    {
        while ( duration > 0.0f )
        {
            currentDisk.transform.position -= new Vector3(0.2f, 0.0f, 0.0f);
            Debug.Log("Moving into player: " + currentDisk.transform.position);
            duration -= 0.2f;
        }

        currentDisk.GetComponent<Disk>().StartAudio();
        yield return null;
    }

    // moves the disk into the disk player and then starts the audio
    IEnumerator MoveDiskOutOfPlayer(float duration)
    {
        Debug.Log("Exiting player");
        while (duration > 0.0f)
        {
            currentDisk.transform.position += new Vector3(0.2f, 0.0f, 0.0f);

            duration -= 0.2f;
        }

        // turn collision back on
        Physics.IgnoreCollision(GetComponent<Collider>(), currentDisk.GetComponent<Collider>(), false);
        currentDisk.GetComponent<Disk>().ResetState();
        yield return null;
    }

    // set some state when a player puts in a disk
    public bool OnDiskEnter(GameObject disk)
    {
        Debug.Log("disk has entered");
        // already have a disk insterted
        if (hasDiskInserted)
            return false;

        // We found our disk
        currentDisk = disk;
        hasDiskInserted = true; // <-- might cause problems depending on the ordering of the collision process
        Physics.IgnoreCollision(GetComponent<Collider>(), currentDisk.GetComponent<Collider>());

        // snap the disk into position and play animation of it entering the object
        SnapToPosition();
        return true;
    }

    // Spit out the disk using a coroutine
    public bool OnDiskExit()
    {
        if (!hasDiskInserted)
            return false;

        hasDiskInserted = false;
        //StartCoroutine("MoveDiskOutOfPlayer", 10.0f);
        lastSnappedPosition = currentDisk.GetComponent<Disk>().snapPosition;
        DiskSpawner.GetComponent<SpawnDisks>().DestroyDisk(currentDisk);
        DiskSpawner.GetComponent<SpawnDisks>().CreateDisk(lastSnappedPosition);
        return true;
    }
}
