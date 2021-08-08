using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChanger : MonoBehaviour
{
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _abilityPanel;
    [SerializeField] private GameObject _deffeatPanel;
    [SerializeField] private GameObject _WinPanel;
    private void Start()
    {
        LoseController.onDefeat += onDefeat;
        SpawnController.onWin += onWin;
    }
    private void onDefeat()
    {
        _shopPanel.SetActive(false);
        _abilityPanel.SetActive(false);
        _deffeatPanel.SetActive(true);
    }
    private void onWin()
    {
        _shopPanel.SetActive(false);
        _abilityPanel.SetActive(false);
        _WinPanel.SetActive(true);
    }
}
