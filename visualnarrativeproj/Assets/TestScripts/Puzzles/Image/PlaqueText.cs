using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueText : MonoBehaviour {

    public GameObject obj;

	// Use this for initialization
	void Start () {
        //MeshFilter lettersMeshFilter = obj.GetComponent<MeshFilter>();
        //DestroyImmediate(lettersMeshFilter);
        TextMesh t = obj.AddComponent<TextMesh>();
        t.text = "new text set";
        t.fontSize = 30;
        t.transform.localEulerAngles += new Vector3(90, 0, 0);
        t.transform.localPosition += new Vector3(56f, 3f, 40f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
