using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sprout : MonoBehaviour
{


    public float growthSpeed;
    public float baseDamage;
    public float baseAttackSpeed;
    public float baseRange;
    public float baseKnockback;
    float localGrowthRate;

    public GameObject shootingPlace;

    public string projectileType;
    public bool isIdle = true;

    private void Awake()
    {
        localGrowthRate = Random.Range(20, 25);
        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1); //Makes the sprout small so it can grow
    }


    void Update()
    {
        if (isIdle == true)
        {
            SwaySprout();
        }

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



    public IEnumerator ShotClosestEnemy()
    {
        while (true)
        {
            //Find closest enemy within range
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, new Vector2(baseRange, baseRange), 0, new Vector2(0, 0), 0, 3);
            
            //Shows the width of the sprouts range
            //Debug.DrawRay(transform.position - new Vector3(baseRange / 2, 0, 0), new Vector2(baseRange, 0), Color.red);

            if (hit && hit.collider.CompareTag("Enemy") && hit.collider.GetComponent<EnemyInfo>().isDead == false)
            {
                
                isIdle = false;

                //Determine direction to the enemy from sprout
                Vector3 direction = hit.transform.position - this.transform.position;
                HowToMoveShooting(direction);

                //Initialize a dart
                GameObject spawnedProjectile = (GameObject)Instantiate(Resources.Load(projectileType), shootingPlace.transform.position, Quaternion.identity);
                spawnedProjectile.GetComponent<Projectile>().baseDamage = this.baseDamage;
                spawnedProjectile.GetComponent<Projectile>().knockback = this.baseKnockback;

                //Apply force and direction to the dart
                spawnedProjectile.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
                spawnedProjectile.GetComponent<Rigidbody2D>().AddForce(200 * direction);

                yield return new WaitForSecondsRealtime(baseAttackSpeed);
                
            }
            else
            {
                isIdle = true;
            }

            
            yield return new WaitForFixedUpdate();

        }

    }




    //---------------------------------------------------------------------------------------------------------------------------------------------------
    //            Movement: rotating, swaying etc. dependend on task (idle, shooting)
    //---------------------------------------------------------------------------------------------------------------------------------------------------


    public virtual void HowToMoveShooting(Vector3 direction)
    {

    }


    public void PointAtEnemy(Vector3 direction)
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
    }

    public void PointLeftRight(Vector3 direction)
    {
        this.transform.rotation = Quaternion.FromToRotation(Vector3.right, new Vector3(direction.x,0,0));
    }

    public virtual void HowToMoveIdle()
    {

    }


    public void SwaySprout()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, (10 * Mathf.Sin(Time.time)));
    }

}
