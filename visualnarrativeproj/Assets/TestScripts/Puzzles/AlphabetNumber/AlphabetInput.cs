using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class AlphabetInput : MonoBehaviour
{


    public TMP_InputField TMP_ChatInput;

    public TMP_Text TMP_ChatOutput;
    
    void OnEnable()
    {
        TMP_ChatInput.onSubmit.AddListener(AddToChatOutput);

    }

    void OnDisable()
    {
        TMP_ChatInput.onSubmit.RemoveListener(AddToChatOutput);
    }


    void AddToChatOutput(string newText)
    {
        string nonRichText = Regex.Replace(TMP_ChatInput.text.ToLower(), "<.*?>", string.Empty);
        if (TMP_ChatInput.text.ToLower() == "honor" ||
            nonRichText == "honor")
        {
            // Clear Input Field
            TMP_ChatInput.text = "SOLVED!";
            TMP_ChatOutput.text = "Mar. 19, 1909.\nDear Mrs.Kenan:\n            " +
                "Last year you wrote me about the resolution of the Daughters of the Confederacy concerning a monument to be placed on the University grounds, this monument to be in honor of the sons of the University who entered the Confederate Army.\n                 " +
                "I hope very much that this laudable purpose can be carried out. You know that more than one thousand of the alumni entered the Confederate service and surely something should be done to perpetuate the patriotism and heroism of these noble sons of the University." +
                "I think I suggested at the time a memorial gateway at one of the entrances to the campus. I enclose a design of such a gateway which was drawn at my request by our architect. This is very similar to the gateway at the University of Wisconsin. I understand from the" +
                " architect that the cost would be something like $1500. I believe that an appeal from the ladies of the North Carolina Division would raise this sum without difficulty. For instance, such a man as General Julian S. Carr would probably contribute generously to it.\n" +
                "This gateway would be placed at the west or principal entrance to the campus." +
                "Of course, this is merely a suggestion on my part and if it does not meet with your approval, let it pass. ";
            TMP_ChatInput.enabled = false;
        } else
        {
            TMP_ChatInput.text = "<color=\"red\">" + TMP_ChatInput.text + "</color>";
        }

        TMP_ChatInput.ActivateInputField();

    }

}
