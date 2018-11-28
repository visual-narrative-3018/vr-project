using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Exhibit : MonoBehaviour {

    // the object this class is attached to
    public GameObject exhibit;
    // parent that holds the list of exhibits
    public GameObject parent;
    // whether or not the exhibit is active
    bool isActive;
    // unique id for this exhibit
    public string id;

    // display active material
    public Material activeMaterial;
    // disply inanctive material
    public Material inactiveMaterial;
    // disply inanctive material
    public Material completedMaterial;
    // current material
    int currentMat;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool getIsActive()
    {
        return this.isActive;
    }

    public void activate()
    {
        setIsActive(true);
        setMaterial(1);
    }

    public void deactivate()
    {
        setIsActive(false);
        setMaterial(0);
    }

    void setIsActive( bool isActive )
    {
        this.isActive = isActive;
    }

    void setMaterial( int mat )
    {
        currentMat = mat;

        // 0 means exhibit is active
        if ( mat == 0 )
        {
            exhibit.GetComponent<Renderer>().material = activeMaterial;
        }
        // 1 means the exhibit is inactive
        else if ( mat == 1 )
        {
            exhibit.GetComponent<Renderer>().material = inactiveMaterial;
        }
        // 2 means the exhibit is inactive
        else if (mat == 2)
        {
            exhibit.GetComponent<Renderer>().material = completedMaterial;
        }
        else
        {
            // nothing to see here
        }
    }

    // exhibit is notifying the script that is was solved: set the exhibit to its completed state
    public void notify()
    {
        setIsActive(false);
        setMaterial(2);

        notifyParent();
    }

    // notify the room that this exhibt has been solved
    public void notifyParent()
    {
        parent.GetComponent<S_ExhibitRoom>().notify();
    }

    // Probably the way this is going to work, is that when an exhibit is completed, the game object notifies this script, which
    // in turn notifies the ExhibitRoom GameObject. 


}
