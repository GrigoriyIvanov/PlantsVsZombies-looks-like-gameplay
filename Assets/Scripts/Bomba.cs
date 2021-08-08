using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] private GameObject _nuclearExplosion;

    public void ExploosionActivation()
    {
        Instantiate(_nuclearExplosion);
    }
    public void BombDeactivation()
    {
        Destroy(gameObject);
    }
}
