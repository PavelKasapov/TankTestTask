using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    [Inject] EnemyMovement enemyMovement;
    [Inject] HpSystem hpSystem;
    [Inject] HpBar hpBar;
    [Inject] EnemyModelCustomizer enemyModelCustomizer;
    [Inject] EnemyAttack enemyAttack;
    private EnemyParameters parameters;

    public HpSystem HpSystem => hpSystem;

    public void SetParameters(EnemyParameters parameters)
    {
        enemyAttack.InitParams(parameters.damage);
        enemyMovement.InitParams(parameters.speed, parameters.hp);
        hpSystem.InitParams(parameters.hp, parameters.armor);
        hpBar.InitSlider();

        if (this.parameters != parameters)
        {
            enemyModelCustomizer.InitParams(parameters);

            this.parameters = parameters;
        }
    }

    public class Factory : PlaceholderFactory<Enemy>
    {
    }
}
