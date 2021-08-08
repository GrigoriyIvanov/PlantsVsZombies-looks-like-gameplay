using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityShop : MonoBehaviour
{
    [SerializeField] private GameObject _laser;
    [SerializeField] private GameObject _bomba;
    IEnumerator LaserActivation()
    {
        _laser.SetActive(true);
        yield return new WaitForSeconds(5);
        _laser.SetActive(false);
    }
    public void BombaActivation()
    {
        Instantiate(_bomba);
    }
    public void LaserActivationButton()
    {
        StartCoroutine(LaserActivation());
    }
}
