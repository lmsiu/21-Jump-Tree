using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject crowPrefab;
    public float spawnInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCrows(spawnInterval, crowPrefab));

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnCrows(float interval, GameObject crow){
        yield return new WaitForSeconds(interval);
        GameObject newCrow = Instantiate(crow, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6), 0), Quaternion.identity);
        StartCoroutine(spawnCrows(interval, crow));
    }
}
