using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    public int health;
    public int defense;
    public int attack;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        defense = 14;
        attack = 0;
    }

    public int OnPlayerTurn()
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
