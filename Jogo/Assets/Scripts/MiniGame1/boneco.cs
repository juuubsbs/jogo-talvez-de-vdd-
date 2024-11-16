using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class boneco : MonoBehaviour
{

   
    public float speed;
    public Rigidbody2D rig;

    float direction;

    void Start()
    {

    }


    void Update()
    {

        direction = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        rig.velocity = new Vector2(direction * speed, rig.velocity.y);
    }
}
