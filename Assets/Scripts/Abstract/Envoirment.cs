using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Envoirment : MonoBehaviour
{

    float speedOffset;
    public float windSpeed = 1;

    void Start()
    {
        speedOffset = Random.Range(0.8f, 1.2f);
    }


    public void Sway(float swayAmount, float swaySpeed, float offset)
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (swayAmount * Mathf.Sin(Time.time * swaySpeed + offset)));
    }

    public void Bounce(float bounceAmount, float bounceSpeed, float offset)
    {
        GetComponent<Transform>().transform.localScale = new Vector3(1, 1 + bounceAmount * Mathf.Sin(Time.time * bounceSpeed + offset), 0);
    }


    public void FloatRight(float speed)
    {
        this.transform.position += new Vector3(speed * speedOffset * windSpeed, 0, 0);
        if(this.transform.position.x > 7)
        {
            Destroy(gameObject);
        }

    }



}
