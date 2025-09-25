using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Scriptable Objects/BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Stats")]
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 3f;
    public float bulletX = 0.1f;
    public float bulletY = 0.03f;

}
