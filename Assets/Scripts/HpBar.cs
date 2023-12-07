using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HpBar : MonoBehaviour
{
    [SerializeField] Slider hpSlider;
    [SerializeField] RectTransform rectTransform;

    [Inject] HpSystem hpSystem;

    private void Awake()
    {
        hpSystem.OnHpChanged += SetValue;
    }

    private void OnDestroy()
    {
        hpSystem.OnHpChanged -= SetValue;
    }

    public void InitSlider()
    {
        hpSlider.maxValue = hpSystem.Hp;
        SetValue(hpSystem.Hp);
    }

    public void SetValue(float value)
    {
        gameObject.SetActive(value != hpSlider.maxValue);
        hpSlider.value = value;

        Debug.Log($"{hpSlider.value} {hpSlider.maxValue} {hpSystem.Hp}");
    }
}