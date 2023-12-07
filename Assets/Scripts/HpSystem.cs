using System;

public class HpSystem
{
    public Action OnDeath = delegate { };
    public Action<float> OnHpChanged = delegate { };

    public float Hp 
    {
        get => hp;
        set 
        {
            hp = value;
            OnHpChanged(hp);

            if (hp <= 0)
            {
                OnDeath();
            }
        }
    }
    public float hp;
    public float armor;

    public void TakeDamage(float damage)
    {
        Hp -= damage * (1 - armor);
    }

    public void InitParams(float hp, float armor)
    {
        Hp = hp;
        this.armor = armor;
    }
}
