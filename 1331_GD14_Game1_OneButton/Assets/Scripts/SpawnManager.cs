using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _candyPrefab;
    private int _spawnRange = 7;
    private float _spawnInterval = 0.3f;
    public AudioSource _audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDropping();
    }

    private void DropCandies()
    {
        int candySpawned = Random.Range(0, _candyPrefab.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_spawnRange, _spawnRange), transform.position.y);
        Instantiate(_candyPrefab[candySpawned], spawnPos, transform.rotation);
    }

    public void StartDropping()
    {
        InvokeRepeating("DropCandies", 0, _spawnInterval);
    }
}
