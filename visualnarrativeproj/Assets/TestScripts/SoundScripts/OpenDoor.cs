using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OpenDoor : MonoBehaviour {

    private int canRotate;
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
        canRotate = 0;

        // Tracks a relative position so that it can act as a trigger to stop the doors from rotating
        pos = 0;

        directionVector = pivot.transform.up;

        someListener = new Action(startRotaion);

        EventManager.StartListening("rotate", startRotaion);
    }

    public void startRotaion()
    {
        canRotate = 1;
        EventManager.StopListening("rotate", startRotaion);
        Debug.Log("start rotation was triggered!!!");
    }

    public void close()
    {
        canRotate = 2;
    }

    // Update is called once per frame
    void Update () {

        // Rotate about a hinge point: open
        if( canRotate == 1 )
        {
            transform.RotateAround(pivot.transform.position, directionVector, direction * speed * Time.deltaTime);
            ++pos;

            if( pos == stop )
            {
                canRotate = 0;
            }
        }
        // Rotate about a hinge point: close
        else if ( canRotate == 2 )
        {
            transform.RotateAround(pivot.transform.position, directionVector, (-1 * direction) * speed * Time.deltaTime);
            --pos;

            if (pos == 0)
            {
                canRotate = 0;
            }
        }
	}
}
