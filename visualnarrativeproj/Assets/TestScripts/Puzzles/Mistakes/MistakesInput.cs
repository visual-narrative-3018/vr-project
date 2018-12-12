using UnityEngine;
using TMPro;
using System;
using VRTK;

public class MistakesInput : VRTK_InteractableObject
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
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9 && !MistakesPuzzle.Instance.finished)
        {
            if (obj.tag == "Win")
            {
                TMP_ChatOutput.text = "On June 2, 1913, at the monument’s public dedication, Confederate war veteran Julian S. Carr said, “The present generation, I am persuaded, scarcely takes note of what the Confederate soldier meant to the welfare of the Anglo Saxon race. . . . if every State of the South had done what North Carolina did . . . the political geography of America would have been re-written.” He then told this story: “less than ninety days perhaps after my return from Appomattox, I horse-whipped a negro wench until her skirts hung in shreds, because upon the streets of this quiet village she had publicly insulted and maligned a Southern lady, and then rushed for protection to these University buildings.”\n" +
                "From the moment of its dedication, Carr’s racist words cemented the monument as a symbol of white supremacy, violence and indignity. Even today, UNC’s website acknowledges that many see Silent Sam as “a glorification of the Confederacy and thus a tacit defense of slavery.” To many in our community, the armed soldier expresses the idea that some in our community are not equal.\n" +
                "This disparaging and marginalizing symbol has no place at the core of an inclusive learning environment. We also believe that the message it sends undercuts the University’s mission “to teach a diverse community of undergraduate, graduate, and professional students to become the next generation of leaders.” We are particularly concerned about the statue’s symbolism given the Board of Governors’ recent ban on representation or counsel by the Center for Civil Rights\n" +
                "Maintaining this monument undercuts the value of equality protected by North Carolina law and the United States Constitution.We note that federal law obliges the University to provide an inclusive learning environment free of racial hostility.Out of concern for public safety, Chapel Hill Mayor Pam Hemminger called for the monument to be moved, and North Carolina Governor Roy Cooper advised UNC that North Carolina law permits the University to remove or relocate the statue.  ";
                MistakesPuzzle.Instance.finished = true;
                obj.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}