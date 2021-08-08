using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawnController : MonoBehaviour
{
    private GameObject Highligthed_field;
    public bool IsTowerHere;

    private void Start()    =>  Highligthed_field = gameObject.transform.GetChild(0).gameObject;
    private void OnMouseEnter()
    {
        if (ShopUI.s_isBoughtSmthng && !IsTowerHere)
        {
            Highligthed_field.SetActive(true);
        }
        
    }
    private void OnMouseExit()
    {
            Highligthed_field.SetActive(false);
    }
    private void OnMouseDown()
    {
        if (ShopUI.s_isBoughtSmthng)
        {
            if (!IsTowerHere)
            {
                SpawnTower();
                IsTowerHere = true;
            }
        }
    }
    private void SpawnTower()
    {
        var _tower = ShopUI.s_oughtTower;
        var parentPosition = gameObject.transform.position;
        var prefab = Instantiate(AllTowers.s_wichPrefabTower[_tower.GetType().ToString()], gameObject.transform);

        prefab.GetComponent<Tower>().Init((TowerData)_tower);

        parentPosition.y += (float)0.2;
        prefab.transform.position = parentPosition;
        ShopUI.s_isBoughtSmthng = false;
    }
}
