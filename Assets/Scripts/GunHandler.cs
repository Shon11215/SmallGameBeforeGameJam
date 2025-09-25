using UnityEngine;

public class GunHandler : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzle;
    private float rateOfFire;
    private float nextFireTime = 0f;
    void Start()
    {
        rateOfFire = gunData.rateOfFire;
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
    }
    public void TryShoot()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / gunData.rateOfFire;
        }
    }
}
