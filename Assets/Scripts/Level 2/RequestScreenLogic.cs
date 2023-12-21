using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class RequestScreenLogic : MonoBehaviour
{
    public Animator animator;
    public GameObject Balloon;
    public GameObject Convetti;

    public GameObject kid1Cheering;
    public GameObject kid1Asking;

    public GameObject kid2Cheering;
    public GameObject kid2Asking;

    public GameObject kid3Cheering;
    public GameObject kid3Asking;

    public GameObject kid4Cheering;
    public GameObject kid4Asking;

    public GameObject kid5Cheering;
    public GameObject kid5Asking;
    int number;
    int kidNumber;

    GameObject[] asking;
    GameObject[] cheering;



    // Start is called before the first frame update
    void Start()
    {
        asking = new GameObject[] { kid1Asking, kid2Asking, kid3Asking, kid4Asking, kid5Asking};
        cheering = new GameObject[] { kid1Cheering, kid2Cheering, kid3Cheering, kid4Cheering, kid5Cheering};
        number = 0;
        kidNumber = 1;
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

        cheering[kidNumber].SetActive(false);
        kidNumber = Random.Range(0, 5);

        asking[kidNumber].SetActive(true);
    }

    public void KidCheering()
    {        
        Balloon.SetActive(false);
        Convetti.SetActive(true);

        asking[kidNumber].SetActive(false);
        cheering[kidNumber].SetActive(true);
        
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
