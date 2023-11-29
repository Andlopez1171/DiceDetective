using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [SerializeField] GhostController ghost;
    [SerializeField] UserController player;
    [SerializeField] diceRollingController roll;
    [SerializeField] ParticleSystem fireballs;
    [SerializeField] ParticleSystem stink;
    [SerializeField] ParticleSystem check;
    [SerializeField] PlayerInputController main;
    [SerializeField] AudioSource audio1;
    [SerializeField] AudioSource audio2;

    ParticleSystem[] magicEffects = new ParticleSystem[3];
    AudioSource[] randomSounds = new AudioSource[2];

    public int userAttack;
    public int enemyAttack;
    public int userDamage;
    public int enemyDamage;
    public int attack;
    public string finalText;

    void Start()
    {
        magicEffects[0] = fireballs;
        magicEffects[1] = stink;
        magicEffects[2] = check;
        randomSounds[0] = audio1;
        randomSounds[1] = audio2;
    }//END Start

    public IEnumerator ProcessBattle(int option)
    {
        roll.DiceRoll();
        yield return new WaitUntil(() => !roll.rolling);
        userAttack = player.OnPlayerTurn(roll.value + 1);
        enemyAttack = ghost.OnEnemyTurn();
        finalText = "You rolled an attack of: " + userAttack + "\nThe enemy rolled an attack of: " + enemyAttack;
        StartCoroutine(main.ChangeText(finalText, 2));
        yield return new WaitUntil(() => !main.textChanging);

        if(userAttack == 1 && option != 3)
        {
            userDamage = Random.Range(1, 6);
            player.health = player.health - userDamage;
            finalText = "Critical Miss! You hit yourself for " + userDamage + "HPP points due to your miss!";
            StartCoroutine(main.ChangeText(finalText, 2));
            yield return new WaitUntil(() => !main.textChanging);
        }//END if
        else if(userAttack == 20 && option != 3)
        {
            roll.DiceRoll();
            yield return new WaitUntil(() => !roll.rolling);
            userDamage = Random.Range(1, 20);
            ghost.health = ghost.health - userDamage;
            finalText = "Critical Hit! You hit the enemy for " + userDamage;
            StartCoroutine(main.ChangeText(finalText, 2));
            yield return new WaitUntil(() => !main.textChanging);
        }//END else if
        else if(option != 3)
        {
            if(userAttack >= ghost.defense)
            {
                if(option == 1)
                {
                    userDamage = Random.Range(1, 6);
                    ghost.health = ghost.health - userDamage;
                    finalText = "You hit the enemy for: " + userDamage;
                    StartCoroutine(main.ChangeText(finalText, 2));
                    yield return new WaitUntil(() => !main.textChanging);
                }//END if
                else if(option == 2)
                {
                    magicEffects[Random.Range(0, 2)].Play();
                    randomSounds[Random.Range(0, 1)].Play();
                    userDamage = Random.Range(1, 10);
                    ghost.health = ghost.health - userDamage;
                    finalText = "You hit the enemy for: " + userDamage;
                    StartCoroutine(main.ChangeText(finalText, 2));
                    yield return new WaitUntil(() => !main.textChanging);
                }//END if-else
            }//END if
            else
            {
                userDamage = 0;
                finalText = "Your attack did not meet or beat the enemy's defense!";
                StartCoroutine(main.ChangeText(finalText, 2));
                yield return new WaitUntil(() => !main.textChanging);
            }
        }//END else

        if(enemyAttack == 1 && option != 3)
        {
            enemyDamage = Random.Range(1, 6);
            ghost.health = ghost.health - enemyDamage;
            finalText = "Critical Miss! The enemy hit itself in the confusion!";
            StartCoroutine(main.ChangeText(finalText, 2));
            yield return new WaitUntil(() => !main.textChanging);
        }//END if
        else if(enemyAttack == 20 && option != 3)
        {
            if(option != 3)
            {
                roll.DiceRoll();
                yield return new WaitUntil(() => !roll.rolling);
                enemyDamage = Random.Range(1, 20);
                player.health = player.health - enemyDamage;
                finalText = "Critical Hit! The enemy hit you for: " + enemyDamage + "!";
                StartCoroutine(main.ChangeText(finalText, 2));
                yield return new WaitUntil(() => !main.textChanging);
            }
        }//END else if
        else
        {
            if(enemyAttack >= player.defense)
            {
                if(option != 3)
                {
                    enemyDamage = Random.Range(1, 6);
                    player.health = player.health - enemyDamage;
                    finalText = "You were hit for: " + enemyDamage;
                    StartCoroutine(main.ChangeText(finalText, 2));
                    yield return new WaitUntil(() => !main.textChanging);
                }
            }//END if
            else
            {
                enemyDamage = 0;
                finalText = "The enemy's attack did not meet or beat your defense!";
                StartCoroutine(main.ChangeText(finalText, 2));
                yield return new WaitUntil(() => !main.textChanging);
            }//END else
        }//END else
        StartCoroutine(main.ResetText());
        yield return null;
    }//END ProcessBattle()
}//END BattleController.c
