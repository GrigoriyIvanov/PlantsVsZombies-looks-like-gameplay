using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private AllEnemy allEnemy;

    IEnumerator WaitForSpawn(int timeBetweenSpawn)
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
    }
    public void SingleEnemySpawn()
    {
        var EnemyToSpawn = allEnemy.EnemyList[Random.RandomRange(0, allEnemy.EnemyList.Count)];
        var prefab = Instantiate(allEnemy.WichPrefabEnemy[EnemyToSpawn.GetType().ToString()], gameObject.transform);
        prefab.GetComponent<Enemy>().Init((EnemyData)EnemyToSpawn);
    }
}
