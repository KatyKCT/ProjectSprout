using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchPlacer : MonoBehaviour
{

    float growthSpeed;
    int maxHeight;
    
    
    
    public int currentHeigth;
    public string branchType;
    public string sproutType;

    Object[] branchPrefabModules;
    public bool isAvailable = true;

    // Start is called before the first frame update
    void Start()
    {
        growthSpeed = GetComponentInParent<BaseModule>().growthSpeed;
        maxHeight = GetComponentInParent<BaseModule>().maxHeight;



        branchPrefabModules = Resources.LoadAll(branchType);


        StartCoroutine(SpawnRandomBranch());
    }


    IEnumerator SpawnRandomBranch()
    {
        yield return new WaitForSeconds(growthSpeed * Random.Range(0f,0f));

        if (isAvailable == true)
        {
            GameObject toSpawn = (GameObject)branchPrefabModules[Random.Range(0, branchPrefabModules.Length)];
            GameObject spawned = Instantiate(toSpawn, this.transform.position, Quaternion.identity, this.transform);
            spawned.GetComponent<BranchInfo>().currentHeigth = this.currentHeigth;
            spawned.GetComponent<BranchInfo>().branchType = this.branchType;
            spawned.GetComponent<BranchInfo>().sproutType = this.sproutType;
            isAvailable = false;
        }
    }

}
