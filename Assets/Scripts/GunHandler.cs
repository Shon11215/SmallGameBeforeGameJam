using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    [SerializeField] private BulletData bulletData;
    public float rateOfFire;
    public int currentDamage;
    private float nextFireTime = 0f;
    void Start()
    {
        currentDamage = bulletData.damage;
        rateOfFire = gunData.rateOfFire;
    }

    private void Shoot()
    {
        var go = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
        var bullet = go.GetComponent<BulletBehavior>();
        if (bullet != null)
        {
            bullet.damage = currentDamage;            
        }
    }
    public void TryShoot()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / rateOfFire;
        }
    }
}
