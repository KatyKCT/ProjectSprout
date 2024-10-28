using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuerillaBranch1Script : MonoBehaviour
{


    void Start()
    {

        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1);
        StartCoroutine(Growing());

    }

    

    IEnumerator Growing()
    {
        //The Branch grows
        float localGrowthRate = Random.Range(20, 25);

        while (GetComponent<Transform>().localScale.x < 1)
        {
            yield return new WaitForSecondsRealtime(GetComponentInParent<BaseModule>().growthSpeed / localGrowthRate);
            GetComponent<Transform>().localScale += new Vector3(0.01f,0.01f,0f);
        }

        if(GetComponent<Transform>().localScale.x > 1 || GetComponent<Transform>().localScale.y > 1)
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }



        //When reaching full size, new branches can grow
        GetComponent<BranchInfo>().currentHeigth = GetComponentInParent<BranchPlacer>().currentHeigth;
        bool spawnedBranches = false;


        while (spawnedBranches == false)
        {
            if (GetComponent<BranchInfo>().currentHeigth < GetComponentInParent<BaseModule>().maxHeight && GetComponent<Transform>().rotation.z < 0.02 && GetComponent<Transform>().rotation.z > -0.02)
            {
                SpawnBranchPlace(0f, 0.8f);
                SpawnSproutPlace(0f, 0.38f);
                spawnedBranches = true;
            }
            yield return new WaitForEndOfFrame();
        }

    }



    void Update()
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (10 * Mathf.Sin(Time.time + 10 * (-1 ^ GetComponent<BranchInfo>().currentHeigth))));
    }





    void SpawnBranchPlace(float x, float y)
    {
        Object toSpawn = Resources.Load("BranchPlace");
        GameObject spawnedBranchPlace = (GameObject)Instantiate(toSpawn, this.transform.position + new Vector3(x, y, 0), Quaternion.identity, this.transform);
        spawnedBranchPlace.GetComponent<BranchPlacer>().currentHeigth = GetComponent<BranchInfo>().currentHeigth + 1;
        spawnedBranchPlace.GetComponent<BranchPlacer>().branchType = GetComponent<BranchInfo>().branchType;
        spawnedBranchPlace.GetComponent<BranchPlacer>().sproutType = GetComponent<BranchInfo>().sproutType;
    }

    void SpawnSproutPlace(float x, float y)
    {
        Object toSpawn = Resources.Load("SproutPlace");
        GameObject spawnedSproutPlace = (GameObject)Instantiate(toSpawn, this.transform.position + new Vector3(x, y, 0), Quaternion.identity, this.transform);
        spawnedSproutPlace.GetComponent<SproutPlacer>().sproutType = GetComponent<BranchInfo>().sproutType;
    }




}
