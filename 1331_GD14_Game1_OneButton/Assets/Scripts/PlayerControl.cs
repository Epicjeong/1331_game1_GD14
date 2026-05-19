using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 _startSpeed;
    private Vector2 _speed;

    [SerializeField] private int _health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _startSpeed;
    }


    void FixedUpdate()
    {
        transform.Translate(_speed * Time.fixedDeltaTime);
    }

    public void SwitchDirections(InputAction.CallbackContext context)
    {
        _speed = -_startSpeed;
        if (context.canceled)
        {
            _speed = _startSpeed;
        }
    }
}
