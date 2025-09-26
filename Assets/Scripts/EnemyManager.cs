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
    private int cost;
    private GameObject player;
    private PlayerController playerController;
    private Rigidbody2D rb;
    [SerializeField] Slider slider;
    private GameManager gameManager;
    private void Awake()
    {
        hp = enemyData.hp;
        speed = enemyData.speed;
        damage = enemyData.damage;
        knockBackPower = enemyData.knockbackPower;
        cost = enemyData.cost;

        slider.maxValue = hp;
        slider.value = hp;
    }
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(cost);
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
        if (hp < 0) {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1)
            {
                gameManager.wave++;
                gameManager.SpawnWave();
            }
            Destroy(gameObject);
        }
    }
    public void DealDmg(int damage)
    {
        player.GetComponent<PlayerManager>().currHp -= damage;
        Vector2 knockbackDir = (player.GetComponent<Rigidbody2D>().transform.position - transform.position).normalized;
        playerController.StartCoroutine(player.GetComponent<PlayerController>().Knockback(knockbackDir, knockBackPower));

    }
    public int GetCost()
    {
        return enemyData !=null ? enemyData.cost : 1;
    }
}
