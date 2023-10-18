using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHover2 : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] Text text;

    void Start()
    {
        textBox.SetActive(false);
        text.enabled = false;
    }

    void OnMouseOver()
    {
        textBox.SetActive(true);
        text.enabled = true;
        text.text = "HPP (Haha you said peepee) is your current Health Point Percentage. Attack is your current bonus to your damage roll.";
        Debug.Log("Reached");
    }

    void OnMouseExit()
    {
        text.enabled = false;
        textBox.SetActive(false);
        Debug.Log("Reached");
    }
}
