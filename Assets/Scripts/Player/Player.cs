using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Range(50f, 200f)] [SerializeField] private float hp;
    [Range(0f, 1f)] [SerializeField] private float armor;
    [Range(1f, 5f)] [SerializeField] private float speed;

    [Inject] PlayerMovement playerMovement;
    [Inject] HpSystem hpSystem;
    [Inject] HpBar hpBar;

    private void Start()
    {
        playerMovement.InitParams(speed);
        hpSystem.InitParams(hp, armor);
        hpSystem.OnDeath = () => gameObject.SetActive(false);
        hpBar.InitSlider();
    }
}
