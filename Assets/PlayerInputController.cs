using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{
    [SerializeField] GhostController ghost;
    [SerializeField] UserController player;
    [SerializeField] BattleController battle;
    [SerializeField] Text battleText;
    public string oldText;
    public int defenseAmt = 2;
    string variableText;

    void Start()
    {
        oldText = battleText.text;
    }

    IEnumerator ChangeText(string newText)
    {
        battleText.text = newText;
        yield return new WaitForSeconds(3);
        if(player.health <= 0)
        {
            battleText.text = "You died. :)";
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Detective's Office");
        }
        if(ghost.health <= 0)
        {
            battleText.text = "You won! :)";
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Detective's Office");
        }
        battleText.text = oldText;
    }//END ChangeText

    IEnumerator ChangeText(string newText, int flag)
    {
        battleText.text = newText;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Detective's Office");
    }//END ChangeText

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            battle.ProcessBattle(1);
            if(battle.userAttack == 1 && battle.enemyAttack != 1)
            {
                variableText = "LMAO Get rekt kid. You rolled a 1 haha. You hit yourself for " + battle.userDamage + "\nEnemy rolled an attack of " + battle.enemyDamage + ".";
            }
            if(battle.userAttack != 1 && battle.enemyAttack == 1)
            {
                variableText = "Player rolled an attack of " + battle.userAttack + ".\nThe enemy rolled a 1. It hit itself for " + battle.enemyDamage + ".";
            }
            if(battle.userAttack == 1 && battle.enemyAttack == 1)
            {
                variableText = "You both rolled a 1. I can't believe it. You both hit yourselves. You hit yourself for " + battle.userDamage + " and the enemy hit themselves for " + battle.enemyDamage + ".";
            }
            variableText = "Player rolled an attack of " + battle.userAttack + ". You hit for " + battle.userDamage + ".\nEnemy rolled an attack of " + battle.enemyAttack + ". It hit for " + battle.enemyDamage + ".";
            StartCoroutine(ChangeText(variableText));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            battle.ProcessBattle(2);
            if(battle.userAttack == 1 && battle.enemyAttack != 1)
            {
                variableText = "LMAO Get rekt kid. You rolled a 1 haha. You hit yourself for " + battle.userDamage + "\nEnemy rolled an attack of " + battle.enemyDamage + ".";
            }
            if(battle.userAttack != 1 && battle.enemyAttack == 1)
            {
                variableText = "Player rolled an attack of " + battle.userAttack + ".\nThe enemy rolled a 1. It hit itself for " + battle.enemyDamage + ".";
            }
            if(battle.userAttack == 1 && battle.enemyAttack == 1)
            {
                variableText = "You both rolled a 1. I can't believe it. You both hit yourselves. You hit yourself for " + battle.userDamage + " and the enemy hit themselves for " + battle.enemyDamage + ".";
            }
            variableText = "Player rolled an attack of " + battle.userAttack + ". You hit for " + battle.userDamage + ".\nEnemy rolled an attack of " + battle.enemyAttack + ". It hit for " + battle.enemyDamage + ".";
            StartCoroutine(ChangeText(variableText));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            battle.ProcessBattle(3);
            StartCoroutine(ChangeText("You defended."));
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(ChangeText("You ran away.", 1));
        }
    }
}
