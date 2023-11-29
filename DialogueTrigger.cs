using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    [SerializeField] DialogueController dialogueController;

    public void TriggerDialogue()
    {
        dialogueController.StartDialogue(dialogue);
    }//END TriggerDialogue()
}
