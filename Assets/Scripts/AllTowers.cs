using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTowers : MonoBehaviour
{
    public List<ScriptableObject> TowersList = new List<ScriptableObject>();

    /// <summary>
    ///  Сюда заносятся префабы башен всех типов которые есть в игре
    /// </summary>
    [SerializeField] private GameObject _defoaltTowerPrefab;
    [SerializeField] private GameObject _shootingTowerPrefab;
    [SerializeField] private GameObject _miningTowerPrefab;
    [SerializeField] private GameObject _fistTowerPrefab;

    public static Dictionary<string, GameObject> s_wichPrefabTower = new Dictionary<string, GameObject>();
    private void Start()
    {
        TowerListDictionary();
    }
    private void TowerListDictionary()
    {
        foreach (ScriptableObject tower in TowersList)
        {

            switch (tower.GetType().ToString())
            {
                case "StandingTowerData":
                    if (!s_wichPrefabTower.ContainsKey("StandingTowerData"))
                    { 
                        s_wichPrefabTower.Add(tower.GetType().ToString(), _defoaltTowerPrefab);
                    }
                    break;
                case "ShootingTowerData":
                    if (!s_wichPrefabTower.ContainsKey("ShootingTowerData"))
                    {
                        s_wichPrefabTower.Add(tower.GetType().ToString(), _shootingTowerPrefab);
                    }
                    break;
                case "MiningTowerData":
                    if (!s_wichPrefabTower.ContainsKey("MiningTowerData"))
                    {
                        s_wichPrefabTower.Add(tower.GetType().ToString(), _miningTowerPrefab);
                    }
                    break;
                case "TowerFistData":
                    if (!s_wichPrefabTower.ContainsKey("TowerFistData"))
                    {
                        s_wichPrefabTower.Add(tower.GetType().ToString(), _fistTowerPrefab);
                    }
                    break;
            }
        }
    }
}
