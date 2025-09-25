using UnityEngine;

[CreateAssetMenu(fileName = "EnemysData", menuName = "Scriptable Objects/EnemysData")]
public class EnemysData : ScriptableObject
{
    [Header("Stats")]
    public int hp = 10;
    public int cost = 1;
    public int damage = 5;
    public float knockbackPower = 2f;
    public float speed = 2f;
}
