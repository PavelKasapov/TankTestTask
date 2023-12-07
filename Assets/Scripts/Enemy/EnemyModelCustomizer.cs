using UnityEngine;

public class EnemyModelCustomizer : MonoBehaviour
{
    [SerializeField] private Transform body;
    [SerializeField] private SpriteRenderer pointer;
    [SerializeField] private Transform armorSpriteMask;
    public void InitParams(EnemyParameters parameters)
    {
        SetBodyScale(parameters.hp);
        SetPointerColor(parameters.damage);
        SetArmorThickness(parameters.armor);
    }

    private void SetBodyScale(float hp)
    {
        switch (hp)
        {
            case float n when (n < 75f):
                body.localScale = Vector3.one * 0.5f;
                break;

            case float n when (n >= 75f && n <= 150f):
                body.localScale = Vector3.one;
                break;

            case float n when (n > 150f):
                body.localScale = Vector3.one * 2f;
                break;
        }
    }

    private void SetPointerColor(float damage)
    {
        switch (damage)
        {
            case float n when (n < 7.5f):
                pointer.color = Color.green;
                break;

            case float n when (n >= 7.5f && n <= 15f):
                pointer.color = Color.yellow;
                break;

            case float n when (n > 15f):
                pointer.color = Color.red;
                break;
        }
    }

    private void SetArmorThickness(float armor)
    {
        armorSpriteMask.localScale = Vector3.one * (1f - armor);
    }
}