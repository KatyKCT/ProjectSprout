using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SproutPlacer : MonoBehaviour
{

    float growthSpeed;
   
    public string sproutType;

    Object[] sproutPrefabModules;
    public bool isAvailable = true;

   
    void Start()
    {
        growthSpeed = GetComponentInParent<BaseModule>().growthSpeed;



        sproutPrefabModules = Resources.LoadAll(sproutType);


        StartCoroutine(SpawnRandomSprout());
    }


    IEnumerator SpawnRandomSprout()
    {
        yield return new WaitForSeconds(growthSpeed * Random.Range(0f, 0f));

        if (isAvailable == true)
        {
            GameObject toSpawn = (GameObject)sproutPrefabModules[Random.Range(0, sproutPrefabModules.Length)];
            GameObject spawned = Instantiate(toSpawn, this.transform.position, Quaternion.identity, this.transform);
            isAvailable = false;
        }
    }
}
