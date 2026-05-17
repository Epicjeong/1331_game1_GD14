using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 _startSpeed;
    private Vector2 _speed;

    private float _breath = 100f;
    private bool _holdingBreath = false;
    private bool _canMove = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _startSpeed;
    }

    
    void FixedUpdate()
    {
        if (_holdingBreath && _breath > 0)
        {
            _breath--;
            Debug.Log(_breath);
            if (_breath == 0)
            {
                _holdingBreath = false;
                StartCoroutine(PanickedBreathing());
            }
        }
        else if (!_holdingBreath)
        {
            transform.Translate(_speed * Time.fixedDeltaTime);
            if (_breath < 100)
            {
                _breath++;
                Debug.Log(_breath);
            }
        }
    }

    public void Stop(InputAction.CallbackContext context)
    {
        _speed = new Vector2(0, 0);
        _holdingBreath = true;
        if (context.canceled && _holdingBreath)
        {
            Continue();
        }
    }

    private void Continue()
    {
        _holdingBreath = false;
        _speed = _startSpeed;

    }

    private IEnumerator PanickedBreathing()
    {
        yield return new WaitWhile(() => _breath < 100);
        _speed = _startSpeed;

    }
}
