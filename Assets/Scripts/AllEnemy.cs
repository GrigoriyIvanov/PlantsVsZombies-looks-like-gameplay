using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour
{
    [SerializeField] public List<ScriptableObject> EnemyList = new List<ScriptableObject>();

    /// <summary>
    ///  Сюда заносятся префабы башен всех типов которые есть в игре
    /// </summary>
    [SerializeField] private GameObject _defoaltEnemyPrefab;
    [SerializeField] private GameObject _shieldEnemyPrefab;

    public Dictionary<string, GameObject> WichPrefabEnemy = new Dictionary<string, GameObject>();
    private void Start()
    {
        TowerListDictionary();
    }
    private void TowerListDictionary()
    {
        foreach (ScriptableObject _tower in EnemyList)
        {

            switch (_tower.GetType().ToString())
            {
                case "EnemyData":
                    if (!WichPrefabEnemy.ContainsKey("EnemyData"))
                    {
                        WichPrefabEnemy.Add(_tower.GetType().ToString(), _defoaltEnemyPrefab);
                    }
                    break;
                case "ShieldEnemyData":
                    if (!WichPrefabEnemy.ContainsKey("ShieldEnemyData"))
                    {
                        WichPrefabEnemy.Add(_tower.GetType().ToString(), _shieldEnemyPrefab);
                    }
                    break;
            }
        }
    }
}
