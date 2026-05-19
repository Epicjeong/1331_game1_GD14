using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    
    void FixedUpdate()
    {
        transform.Translate(_speed * Time.fixedDeltaTime);
    }

    public void SwitchDirections(InputAction.CallbackContext context)
    {
        _speed = _speed * -1;
    }
}
