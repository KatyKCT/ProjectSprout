using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float baseDamage;
    public float knockback;

    private void Start()
    {
        StartCoroutine(DestoryProjectile());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyInfo>().AlterHealth(-(baseDamage * Random.Range(0.8f,1.2f)));
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockback * 1,0));
            Destroy(gameObject);
        }
    }

    IEnumerator DestoryProjectile()
    {
        yield return new WaitForSecondsRealtime(2);
        Destroy(gameObject);
    }


}
