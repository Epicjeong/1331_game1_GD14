using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private bool _isInvulnerable;
    [SerializeField] private PlayerControl _player;
    [SerializeField] private SpawnManager _spawner;

    private int _invulTime = 1;
    public int CurrentHealth { get; private set; }

    public int MaxHealth => _maxHealth;
    public bool IsDead { get; private set; }

    private void Awake()
    {
        ResetHealth();
    }

    public event Action<DamageInfo> OnDamaged;
    public event Action OnDied;

    public void ResetHealth()
    {
        CurrentHealth = _maxHealth;
        IsDead = false;
    }

    public void ApplyDamage(DamageInfo info)
    {
        if (!IsDead || !_isInvulnerable)
        {
            CurrentHealth -= info.Amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);

            OnDamaged?.Invoke(info);
            Debug.Log(CurrentHealth);

            if (CurrentHealth <= 0) Die();

            else
            {
                StartCoroutine(Invulnerable());
            }
        }
    }

    private void Die()
    {
        IsDead = true;
        OnDied?.Invoke();
        Destroy(gameObject);
    }

    public IEnumerator Invulnerable()
    {
        _isInvulnerable = true;
        _spawner.CancelInvoke();
        _player.Freeze();
        Debug.Log("sasdfaf");
        yield return new WaitForSeconds(_invulTime);
        _isInvulnerable = false;
        _spawner.StartDropping();
        _player.Resume();
    }
}
