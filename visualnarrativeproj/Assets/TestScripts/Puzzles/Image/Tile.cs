using UnityEngine;
using System;
using VRTK;

public class Tile : VRTK_InteractableObject
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
        if (ImagePuzzle.Instance.doneMoving)
        {
            if (Array.IndexOf(ImagePuzzle.Instance.orderedArray, obj) > -1)
            {
                index = Array.IndexOf(ImagePuzzle.Instance.orderedArray, obj);
                if (ImagePuzzle.Instance.chosenIndex != -1)
                {
                    ImagePuzzle.Instance.orderedArray[ImagePuzzle.Instance.chosenIndex].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
                }
                if (index != ImagePuzzle.Instance.chosenIndex)
                {
                    ImagePuzzle.Instance.orderedArray[index].transform.GetChild(0).GetComponent<SpriteRenderer>().color = ImagePuzzle.Instance.color;
                    ImagePuzzle.Instance.chosenIndex = index;
                }
                else
                {
                    ImagePuzzle.Instance.chosenIndex = -1;
                }
            }
        }
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
    {
        base.StopUsing(previousUsingObject, resetUsingObjectState);
        ImagePuzzle.Instance.orderedArray[Array.IndexOf(ImagePuzzle.Instance.orderedArray, obj)].transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
    }

    protected override void Update()
    {
        base.Update();
        if (ImagePuzzle.Instance.doneMoving && ImagePuzzle.Instance.chosenIndex >= 0)
        {
            if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9 && ImagePuzzle.Instance.chosenIndex < ImagePuzzle.Instance.total - 1)
            {
                StartCoroutine(ImagePuzzle.Instance.SwapPositions(ImagePuzzle.Instance.chosenIndex++, ImagePuzzle.Instance.chosenIndex));
            }

            if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.9 && ImagePuzzle.Instance.chosenIndex > 0)
            {
                StartCoroutine(ImagePuzzle.Instance.SwapPositions(ImagePuzzle.Instance.chosenIndex--, ImagePuzzle.Instance.chosenIndex));
            }
        }
    }
}