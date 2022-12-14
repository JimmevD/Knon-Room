using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject mainMenu, pauseMenu, howToPlay, gameOver, soundIcon, sliders;
    private bool backToMainMenu;

    [SerializeField] private GameObject[] howToPlayMenus;
    private int currentHowToPlayMenu;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !mainMenu.activeInHierarchy && !gameOver.activeInHierarchy)
        {
            PauseAndResume();
        }
    }

    public void Play()
    {
        scoreText.gameObject.SetActive(true);
        soundIcon.SetActive(false);
        sliders.SetActive(false);
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void PauseAndResume()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            soundIcon.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pauseMenu.SetActive(false);
            soundIcon.SetActive(false);
            sliders.SetActive(false);
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
        soundIcon.SetActive(false);
        sliders.SetActive(false);
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
        soundIcon.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        gameOver.SetActive(false);
        soundIcon.SetActive(true);
        mainMenu.SetActive(true);
    }


    public void ScrollHowToPlayMenus(bool isRight)
    {
        howToPlayMenus[currentHowToPlayMenu].SetActive(false);

        if (isRight)
        {
            if (currentHowToPlayMenu != howToPlayMenus.Length -1)
            {          
                currentHowToPlayMenu++;
            }
            else
            {
                currentHowToPlayMenu = 0;
            }
        }
        else
        {
            if (currentHowToPlayMenu != 0)
            {
                currentHowToPlayMenu--;
            }
            else
            {
                currentHowToPlayMenu = howToPlayMenus.Length - 1;
            }          
        }

        howToPlayMenus[currentHowToPlayMenu].SetActive(true);
    }
}
