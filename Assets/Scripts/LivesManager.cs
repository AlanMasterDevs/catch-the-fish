using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour
{
    public static LivesManager instance;
    private int lives = 5;
    [SerializeField]
    private GameObject[] livesImageUI;
    private Color UIImageColor;
    private GameObject livesPanel;

    private void Awake()
    {
        instance = this;
        //livesImageUI = GameObject.FindGameObjectsWithTag("LiveImageUI");
        UIImageColor = new Color(1, 1, 1, 0.5f);
    }

    private void Start()
    {
        livesPanel = GameObject.Find("LivesPanel");
        livesImageUI = new GameObject[livesPanel.transform.childCount];

        InitializeLives();
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            lives--;
            SetLiveImageUI();
        }

        if (lives <= 0)
            GameManager.instance.GameOver();
    }

    private void SetLiveImageUI()
    {
        livesImageUI[lives].GetComponent<Image>().color = UIImageColor;
    }

    private void InitializeLives()
    {
        for (int i = 0; i < livesPanel.transform.childCount; i++)
        {
            livesImageUI[i] = GameObject.Find("Live" + (i + 1));
        }
    }
}
