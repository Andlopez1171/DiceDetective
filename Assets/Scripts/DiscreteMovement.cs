using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscreteMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }//END awake

    void Start()
    {

    }

    public void MoveTransform(Vector3 vel)
    {
        transform.position += vel * Time.deltaTime * 2;
    }//END MoveTransform()

    public void MoveRB(Vector3 vel)
    {
        rb.velocity = vel * speed;
    }
}
