using System;

public interface IDamageable
{
    int Life { get; set; }
    int TakeDamage(int damage);
    event Action<int> OnTakeDamage;
}
