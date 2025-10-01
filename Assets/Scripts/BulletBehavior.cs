using System;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] BulletData BulletData;
    private Rigidbody2D rb;
    public int damage;
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
        GameObject other = collision.collider.gameObject;
        if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            if(other.TryGetComponent<EnemyManager>(out var enemy))
                enemy.TakeDmg(damage);
            Destroy(gameObject);
        }
        
    }

 
}
