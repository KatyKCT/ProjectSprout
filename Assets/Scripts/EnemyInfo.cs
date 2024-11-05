using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{

    //public float baseDamage;
    public float maxHealth = 100;
    public float currentHealth = 100;
    //public float baseSpeed;

    public bool isDead = false;

    public void AlterHealth(float healthIncrement)
    {
        currentHealth += healthIncrement;

        if (currentHealth <= 0 && isDead == false)
        {
            StartCoroutine(KillEnemy());
        }
    }

    public IEnumerator KillEnemy()
    {
        isDead = true;
        yield return new WaitForSecondsRealtime(0.2f);
        Destroy(gameObject);
    }


}
