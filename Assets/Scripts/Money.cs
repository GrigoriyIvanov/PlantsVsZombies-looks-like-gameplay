using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private Rigidbody2D _coinRigidBody;
    private float _yCoordinateToStop;
    private float _moneySpeed = -3f;

    static public int s_moneyAmount;
    public bool IsSkyFallingCoin;

    public static event OnMoneyAmountChange onMoneyAmountChange;
    public delegate void OnMoneyAmountChange(int money);

    

    void Start()
    {
        BeginMove(IsSkyFallingCoin);
    }
    void Update()
    {
        RandomStoper();
    }
    private void BeginMove(bool isSkyFallingCoin)
    {
        _yCoordinateToStop = Random.Range((float)-5.5, (float)-2.35);
        _coinRigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (isSkyFallingCoin)
        {
            _coinRigidBody.velocity = new Vector2(0, _moneySpeed);          
        }
        else
        {
            _coinRigidBody.bodyType = RigidbodyType2D.Dynamic;
            _coinRigidBody.AddForce(new Vector2(Random.Range(-150,150), Random.Range((float)1.4,3)*150));
        }
    }
    private void RandomStoper()
    {
        if (gameObject.transform.position.y < _yCoordinateToStop && _coinRigidBody.velocity.y != 0)
        {
            _coinRigidBody.velocity = new Vector2(0, 0);
            _coinRigidBody.bodyType = RigidbodyType2D.Static;
        }
    }
    private void OnMouseDown()
    {
        s_moneyAmount += 25;
        MoneyChange(s_moneyAmount);
        Destroy(gameObject);
    }
    static public void MoneyChange(int MoneyAmount)
    {
        onMoneyAmountChange?.Invoke(money: MoneyAmount);
    }
}
