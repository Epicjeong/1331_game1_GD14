using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ResetGame()
    {
        Debug.Log("peepeepoopoo");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
