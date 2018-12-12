using System;
using UnityEngine;

public class MistakesPuzzle : Singleton<MistakesPuzzle>
{
    public Boolean finished = false;
    public GameObject exhibit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (!exhibit.GetComponent<S_Exhibit>().getIsActive())
        //    return;
    }
}
