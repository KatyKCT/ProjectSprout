using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public float baseDamage;
    public float baseSpeed;


    public void JumpForward()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(-50,100,0));
    }


}
