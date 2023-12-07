using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    Controls playerControls;

    [Inject] private PlayerMovement playerMovement;
    [Inject] private PlayerTower playerTower;

    private void Awake()
    {
        playerControls = new Controls();

        playerControls.Player.Attack.performed += _ => playerTower.Attack(true);
        playerControls.Player.Attack.canceled += _ => playerTower.Attack(false);

        playerControls.Player.Movement.performed += value => playerMovement.Move(value.ReadValue<Vector2>());
        playerControls.Player.Movement.canceled += value => playerMovement.Move(value.ReadValue<Vector2>());

        playerControls.Player.TowerRotation.performed += value => playerTower.RotateTower(value.ReadValue<float>());
        playerControls.Player.TowerRotation.canceled += value => playerTower.RotateTower(value.ReadValue<float>());

        playerControls.Player.WeaponChange.performed += value => playerTower.ChangeCannon(value.ReadValue<float>());
    }

    private void OnEnable()
    {
        playerControls.Player.Enable();
    }

    private void OnDisable()
    {
        playerControls.Player.Disable();
    }

}
