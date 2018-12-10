using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDisks : MonoBehaviour {

    public GameObject diskToSpawn;
    public GameObject disk;

    // Use this for initialization
    void Start () {
        disk = Instantiate(diskToSpawn, diskToSpawn.transform.position,
                Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    public void DestroyDisk( GameObject disk )
    {
        Destroy(disk);
    }

    public void CreateDisk(Vector3 pos)
    {
        disk = Instantiate(diskToSpawn, pos,
                Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
