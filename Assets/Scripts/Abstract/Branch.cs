using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Branch : MonoBehaviour
{

    public string branchType;
    public string sproutType;
    public int currentHeigth;

    public bool onlySpawnSprout;



    //---------------------------------------------------------------------------------------------------------------------------------------------------
    //            Basics: growing the branch, swaying the branch, spawning new branches and sprouts
    //---------------------------------------------------------------------------------------------------------------------------------------------------


    private void Awake()
    {
        GetComponent<Transform>().localScale = new Vector3(0.05f, 0.05f, 1);
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


    //---------------------------------------------------------------------------------------------------------------------------------------------------
    //            Mouse interactions, destroying the branch
    //---------------------------------------------------------------------------------------------------------------------------------------------------



    //Get the GameObject’s mesh renderer to access the GameObject’s material and color
    public GameObject branchSpriteFront;
    public GameObject branchSpriteBack;

    void Start()
    {
        branchSpriteFront.GetComponent<SpriteRenderer>().material.color = Color.white;
        branchSpriteBack.GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    void OnMouseOver()
    {
        // Change the color of the GameObject to red when the mouse is over GameObject
        branchSpriteFront.GetComponent<SpriteRenderer>().material.color = new Color(0.9f, 0.85f, 1f, 1f);
        branchSpriteBack.GetComponent<SpriteRenderer>().material.color = new Color(0.9f,0.85f,1f,1f);

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartCoroutine(DestroyBranch());
        }

    }

    void OnMouseExit()
    {
        // Reset the color of the GameObject back to normal
        branchSpriteFront.GetComponent<SpriteRenderer>().material.color = Color.white;
        branchSpriteBack.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
    



    public IEnumerator DestroyBranch()
    {

        for(float i = 0; i < 100; i+=5)
        foreach (SpriteRenderer child in GetComponentsInChildren<SpriteRenderer>())
        {
            child.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(1f, 1f, 1f, 1f), new Color(0.6f, 0.6f, 0.6f, 1f), i / 100);
            yield return new WaitForEndOfFrame();
        }

        GetComponentInParent<BranchPlacer>().isAvailable = true;
        GetComponentInParent<BranchPlacer>().StartCoroutine(GetComponentInParent<BranchPlacer>().WaitAndSpawnBranch());

        Destroy(gameObject);

    }

}
