using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;


public class PlayManager : MonoBehaviour
{
    public GameObject GameoverPanel;
    public GameObject PlayerObj;
    public Text currentScoreText;
    public Text bestScoreText;
    public int dead;
    public static PlayManager instance;

    public int currentScore = 0;

    AudioSource audioSource;
    public AudioClip itemClip;
    public AudioClip jumpClip;
    public AudioClip deadClip;
    public bool isConnectedInGooglePlayService;

    public static int nosound;

    public PlayFabManager playFabManager;
    [HideInInspector] public static int counter;

private void Awake() {
    instance=this;
}
    void Start()
    {
        instance=this;
        gameOver();
        audioSource = GetComponent<AudioSource>();

        Time.timeScale = 1f;
        currentScoreText.text = currentScore.ToString();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }



    void Update()
    {
        currentScore = (int)PlayerObj.transform.position.y / 2;
        currentScoreText.text = currentScore.ToString();

        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            if (counter * 2 < currentScore)
            {
                playFabManager.SetUserData();
                playFabManager.SendCheatersLeaderboard(currentScore);
            }
            else
            {
                if (PlayerPrefs.GetInt("Cheater", 0) != 1)
                    playFabManager.SendLeaderboard(currentScore);
            }

            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }

    }


    public void GameOver()
    {
        StartCoroutine(GameOverCoroutine());
    }


    IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        Time.timeScale = 0.005f;
        Debug.LogError("remove" + PlayerPrefs.GetInt("removeads").ToString());
        if (PlayerPrefs.GetInt("gameoveroff",0)==1)
        {
                    Time.timeScale=0;
        GameoverPanel.SetActive(false);
        }
        else
        {
                    Time.timeScale=1;
        GameoverPanel.SetActive(true);
        ChangeColorToWhite();
        }
        yield break;

    }
    public void screenshot()
    {
        GameoverPanel.SetActive(true);
        ChangeColorToWhite();
    }

    public void gameOver()
    {
        PlayerPrefs.SetInt("dead", PlayerPrefs.GetInt("dead", 0) + 1);

        if (PlayerPrefs.GetInt("dead") >= dead && PlayerPrefs.GetInt("removeads", 0) == 0)
        {
            PlayerPrefs.SetInt("dead", 0);
            AdsManager.instance.ShowRewardedVideo();
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ChangeColorToWhite()
    {
        currentScoreText.color = Color.white;
        bestScoreText.color = Color.white;
    }


    public void PlayDeadClip()
    {

        audioSource.PlayOneShot(deadClip);

    }
    public void PlayItemClip()
    {

        audioSource.PlayOneShot(itemClip);

    }
    public void PlayJumpClip()
    {

        audioSource.PlayOneShot(jumpClip);
    }
}
