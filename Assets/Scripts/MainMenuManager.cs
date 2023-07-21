using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private Button playButton;

    private void Awake()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        playButton.onClick.AddListener(LoadGame);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}
