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
	
	// Update is called once per frame
	void Update ()
    {
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
    }
}
