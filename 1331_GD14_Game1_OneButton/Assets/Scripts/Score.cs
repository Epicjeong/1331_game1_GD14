using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float _timer;
    private int _score;
    private bool _playerAlive = true;
    [SerializeField] private TextMeshProUGUI _scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _timer = 0f;
    }

    private void Update()
    {
        if (_playerAlive)
        {
            _timer += Time.deltaTime;
            _score = System.Convert.ToInt32(_timer);
            _scoreText.text = "Score: " + _score;
        }
    }

    public void StopScore()
    {
        _playerAlive = false;
    }
}
