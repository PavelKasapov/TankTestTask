using UnityEngine;

[CreateAssetMenu(fileName = "EnemyParameters", menuName = "ScriptableObjects/EnemyParameters", order = 1)]
public class EnemyParameters : ScriptableObject
{
    public string enemyTypeName;
    [Range(50f, 200f)]
    public float hp;
    [Range(5f, 20f)]
    public float damage;
    [Range(0f, 1f)]
    public float armor;
    [Range(1f, 5f)]
    public float speed;
}
