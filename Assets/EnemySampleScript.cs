using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySampleScript : Enemy
{
    
    void Start()
    {
        StartCoroutine(Move());

    }

    void Update()
    {
        
    }

    IEnumerator Move()
    {
        while (GetComponent<EnemyInfo>().isDead == false)
        {
            yield return new WaitForSecondsRealtime(2);
            JumpForward();
        }
    }

}
