using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Vector2 _startSpeed;
    private Vector2 _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _speed = _startSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(_speed * Time.fixedDeltaTime);
        Debug.Log(_speed);
    }

    public void Stop(InputAction.CallbackContext context)
    {
        Debug.Log("oiuhasdfa");
        _speed = new Vector2(0, 0); 
        if (context.canceled)
            _speed = _startSpeed;
    }
}
