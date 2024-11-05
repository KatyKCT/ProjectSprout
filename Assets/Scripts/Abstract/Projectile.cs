using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float baseDamage;
    //public float knockBack;

    private void Start()
    {
        StartCoroutine(DestoryProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyInfo>().AlterHealth(-(baseDamage * Random.Range(0.8f,1.2f)));
            Destroy(gameObject);
        }
    }

    IEnumerator DestoryProjectile()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }


}
