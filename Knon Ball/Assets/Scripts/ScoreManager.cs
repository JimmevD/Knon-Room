using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int curScore, highscore;
    private UIManager uiManager;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText, scoreText2, highScoreText2;
    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highScoreText.text = "Highscore: " + highscore;
        highScoreText2.text = "Highscore: " + highscore;
    }
    public void AddScore(int amount)
    {
        curScore += amount;
        scoreText.text = curScore.ToString();
        scoreText2.text = curScore.ToString();

        if (curScore > highscore)
        {
            highscore = curScore;
            PlayerPrefs.SetInt("highscore", highscore);
            highScoreText.text = "Highscore: " + highscore;
            highScoreText2.text = "Highscore: " + highscore;
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highscore);
        PlayerPrefs.Save();
    }

}
