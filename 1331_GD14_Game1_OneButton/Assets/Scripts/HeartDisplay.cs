using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Transform _contentParent;
    [SerializeField] private Health _health;
    [SerializeField] private GameObject _heart;
    private int _heartSize = 50;
    private int _placementOffset = 320;
    public List<GameObject> _heartAmount;

    public void MakeHearts()
    {
        for (var i = 0; i < _health.CurrentHealth; i++)
        {
            Vector2 pos = new Vector2(transform.position.x, i * -_heartSize + _placementOffset);
            var heart = Instantiate(_heart, _contentParent);
            heart.transform.position = pos;
            _heartAmount.Add(heart);
        }
    }

    public void RemoveHeart()
    {
        var heart = _heartAmount[_health.CurrentHealth];
        _heartAmount.Remove(heart);
        Destroy(heart);
    }
}
