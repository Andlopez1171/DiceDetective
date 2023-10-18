using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    [SerializeField] GhostController ghost;
    [SerializeField] UserController player;
    [SerializeField] diceRollingController roll;
    public int turnManager;
    public int userAttack;
    public int enemyAttack;
    public int userDamage;
    public int enemyDamage;

    void Start()
    {
        turnManager = 0;
    }//END Start

    public void ProcessBattle(int option)
    {
        userAttack = player.OnPlayerTurn();
        enemyAttack = ghost.OnEnemyTurn();

        if(userAttack == 1 && option != 3)
        {
            userDamage = Random.Range(1, 6);
            player.health = player.health - userDamage;
        }//END if
        else if(userAttack == 20 && option != 3)
        {
            userDamage = Random.Range(1, 20);
            ghost.health = ghost.health - userDamage;
        }//END else if
        else if(option != 3)
        {
            if(userAttack >= ghost.defense)
            {
                userDamage = Random.Range(1, 6);
                ghost.health = ghost.health - userDamage;
            }//END if
            else
            {
                userDamage = 0;
            }
        }//END else

        turnManager = 1;

        if(enemyAttack == 1 && option != 3)
        {
            enemyDamage = Random.Range(1, 6);
            ghost.health = ghost.health - enemyDamage;
        }//END if
        else if(enemyAttack == 20 && option != 3)
        {
            if(option != 3)
            {
                enemyDamage = Random.Range(1, 20);
                player.health = player.health - enemyDamage;
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
                }
            }//END if
            else
            {
                enemyDamage = 0;
            }
        }//END else
    }
}
