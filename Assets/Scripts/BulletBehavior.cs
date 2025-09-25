using System;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] BulletData BulletData;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(BulletData.bulletX, BulletData.bulletY);
        rb.linearVelocity = transform.right * BulletData.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,BulletData.lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
        if (enemy != null)
        {
            enemy.TakeDmg(BulletData.damage);
            Destroy(gameObject);
        }
    }

 
}
