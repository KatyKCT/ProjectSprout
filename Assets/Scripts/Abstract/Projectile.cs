using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float baseDamage;

    private void Start()
    {
        StartCoroutine(DestoryProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestoryProjectile()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }


}
