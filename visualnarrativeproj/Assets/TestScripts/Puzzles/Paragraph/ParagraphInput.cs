using UnityEngine;
using TMPro;
using VRTK;

public class ParagraphInput : VRTK_InteractableObject
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
        Debug.Log("HENLO" + obj.tag);
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.9 && !ParagraphPuzzle.Instance.finished)
        {
            if (obj.tag == "Win")
            {
                TMP_ChatOutput.text = "Dear Chancellor Folt,\n\n" +
                "As the proud home of the country’s oldest and finest public university, the Town of Chapel Hill greatly values the long-established relationships with the University of North Carolina at Chapel Hill(UNC) that allow us to work together, as neighbors and community partners, to address important issues and be the outstanding college town that we all want.\n" +
                "Critical to the success of our collaboration has always been our shared commitment to being a safe, welcoming and inclusive place for everyone who lives, works, learns, plays and visits in Chapel Hill.\n" +
                "With these goals in mind, we are writing to reaffirm Chapel Hill’s earlier request for the expeditious and permanent relocation of the Silent Sam Confederate monument from its location in McCorkle Place to a more contextually appropriate place that is safer for public viewing.\n" +
                "We make this request for the following reasons:\n" +
                "1.Prominent placement of the Silent Sam monument at McCorkle Place in downtown Chapel Hill is an offense to the entire Chapel Hill community, including African - American students, faculty members, university employees, local residents, and business persons who call Chapel Hill home, as well as to returning alumni and the countless fans and tourists who visit our Town every year. To them and to us, Silent Sam and its roots in pro - slavery, pro - segregation ideology represent the antithesis of the high value that UNC and the Town of Chapel Hill place on being a welcoming and inclusive place for all.\n" +
                "2.Strong emotions surrounding Silent Sam have existed for many years, including escalating tensions and frequent clashes that have occurred this year.These emotions demonstrate the very clear and present danger to public safety that will continue to intensify if the statue is returned to McCorkle Place or another prominent outdoor campus location.\n" +
                "3. Downtown businesses and the Town’s reputation as one of the best small towns in the nation have suffered as a result of the tensions and outbreaks of violence.These impacts were outlined in a letter from the Chapel Hill-Carrboro Chamber of Commerce and Chapel Hill Downtown Partnership (August 30, 2018). Continued unrest will be increasingly detrimental to the vitality and vibrancy of downtown Chapel Hill that we have worked so hard together to achieve.\n" +
                "4. The financial and other resource costs to the University and the Town associated with the statue and these on-going events are placing an unsustainable strain on our mutual aid agreement for public safety that is vitally important to keep students and the entire community safe during downtown student celebrations and other events throughout the school year.\n\n" +
                "We appreciate your leadership in working with the UNC Board of Governors to open the door for UNC to explore alternatives for the Silent Sam monument and believe our request aligns with the objectives spelled out in their August 28th resolution.";
                ParagraphPuzzle.Instance.finished = true;
                obj.GetComponent<Renderer>().material.color = Color.green;
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }
}
