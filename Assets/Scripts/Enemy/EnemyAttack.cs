using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    WaitForSeconds waitForSeconds = new(1f);
    bool canAttack = true;
    float damage;
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canAttack && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HitTaker>().TakeDamage(damage);
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        canAttack = false;
        yield return waitForSeconds;
        canAttack = true;
    }

    public void InitParams(float damage)
    {
        this.damage = damage;
    }
}
