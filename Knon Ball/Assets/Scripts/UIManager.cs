using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int curScore;

    [SerializeField] private GameObject mainMenu, pauseMenu, howToPlay;
    private bool backToMainMenu;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu.activeInHierarchy)
        {
            PauseAndResume();
        }
    }

    public void AddScore(int amount)
    {
        curScore += amount;

        scoreText.text = "Score " + curScore.ToString();
    }

    public void Play()
    {
        scoreText.gameObject.SetActive(true);
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseAndResume()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void HowToPlay(bool fromStartMenu)
    {
        if (fromStartMenu)
        {
            mainMenu.SetActive(false);
            howToPlay.SetActive(true);
            backToMainMenu = true;
        }
        else
        {
            pauseMenu.SetActive(false);
            howToPlay.SetActive(true);
            backToMainMenu = false;
        }

        scoreText.gameObject.SetActive(false);
    }

    public void Back()
    {
        if (backToMainMenu)
        {
            howToPlay.SetActive(false);
            mainMenu.SetActive(true);
        }
        else
        {
            howToPlay.SetActive(false);
            pauseMenu.SetActive(true);
            scoreText.gameObject.SetActive(true);
        }      
    }
}