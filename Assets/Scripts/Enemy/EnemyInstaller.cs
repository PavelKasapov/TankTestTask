using UnityEngine;
using Zenject;

public class EnemyInstaller : MonoInstaller
{
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] EnemyModelCustomizer enemyModelCustomizer;
    [SerializeField] HpBar hpBar;
    [SerializeField] Transform mainTransform;
    [SerializeField] EnemyAttack enemyAttack;

    public override void InstallBindings()
    {
        Container.BindInstance(enemyMovement); 
        Container.BindInstance(enemyModelCustomizer);
        Container.BindInstance(mainTransform).WithId("MainTransform");
        Container.BindInstance(hpBar);
        Container.BindInstance(enemyAttack);
        Container.BindInterfacesAndSelfTo<HpSystem>().AsSingle();
    }
}