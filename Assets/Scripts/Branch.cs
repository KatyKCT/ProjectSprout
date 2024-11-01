using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Branch : MonoBehaviour
{

    public string branchType;
    public string sproutType;
    public int currentHeigth;

    public bool onlySpawnSprout;

    private void Start()
    {
        /*
        this.branchType = GetComponent<BranchInfo>().branchType;
        this.sproutType = GetComponent<BranchInfo>().sproutType;
        this.currentHeigth = GetComponent<BranchInfo>().currentHeigth;
        */
    }


    public void SpawnBranchPlace(float x, float y)
    {
        Object toSpawn = Resources.Load("BranchPlace");
        GameObject spawnedBranchPlace = (GameObject)Instantiate(toSpawn, this.transform.position + new Vector3(x, y, 0), Quaternion.identity, this.transform);
        spawnedBranchPlace.GetComponent<BranchPlacer>().currentHeigth = this.currentHeigth + 1;
        spawnedBranchPlace.GetComponent<BranchPlacer>().branchType = this.branchType;
        spawnedBranchPlace.GetComponent<BranchPlacer>().sproutType = this.sproutType;
    }

    public void SpawnSproutPlace(float x, float y)
    {
        Object toSpawn = Resources.Load("SproutPlace");
        GameObject spawnedSproutPlace = (GameObject)Instantiate(toSpawn, this.transform.position + new Vector3(x, y, 0), Quaternion.identity, this.transform);
        spawnedSproutPlace.GetComponent<SproutPlacer>().sproutType = this.sproutType;
    }


    public void SwayBranch()
    {
        GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, (10 * Mathf.Sin(Time.time + 10 * (-1 ^ currentHeigth))));
    }


    public virtual void SpawnPlaces()
    {
        

    }



    public IEnumerator Growing()
    {
        //The Branch grows
        float localGrowthRate = Random.Range(20, 25);

        while (GetComponent<Transform>().localScale.x < 1)
        {
            yield return new WaitForSecondsRealtime(GetComponentInParent<BaseModule>().growthSpeed / localGrowthRate);
            GetComponent<Transform>().localScale += new Vector3(0.01f, 0.01f, 0f);
        }

        if (GetComponent<Transform>().localScale.x > 1 || GetComponent<Transform>().localScale.y > 1)
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }



        //When reaching full size, new branches can grow
        bool spawnedBranches = false;


        while (spawnedBranches == false)
        {
            if (GetComponent<Branch>().currentHeigth <= GetComponentInParent<BaseModule>().maxHeight && GetComponent<Transform>().rotation.z < 0.02 && GetComponent<Transform>().rotation.z > -0.02)
            {
                if(GetComponent<Branch>().currentHeigth == GetComponentInParent<BaseModule>().maxHeight)
                {
                    onlySpawnSprout = true;
                }
                else
                {
                    onlySpawnSprout = false;
                }

                SpawnPlaces();
                spawnedBranches = true;
            }
            yield return new WaitForEndOfFrame();
        }

    }


}
