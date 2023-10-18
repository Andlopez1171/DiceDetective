using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] Text text;
    [SerializeField] UserController player;

    void Start()
    {
        textBox.SetActive(false);
        text.enabled = false;
    }

    void OnMouseOver()
    {
        textBox.SetActive(true);
        text.enabled = true;
        text.text = "Current player HPP is " + player.health + " and current attack is " + player.attack + ".";
        Debug.Log("Reached");
    }

    void OnMouseExit()
    {
        text.enabled = false;
        textBox.SetActive(false);
        Debug.Log("Reached");
    }
}
