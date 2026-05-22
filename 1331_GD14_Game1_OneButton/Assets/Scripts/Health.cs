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
    [SerializeField] private GameObject _gameOverDisplay;
    [SerializeField] private Score _score;
    [SerializeField] private HeartDisplay _hearts;
 
    private int _invulTime = 2;
    public int CurrentHealth { get; private set; }

    public int MaxHealth => _maxHealth;
    public bool IsDead { get; private set; }

    private void Awake()
    {
        ResetHealth();
        _hearts.MakeHearts();
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
            _hearts.RemoveHeart();

            if (CurrentHealth <= 0) Die();

            else
                StartCoroutine(Invulnerable());
        }
    }

    private void Die()
    {
        IsDead = true;
        OnDied?.Invoke();
        _spawner.CancelInvoke();
        _gameOverDisplay.SetActive(true);
        _score.StopScore();
        Destroy(gameObject);
    }

    public IEnumerator Invulnerable()
    {
        _isInvulnerable = true;
        _spawner.CancelInvoke();
        _player.Freeze();
        yield return new WaitForSeconds(_invulTime);
        _isInvulnerable = false;
        _spawner.StartDropping();
        _player.Resume();
    }
}
