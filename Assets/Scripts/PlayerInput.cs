using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    DiscreteMovement discreteMovement;
    [SerializeField] AnimationController animationController;

    void Awake()
    {
        discreteMovement = GetComponent<DiscreteMovement>();
    }//END awake()

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        if(Input.GetKey(KeyCode.W))
        {
            animationController.ChangeAnimationState();
            vel.y = 1;
        }//END if
        if(Input.GetKey(KeyCode.A))
        {
            animationController.ChangeAnimationState();
            vel.x = -1;
        }//END else if
        if(Input.GetKey(KeyCode.S))
        {
            animationController.ChangeAnimationState();
            vel.y = -1;
        }//END else if
        if(Input.GetKey(KeyCode.D))
        {
            animationController.ChangeAnimationState();
            vel.x = 1;
        }//END else if
        if(!Input.anyKey)
        {
            animationController.StopAnimationState();
        }

        discreteMovement.MoveRB(vel);
    
    }//END Update()
}
