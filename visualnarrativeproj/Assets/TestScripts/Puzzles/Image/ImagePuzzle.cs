using UnityEngine;
using System;
using System.Collections;
using VRTK;

public class ImagePuzzle : VRTK_InteractableObject
{
    public GameObject obj;
    private int index = -1;

    void Start()
    {
        //
    }


    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        if (SwitchPlaces.Instance.doneMoving)
        {
            if (Array.IndexOf(SwitchPlaces.Instance.orderedArray, obj) > -1)
            {
                index = Array.IndexOf(SwitchPlaces.Instance.orderedArray, obj);
                if (SwitchPlaces.Instance.chosenIndex != -1)
                {
                    SwitchPlaces.Instance.orderedArray[SwitchPlaces.Instance.chosenIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (index != SwitchPlaces.Instance.chosenIndex)
                {
                    SwitchPlaces.Instance.orderedArray[index].transform.GetChild(0).GetComponent<SpriteRenderer>().color = SwitchPlaces.Instance.color;
                    SwitchPlaces.Instance.chosenIndex = index;
                }
                else
                {
                    SwitchPlaces.Instance.chosenIndex = -1;
                }
            }
        }
    }
 
    public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
    {
        base.StopUsing(previousUsingObject, resetUsingObjectState);
        SwitchPlaces.Instance.orderedArray[Array.IndexOf(SwitchPlaces.Instance.orderedArray, obj)].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }
    
    protected override void Update()
    {
        base.Update();
        if (SwitchPlaces.Instance.doneMoving && SwitchPlaces.Instance.chosenIndex >= 0)
        {
            Debug.Log("DONE MOVING, chosenIndex: " + SwitchPlaces.Instance.chosenIndex + " total: " + SwitchPlaces.Instance.total);
            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.9 && SwitchPlaces.Instance.chosenIndex < SwitchPlaces.Instance.total - 1)
            {
                Debug.Log("TRIGGERING RIGHT");
                StartCoroutine(SwitchPlaces.Instance.SwapPositions(SwitchPlaces.Instance.chosenIndex++, SwitchPlaces.Instance.chosenIndex));
            }

            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9 && SwitchPlaces.Instance.chosenIndex > 0)
            {
                Debug.Log("TRIGGERING LEFT");
                StartCoroutine(SwitchPlaces.Instance.SwapPositions(SwitchPlaces.Instance.chosenIndex--, SwitchPlaces.Instance.chosenIndex));
            }
        }
    }
}