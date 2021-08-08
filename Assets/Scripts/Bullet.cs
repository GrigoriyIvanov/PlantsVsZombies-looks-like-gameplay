using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float BulletDamage;
    private Rigidbody2D _myRigidBody;
    private void Start()
    {
        _myRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move(3);
    }
    private void Move(int Speed)
    {
        var pos = gameObject.transform.position;
        pos.x += (float)Speed / 100;
        _myRigidBody.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Destroy(gameObject);
        }
    }
}
