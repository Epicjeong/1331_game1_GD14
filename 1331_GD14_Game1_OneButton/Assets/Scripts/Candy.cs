using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody2D;
    [SerializeField] private Vector3 _force;

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidBody2D.AddForce(_force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
