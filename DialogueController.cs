using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public Queue<string> sentences;
    [SerializeField] Text dialogueText;
    [SerializeField] Text dialogueName;
    public GameObject dialogueBox;

    void Start()
    {
        dialogueBox.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        dialogueBox.SetActive(true);
        dialogueName.text = dialogue.name;

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }//END foreach

        DisplayNextSentence();
    }//END StartDialogue

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }//END DisplayNextSentence

    void EndDialogue()
    {
        dialogueBox.SetActive(false);
    }//END EndDialogue()
}
