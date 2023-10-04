using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceRollingController : MonoBehaviour
{
    [SerializeField] int value = 19;
    [SerializeField] GameObject[] diceSides = new GameObject[20];
    [SerializeField] Animator animator;
    DiceAnimationController diceAnimationController;

    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            diceSides[i].SetActive(false);
        }//This turns off the dice objects

        diceSides[19].SetActive(true);
        animator.enabled = false; // Make sure that the dice is still there as an object
        diceAnimationController = GetComponent<DiceAnimationController>();
    }//END Start()

    IEnumerator PlayAnimation()
    {
        diceSides[19].SetActive(true);
        diceAnimationController.ChangeAnimationState("Dice Roll");
        yield return new WaitForSeconds(2);
        diceAnimationController.animator.enabled = false;
    }

    public void DiceRoll()
    {
        diceSides[value].SetActive(false);
        PlayAnimation();
        int randomValue = Random.Range(0, 19);
        diceSides[randomValue].SetActive(true);
        value = randomValue;
    }//END DiceRoll
}
