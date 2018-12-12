using UnityEngine;
using TMPro;
using VRTK;

public class AlphabetInput : VRTK_InteractableObject
{
    public TMP_Text TMP_ChatOutput;
    public GameObject obj;

    void Start()
    {
    }


    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
    {
        base.StopUsing(previousUsingObject, resetUsingObjectState);
    }

    protected override void Update()
    {
        base.Update();
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9 && !AlphabetPuzzle.Instance.finished)
        {
            if (obj.tag == "Win")
            {
                TMP_ChatOutput.text = "Mar. 19, 1909.\nDear Mrs.Kenan:\n            " +
                "Last year you wrote me about the resolution of the Daughters of the Confederacy concerning a monument to be placed on the University grounds, this monument to be in honor of the sons of the University who entered the Confederate Army.\n                 " +
                "I hope very much that this laudable purpose can be carried out. You know that more than one thousand of the alumni entered the Confederate service and surely something should be done to perpetuate the patriotism and heroism of these noble sons of the University." +
                "I think I suggested at the time a memorial gateway at one of the entrances to the campus. I enclose a design of such a gateway which was drawn at my request by our architect. This is very similar to the gateway at the University of Wisconsin. I understand from the" +
                " architect that the cost would be something like $1500. I believe that an appeal from the ladies of the North Carolina Division would raise this sum without difficulty. For instance, such a man as General Julian S. Carr would probably contribute generously to it.\n" +
                "This gateway would be placed at the west or principal entrance to the campus." +
                "Of course, this is merely a suggestion on my part and if it does not meet with your approval, let it pass. ";
                AlphabetPuzzle.Instance.finished = true;
                obj.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
