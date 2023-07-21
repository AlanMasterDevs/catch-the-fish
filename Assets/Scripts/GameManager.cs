using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private bool isGameOver = false;
    public GameObject gameOverPanel;

    private void Awake()
    {
        instance = this;
        gameOverPanel = GameObject.Find("GameOverPanel");
        gameOverPanel.SetActive(false);
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameOver = false;
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = true;
        FishSpawner.instance.GetFishes();
        FishSpawner.instance.StartSpawnFishes();
    }

    public void GameOver()
    {
        isGameOver = true;
        FishSpawner.instance.StopSpawnFishes();
        GameObject.Find("Player").GetComponent<PlayerController>().IsMoving = false;
        gameOverPanel.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
