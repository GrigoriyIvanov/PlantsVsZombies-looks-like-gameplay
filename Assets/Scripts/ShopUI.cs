using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private GameObject _allTowers;
    [SerializeField] private GameObject _shopButton;
    private List<ScriptableObject> _allTowersList = new List<ScriptableObject>();

    static public ScriptableObject s_oughtTower;
    static public bool s_isBoughtSmthng = false;

    void Start()
    {
        _allTowersList = _allTowers.GetComponent<AllTowers>().TowersList;

        for (int i = 0; i < _allTowersList.Count; i++)
        {
            ButtonInit(i);
        }
    }
    private void ButtonInit(int i)
    {
        var Button_In_Shop = Instantiate(_shopButton, gameObject.transform.position, Quaternion.identity);
        Button_In_Shop.transform.SetParent(gameObject.transform, false);
        Button_In_Shop.transform.localScale = new Vector3(1, (float)1, 1);

        var item = (TowerData)_allTowersList[i];
        //Выставляем цену
        Button_In_Shop.transform.GetChild(0).gameObject.GetComponent<Text>().text = item.Price.ToString();

        //Выставляем иконку
        Button_In_Shop.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = item.Icon;

        //Обозначаем клик
        Button_In_Shop.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(item));
    }

    private void ButtonClicked(ScriptableObject tower)
    {
        var item = (TowerData)tower;
        if (Money.s_moneyAmount >= item.Price)
        {
            Money.s_moneyAmount += -item.Price;
            Money.MoneyChange(Money.s_moneyAmount);
            s_isBoughtSmthng = true;
            s_oughtTower = tower;
        }
        else
        {
            //Not enough money
        }
    }
}
