using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    // First set of objects
    public Transform [] spawnLocationSetOne;
    public GameObject[] spawnObjectSetOne;
    public GameObject[] spawnCloneObjectSetOne;

    // Second set of objects
    public Transform [] spawnLocationSetTwo;
    public GameObject[] spawnObjectSetTwo;
    public GameObject[] spawnCloneObjectSetTwo;

    // Controllers for when objects can spawn
    bool hasSetOneObjectsSpawned = false;
    bool hasSetTwoObjectsSpawned = false;

    int num_updates = 0;

    // spawn the first set of elements
    void spawnElementSetOne()
    {
        for( int i = 0; i < spawnObjectSetOne.Length; ++i )
        {
            spawnCloneObjectSetOne[i] = Instantiate(spawnObjectSetOne[i], spawnLocationSetOne[i].position,
                Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }

    // Spawn the second set of elements
    void spawnElementSetTwo()
    {
        for (int i = 0; i < spawnObjectSetTwo.Length; ++i)
        {
            spawnCloneObjectSetTwo[i] = Instantiate(spawnObjectSetTwo[i], spawnLocationSetTwo[i].position,
                Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }

	// Use this for initialization
	void Start ()
    {
        //spawnElementSetOne();
	}

    public void updateState()
    {
        // Spawn the first set of objects if they have not already been spawned
        if (num_updates == 0)
        {
            Debug.Log("init spawn");
            ++num_updates;
            spawnElementSetOne();
            hasSetOneObjectsSpawned = true;
        }

        // Destroy the first set of objects and spawn the second set of not already done and only if
        // the first set has been spawned
        // I think this is the last spawn, should spawn special objects for player to interact with on the statue
        // TODO Do we want it to destroy the previos set of spawning? -> currently doing just this 
        else if (num_updates == 1)
        {
            Debug.Log("2 key pressed");
            ++num_updates;
            foreach (GameObject objectToDestroy in spawnCloneObjectSetOne)
                Destroy(objectToDestroy);

            spawnElementSetTwo();
            hasSetTwoObjectsSpawned = true;
        }

        // Destroy the second set of objects, these are end game objects
        else if (num_updates == 2)
        {
            /*
            Debug.Log("3 key pressed");
            foreach (GameObject objectToDestroy in spawnCloneObjectSetTwo)
                Destroy(objectToDestroy);

            hasSetOneObjectsSpawned = false;
            hasSetTwoObjectsSpawned = false;
            */
        }
        else if (num_updates == 3)
        {
            // we should be done spawning
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        /*
        // Spawn the first set of objects if they have not already been spawned
        if (Input.GetKeyDown("[1]") && !hasSetOneObjectsSpawned)
        {
            Debug.Log("1 key pressed");
            spawnElementSetOne();
            hasSetOneObjectsSpawned = true;
        }

        // Destroy the first set of objects and spawn the second set of not already done and only if
        // the first set has been spawned
        if(Input.GetKeyDown("[2]") && hasSetOneObjectsSpawned && !hasSetTwoObjectsSpawned )
        {
            Debug.Log("2 key pressed");
            foreach ( GameObject objectToDestroy in spawnCloneObjectSetOne )
                Destroy( objectToDestroy );

            spawnElementSetTwo();
            hasSetTwoObjectsSpawned = true;
        }

        // Destroy the second set of objects and reset the spawning rules (testing only)
        if (Input.GetKeyDown("[3]") && hasSetOneObjectsSpawned && hasSetTwoObjectsSpawned)
        {
            Debug.Log("3 key pressed");
            foreach (GameObject objectToDestroy in spawnCloneObjectSetTwo)
                Destroy(objectToDestroy);

            hasSetOneObjectsSpawned = false;
            hasSetTwoObjectsSpawned = false;
        }
    */
    }
}
