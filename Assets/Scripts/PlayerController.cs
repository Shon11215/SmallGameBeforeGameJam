using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool inKnockback;
    [SerializeField] float knockbackDuration = 0.1f;

    public float speed = 1.0f;
    public Vector2 input;
    //public GameObject bullet;
    private GunHandler gunHandler;

    private Rigidbody2D rb;
    private Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gunHandler = GetComponentInChildren<GunHandler>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 worldPos = cam.ScreenToWorldPoint(mousePos);
        Vector2 dir = (Vector2)(worldPos - transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);


        if (Mouse.current.leftButton.isPressed)
        {
            gunHandler.TryShoot();
        }
    }

    public IEnumerator Knockback(Vector2 dir, float power)
    {
        inKnockback = true;
        rb.linearVelocity = dir * power;
        yield return new WaitForSeconds(knockbackDuration);
        inKnockback = false;
    }

    private void FixedUpdate()
    {
        if (!inKnockback)
        {
            rb.linearVelocity = input * speed;
        }
    }

    public void OnMove(InputValue value)
    {
        input = value.Get<Vector2>().normalized;
    }
}
