using UnityEngine;

public class SimpleDamageReciever : MonoBehaviour, IDamageReciever
{
    [SerializeField] private Health _health;

    private void Awake()
    {
        if (_health == null )
        {
            _health = GetComponentInParent<Health>();
        }
    }

    public void ApplyDamage(DamageInfo info)
    {
        if (_health == null) return;

        info.Amount = Mathf.RoundToInt(info.Amount);
        _health.ApplyDamage(info);
    }
}
