using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceRollingController : MonoBehaviour
{
    public int value = 19;
    [SerializeField] GameObject[] diceSides = new GameObject[20];
    [SerializeField] Animator animator;
    [SerializeField] DiceAnimationController diceAnimationController;

    public bool rolling = false;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            diceSides[i].SetActive(false);
        }//This turns off the dice objects

        diceSides[19].SetActive(true);
        animator.enabled = false; // Make sure that the dice is still there as an object
    }//END Start()

    /* Check for coroutine that is already running to make sure that there aren't two at a time. */

    IEnumerator PlayAnimation()
    {
        diceSides[19].SetActive(true);
        diceAnimationController.ChangeAnimationState("DiceRoll");
        yield return new WaitForSeconds(2);
        diceAnimationController.animator.enabled = false;
        int randomValue = Random.Range(0, 19);
        diceSides[randomValue].SetActive(true);
        value = randomValue;
        rolling = false;
    }

    public void DiceRoll()
    {
        if(rolling)
        {
            return;
        }//END if
        rolling = true;
        diceSides[value].SetActive(false);
        StartCoroutine(PlayAnimation());
        //PlayAnimation(); //Start coroutine
    }//END DiceRoll
}
