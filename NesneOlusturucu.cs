using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneOlusturucu : MonoBehaviour
{
    public GameObject[] nesnePrefabs;
    public float minSpawnTime=1f;
    public float maxSpawnTime=5f;
    public Transform spawnAreaTop;
    public Transform spawnAreaBottom;

    void Start()
    {
        StartCoroutine(NesneOlusturRoutine());
    }
    IEnumerator NesneOlusturRoutine()
    {
        while(true)
        {
            float spawnTime=Random.Range(minSpawnTime,maxSpawnTime);
            yield return new WaitForSeconds(spawnTime);

            float spawnX=Random.Range(spawnAreaTop.position.x,spawnAreaBottom.position.x);
            Vector3 spawnPosition=new Vector3(spawnX,spawnAreaTop.position.y,0);

            int randomIndex=Random.Range(0,nesnePrefabs.Length);
            Instantiate(nesnePrefabs[randomIndex],spawnPosition,Quaternion.identity);
        }

    }
}
