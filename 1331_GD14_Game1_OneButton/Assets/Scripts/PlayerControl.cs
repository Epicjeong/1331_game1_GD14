using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private CharacterController _charControl;
    [SerializeField] private Vector2 _startSpeed;
    [SerializeField] private SpriteRenderer _sprite;
    private Vector2 _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _startSpeed;
    }


    void FixedUpdate()
    {
        _charControl.Move(_speed * Time.deltaTime);
    }

    public void SwitchDirections(InputAction.CallbackContext context)
    {
        if (_speed != Vector2.zero)
        {
            _speed = -_startSpeed;
            if (context.canceled)
            {
                _speed = _startSpeed;
            }
        }
    }

    public void Freeze()
    {
        _speed = Vector2.zero;
        _sprite.color = new Color(1, 1, 1, .5f);
        transform.position = new Vector2(0, transform.position.y);
        Physics.SyncTransforms();
    }
    public void Resume()
    {
        _speed = _startSpeed;
        _sprite.color = new Color(1, 1, 1, 1);
    }
}
