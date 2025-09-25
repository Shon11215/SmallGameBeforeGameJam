using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private EnemysData enemyData;

    //Stats
    private int hp;
    private float speed;
    private int damage;
    private float knockBackPower;
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody2D rb;
    [SerializeField] Slider slider;

    private void Awake()
    {
        hp = enemyData.hp;
        speed = enemyData.speed;
        damage = enemyData.damage;
        knockBackPower = enemyData.knockbackPower;

        slider.maxValue = hp;
        slider.value = hp;
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player && collision.gameObject.CompareTag("Player"))
            DealDmg(damage);
    }
    private void FixedUpdate()
    {
        if (!player) { rb.linearVelocity = Vector2.zero; return; }
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rb.linearVelocity = dir * speed;
    }
    public void TakeDmg(int damage)
    {
        hp -= damage;
        slider.value = hp;
        if (hp < 0) { Destroy(gameObject); }
    }
    public void DealDmg(int damage)
    {
        player.GetComponent<PlayerManager>().currHp -= damage;
        Vector2 knockbackDir = (player.GetComponent<Rigidbody2D>().transform.position - transform.position).normalized;
        playerController.StartCoroutine(player.GetComponent<PlayerController>().Knockback(knockbackDir, knockBackPower));

    }
}
