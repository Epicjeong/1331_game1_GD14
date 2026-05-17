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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _startSpeed;
    }

    
    void FixedUpdate()
    {
        transform.Translate(_speed * Time.fixedDeltaTime);
        if (_holdingBreath)
        {
            _breath--;
            Debug.Log(_breath);
        }
        else if (!_holdingBreath && _breath < 100)
        {
            _breath++;
            Debug.Log(_breath);
        }
    }

    public void Stop(InputAction.CallbackContext context)
    {
        _speed = new Vector2(0, 0);
        _holdingBreath = true;
        if (_breath == 0)
        {
            PanickedBreathing();
        }
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
        _holdingBreath = false;
        yield return new WaitWhile(() => _breath < 100);
        Continue();
        
    }
}
