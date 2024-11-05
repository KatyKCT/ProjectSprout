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


        SpawnRandomSprout();
    }


    public void SpawnRandomSprout()
    {
        if (isAvailable == true)
        {
            GameObject toSpawn = (GameObject)sproutPrefabModules[Random.Range(0, sproutPrefabModules.Length)];
            GameObject spawned = Instantiate(toSpawn, this.transform.position, Quaternion.identity, this.transform);
            isAvailable = false;
        }
    }
}
