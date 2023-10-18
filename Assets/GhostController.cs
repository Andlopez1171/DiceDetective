using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public int health;
    public int defense;
    public int attack;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        defense = 13;
        attack = 0;
    }

    public int OnEnemyTurn()
    {
        int randomValue = Random.Range(1, 20);
        if(randomValue == 1)
        {
            return randomValue;
        }//END if
        else if(randomValue == 20)
        {
            return randomValue;
        }//END else
        else
        {
            return randomValue + attack;
        }//END else
    }
}
