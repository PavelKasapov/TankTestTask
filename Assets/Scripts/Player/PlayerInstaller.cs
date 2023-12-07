using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] HpBar hpBar;
    [SerializeField] Transform mainTransform;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerTower playerTower;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<HpSystem>().AsSingle();
        Container.BindInstance(mainTransform).WithId("MainTransform");
        Container.BindInstance(hpBar);
        Container.BindInstance(playerMovement);
        Container.BindInstance(playerTower);
    }
}