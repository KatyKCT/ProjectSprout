using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sprout : MonoBehaviour
{
   

    public float growthSpeed;
    public float baseDamage;
    public float baseAttackSpeed;
    public float baseRange;
    float localGrowthRate;

    public bool isIdle = true;

    private void Awake()
    {
        localGrowthRate = Random.Range(20, 25);
    }

    public IEnumerator Growing()
    {
        //The Sprout grows
        while (GetComponent<Transform>().localScale.x < 1)
        {
            yield return new WaitForSecondsRealtime(GetComponentInParent<BaseModule>().growthSpeed / localGrowthRate);
            GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0f);
        }

        if (GetComponent<Transform>().localScale.x > 1 || GetComponent<Transform>().localScale.y > 1)
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }

    }

    public void ShotClosestEnemy()
    {
        //Find closest enemy within range

        RaycastHit2D hit = Physics2D.BoxCast(transform.position - new Vector3(baseRange / 2, 0, 0), new Vector2(baseRange, baseRange), 0, new Vector2(1, 0));
        Debug.DrawRay(transform.position - new Vector3(baseRange / 2, 0, 0), new Vector2(baseRange, 0), Color.red);

        if (hit)
        {
            isIdle = false;
            Vector3 direction = hit.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
        }
        else
        {
            isIdle = true;
        }

        //Determine direction to the enemy from sprout

        //Initialize a dart

        //Apply force and direction to the dart

    }



    public void SwaySprout(int offset)
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (10 * Mathf.Sin(Time.time + offset)));
    }

}
