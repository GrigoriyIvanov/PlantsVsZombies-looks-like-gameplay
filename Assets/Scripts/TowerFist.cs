using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFist : Tower
{
    private TowerFistData _towerData;
    private int _reloadTime;
    private float _towerHealth;
    [SerializeField] private SpriteRenderer _fist;
    [SerializeField] private RuntimeAnimatorController _attacAnimation;
    [SerializeField] private SpriteMask _mask1;
    [SerializeField] private SpriteMask _mask2;

    public bool IsReloaded;
    public override void Init(TowerData _towerSettings)
    {
        base.Init(_towerSettings);
        _towerData = (TowerFistData)_towerSettings;
        _reloadTime = _towerData.ReloadTime;
        IsReloaded = true;
        _fist.sprite = _towerData.Icon;
        _towerHealth = _towerData.Health;
        gameObject.GetComponent<SpriteRenderer>().sprite = null;

        var orderInLayer = (int)transform.position.y+10;
        _mask1.frontSortingOrder = orderInLayer;
        _mask2.frontSortingOrder = orderInLayer;
        _fist.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
    }
    public override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        if (collision.gameObject.GetComponent<Enemy>() != null && IsReloaded)
        {
            IsReloaded = false;
            FistAttac();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null && IsReloaded)
        {
            IsReloaded = false;
            FistAttac();           
        }
    }
    private void FistAttac()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = _attacAnimation;
        GetDamage(1000);
        StartCoroutine(FistReload());
    }
    IEnumerator FistReload()
    {
        yield return new WaitForSeconds(_reloadTime);
        IsReloaded = true;
    }
    public void StopAnimation()
    {
        gameObject.GetComponent<Animator>().runtimeAnimatorController = null;
    }
}
