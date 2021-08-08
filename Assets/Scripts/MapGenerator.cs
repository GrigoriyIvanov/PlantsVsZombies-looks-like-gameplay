using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _floorCell;
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Instantiate(_floorCell, new Vector3((float)(-4.152272 + j * 1.5 / 0.9), (float)(-5.143477 + i * 1.5/0.9), 0), Quaternion.identity);
            }
        }
    }
}
