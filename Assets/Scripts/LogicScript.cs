using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text textScore;
    public Text HighScoreText;
    public GameObject GameOverScreen;
    public GameObject Pillar;
    private PillarMove ResetPillarSpeed;
    public GameObject Back;
    private BackgroundMove ResetBackSpeed;

    public GameObject Work;
    private DaVinciWorksScript ResetWorkSpeed;

    Transform Work1; // child 1
    Transform Work2; // child 2
    Transform Work3; // child 3

    private BoxCollider2D Box1;
    private BoxCollider2D Box2;
    private BoxCollider2D Box3;

    void Start()
    {
        ResetPillarSpeed = Pillar.GetComponent<PillarMove>();
        ResetBackSpeed = Back.GetComponent<BackgroundMove>();
        ResetWorkSpeed = Work.GetComponent<DaVinciWorksScript>();

        Work1 = Work.transform.Find("FirstWork");
        Work2 = Work.transform.Find("SecondWork");
        Work3 = Work.transform.Find("ThirdWork");

        Box1 = Work1.GetComponent<BoxCollider2D>();
        Box2 = Work2.GetComponent<BoxCollider2D>();
        Box3 = Work3.GetComponent<BoxCollider2D>();

    }
    void Update()
    {
        HighScore();
        UpdateHighScoreText();
    }

    [ContextMenu("Increase Score by 1")]
    public void addScore(int ScoreToAdd)
    {
        playerScore += ScoreToAdd;
        textScore.text = playerScore.ToString();
    }

    public void restarGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quitgame()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        ResetPillarSpeed.movespeed = 15;
        ResetPillarSpeed.Safe = true;
        ResetBackSpeed.movespeed = 5f;
        ResetWorkSpeed.movespeed = 10;
        Box1.isTrigger = false;
        Box2.isTrigger = false;
        Box3.isTrigger = false;
    }

    void HighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }
    }

    void UpdateHighScoreText()
    {
        HighScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

}
