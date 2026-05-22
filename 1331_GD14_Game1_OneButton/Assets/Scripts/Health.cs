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
    [SerializeField] private AudioSource _audio;

    private int _invulTime = 1;
    public int CurrentHealth { get; private set; }

    public int MaxHealth => _maxHealth;

    private void Awake()
    {
        ResetHealth();
        _hearts.MakeHearts();
    }

    public void ResetHealth()
    {
        CurrentHealth = _maxHealth;
    }

    public void ApplyDamage(DamageInfo info)
    {
        if (!_isInvulnerable)
        {
            CurrentHealth -= info.Amount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _maxHealth);

            _audio?.Play();
            _hearts.RemoveHeart();

            if (CurrentHealth <= 0) Die();

            else
                StartCoroutine(Invulnerable());
        }
    }

    private void Die()
    {
        _spawner.CancelInvoke();
        _gameOverDisplay.SetActive(true);
        _score.StopScore();
        Destroy(gameObject);
    }

    public IEnumerator Invulnerable()
    {
        _isInvulnerable = true;
        Debug.Log(_isInvulnerable);
        _spawner.CancelInvoke();
        _player.Freeze();
        yield return new WaitForSeconds(_invulTime);
        _isInvulnerable = false;
        _spawner.StartDropping();
        _player.Resume();
    }
}
