using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public AutoAnimation autoAnimation;

    

    private Queue<string> sentencesQueue;

    public bool convoChildrenOver = false;
    public bool cameraOff = false;

    void Start()
    {
        sentencesQueue = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        //Debug.Log("Starting conversation with " + dialogue.name);
        nameText.text = dialogue.name;


        sentencesQueue.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentencesQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentencesQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentencesQueue.Dequeue();
        //Debug.Log (sentence);
        //dialogueText.text = sentence;

        // We use this method to stop the animation if the player tryes to go to the next text while animating the previous one
        StopAllCoroutines();

        // We call the Corutine to show the text letter by letter
        StartCoroutine(TypeSentence(sentence));

    }

    // This is a Coroutine
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue ()
    {
        Debug.Log("I'm ending the dialogue!");
        animator.SetBool("IsOpen", false);
        if (convoChildrenOver)
        {
            autoAnimation.checkConvoFinished = true;
            cameraOff = true;
        }
    }
}
