using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnCollision : MonoBehaviour
{
    [SerializeField] GameObject textBox;
    [SerializeField] Text text;
    public int value = 0;
    // Start is called before the first frame update
    void Start()
    {
        textBox.SetActive(false);
        text.enabled = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Battle");
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
            text.enabled = true;
            value = 1;
            Debug.Log("Reached");
        }//END if
    }//END OnCollisionEnter2D

    void OnCollisionExit2D(Collision2D collision)
    {
        text.enabled = false;
        textBox.SetActive(false);
        value = 0;
        Debug.Log("Reached");
    }
}
