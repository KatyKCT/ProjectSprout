using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    Object[] skyPrefabs;


    void Start()
    {
        skyPrefabs = Resources.LoadAll("Skies");
        StartCoroutine(WindGust());
        StartCoroutine(SpawnSkies());
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        
    }

    public IEnumerator SpawnSkies()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(15f, 30f));
            GameObject spawnedSky = (GameObject)Instantiate(skyPrefabs[Random.Range(0, skyPrefabs.Length)], new Vector3(-7f, Random.Range(1.8f, 0f), 0), Quaternion.identity, this.transform);
        }
    }



    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(7f, 12f));
            GameObject spawnedEnemy = (GameObject)Instantiate( Resources.Load("EnemySample"), new Vector3(4f, -0.8f, 0), Quaternion.identity);
        }
    }



    public IEnumerator WindGust()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(Random.Range(5f, 10f));

            foreach (SkyScript child in GetComponentsInChildren<SkyScript>())
            {
                child.GetComponent<SkyScript>().windSpeed = 1.5f;
            }

            yield return new WaitForSecondsRealtime(Random.Range(2f, 5f));
            foreach (SkyScript child in GetComponentsInChildren<SkyScript>())
            {
                child.GetComponent<SkyScript>().windSpeed = 1f;
            }
        }

    }



}
