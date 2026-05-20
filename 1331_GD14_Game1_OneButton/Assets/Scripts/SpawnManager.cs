using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _candyPrefab;
    private int _spawnRange = 7;
    private float _spawnInterval = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("DropCandies", 0, _spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DropCandies()
    {
        int candySpawned = Random.Range(0, _candyPrefab.Length);
        Vector2 spawnPos = new Vector2(Random.Range(-_spawnRange, _spawnRange), transform.position.y);
        Instantiate(_candyPrefab[candySpawned], spawnPos, transform.rotation);
    }
}
