using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_spawn : MonoBehaviour
{
    [SerializeField] public float spawnRate;
    [SerializeField] private GameObject[] enemiesPrefab; // Enemies list
    [SerializeField] private bool canSpawn = true;
    public SpriteRenderer spawn;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner ()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
        while (canSpawn)
        {
            yield return wait;
            int randNum = Random.Range(0, enemiesPrefab.Length);
            GameObject enemiesRandom = enemiesPrefab[randNum];
            float x = Random.Range(-3, 3);
            float y = Random.Range(-3, 3);
            spawn.transform.localScale = new Vector3(x, y, 0);
            // Choose random in the enemies list
            Instantiate(enemiesRandom, transform.position, Quaternion.identity);
        }
    }
}
