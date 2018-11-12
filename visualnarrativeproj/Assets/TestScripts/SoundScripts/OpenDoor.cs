using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenDoor : MonoBehaviour {

    private bool canRotate;
    private float pos;
    public int direction;

    public GameObject parent;

    public GameObject pivot;

    private readonly float speed = 50;
    private readonly int stop = 100;
    private Vector3 directionVector;

    private Action someListener;

    // Use this for initialization
    void Start () {

        // Let's the update method know to start/stop rotation
        canRotate = false;

        // Tracks a relative position so that it can act as a trigger to stop the doors from rotating
        pos = 0;

        directionVector = pivot.transform.up;

        someListener = new Action(startRotaion);

        EventManager.StartListening("rotate", startRotaion);
    }

    void startRotaion()
    {
        canRotate = true;
        EventManager.StopListening("rotate", startRotaion);
        Debug.Log("start rotation was triggered!!!");
    }

    // Update is called once per frame
    void Update () {

        // Rotate about a hinge point
        if( canRotate )
        {
            transform.RotateAround(pivot.transform.position, directionVector, direction * speed * Time.deltaTime);
            pos++;

            if( pos == stop )
            {
                canRotate = false;
            }
        }
	}
}
