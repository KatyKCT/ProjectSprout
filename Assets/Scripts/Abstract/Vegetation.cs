using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vegetation : MonoBehaviour
{


    public void SwayPlant(float swayAmount, float swaySpeed, float offset)
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (swayAmount * Mathf.Sin(Time.time * swaySpeed + offset)));
    }

    public void BouncePlant(float bounceAmount, float bounceSpeed, float offset)
    {
        GetComponent<Transform>().transform.localScale = new Vector3(1, 1 + bounceAmount  * Mathf.Sin(Time.time * bounceSpeed + offset), 0);
    }


}
