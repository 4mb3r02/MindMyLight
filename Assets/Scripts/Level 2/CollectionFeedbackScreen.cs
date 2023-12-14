using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CollectionFeedbackScreen : MonoBehaviour
{
    public Animator animator;
    public GameObject Balloon;
    public GameObject Convetti;

    public GameObject cheering;
    public GameObject asking;
    int number;

    // Start is called before the first frame update
    void Start()
    {
        number = 0;
        //MoveScreenUp();
        ////KidAskBalloon();
        //KidCheering();
        ////MoveScreenDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //if button pressed variable ++ and onto the switch case
            number++;
            switch (number)
            {
                // number++;
                case 1:
                    KidAskBalloon();
                    MoveScreenUp();
                    break;

                case 2:
                    KidCheering();
                    break;

                case 3:
                    MoveScreenDown();
                    number = 0;
                    break;
            }
        }
        
    }
    public void KidAskBalloon()
    {
        Convetti.SetActive(false);
        Balloon.SetActive(true);

        cheering.SetActive(false);
        asking.SetActive(true);
    }

    public void KidCheering()
    {        
        Balloon.SetActive(false);
        Convetti.SetActive(true);

        asking.SetActive(false);
        cheering.SetActive(true);
        
    }

    public void MoveScreenDown()
    {
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
    }

    public void MoveScreenUp()
    {
        animator.SetBool("Close", false);
        animator.SetBool("Open", true);
    }
}
