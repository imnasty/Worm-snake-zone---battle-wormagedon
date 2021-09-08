using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Autoscreen : MonoBehaviour
{
    public ObstacleManager obstacleManager;
    public GameObject prefab;
    public GameObject panelLoading;
    public GameObject setting;
    public GameObject tabtostart;
    public GameObject leaderboard;
    public GameObject Screenpanel1;
    public GameObject Screenpanel2;
    public GameObject Screenpanel3;
    public GameObject Screenpanel4;
    public GameObject Screenpanel5;
    public GameObject Screenpanel6;
    public Rigidbody2D player;
    public Player playersc;
    public float Delay;
    public PlayManager playManager;
    public GameObject gameoverpanel;
    public RectTransform left;
    public Transform playerpos;
    private bool lockin = false;
    public RectTransform right;
    // Start is called before the first frame update
    private void Update()
    {
      //  Debug.LogWarning("Left" + left.position.x.ToString());
     //   Debug.LogWarning("Right" + right.position.x.ToString());
       // Debug.LogWarning(playerpos.position.x.ToString());
        if (lockin == true)
        {
            playerpos.position = new Vector3(0, playerpos.position.y, playerpos.position.z);
        }
    }
    public void screen()
    {
        StartCoroutine(Screenwait());
    }
    public IEnumerator Screenwait()
    {
        PlayerPrefs.SetFloat("Delay", 15f);
        Delay = PlayerPrefs.GetFloat("Delay", 15f) * 30;
        Debug.LogError(Delay.ToString());
        yield return StartCoroutine(FirstScreen());
        Debug.LogWarning("1delay");
        PlayerPrefs.SetInt("loadsscreen", 1);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("1delay end");
        yield return StartCoroutine(TwoScreen());
        Debug.LogWarning("2delay");
        PlayerPrefs.SetInt("loadsscreen", 2);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("2delay end");
        yield return StartCoroutine(ThreeScreen());
        Debug.LogWarning("3delay");
        PlayerPrefs.SetInt("loadsscreen", 3);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("3delay end");
        yield return StartCoroutine(FourScreen());
        Debug.LogWarning("4delay");
        PlayerPrefs.SetInt("loadsscreen", 4);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("4delay end");
        yield return StartCoroutine(FiveScreen());
        Debug.LogWarning("5delay");
        PlayerPrefs.SetInt("loadsscreen", 5);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("5delay end");
        yield return StartCoroutine(SixScreen());
        Debug.LogWarning("6delay");
        PlayerPrefs.SetInt("loadsscreen", 6);
        yield return new WaitForSecondsRealtime(Delay);
        Debug.LogWarning("6delay end");
        
    }

    public IEnumerator FirstScreen()
    {
        Debug.LogError("1 kor");
        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        // panelLoading.SetActive(true);
        yield return new WaitForSeconds(0);
        Debug.LogError("1 kor end");
    }
    public IEnumerator TwoScreen()
    {
        Debug.Log("2 kor");
        yield return new WaitForSeconds(10);
        PlayerPrefs.SetInt("FixAngle", 1);
        setting.SetActive(false);
        tabtostart.SetActive(false);
        leaderboard.SetActive(false);
        Screenpanel2.SetActive(true);
        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        panelLoading.SetActive(true);
        yield return new WaitForSeconds(0);
        setting.SetActive(true);
        tabtostart.SetActive(true);
        leaderboard.SetActive(true);
        Screenpanel2.SetActive(false);
        PlayerPrefs.SetInt("FixAngle", 0);
        Debug.LogError("2 kor end");
    }
    public IEnumerator ThreeScreen()
    {
        Debug.Log("3 kor");
        setting.SetActive(false);
        tabtostart.SetActive(false);
        leaderboard.SetActive(false);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(true);
        player.gravityScale = 0f;
        yield return new WaitForSeconds(0);
        playersc.InForce();
        PlayerPrefs.SetInt("FixAngle", 2);
        Debug.LogError(PlayerPrefs.GetInt("FixAngle", 0).ToString());
        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        //  yield return new WaitForSeconds(450);
        panelLoading.SetActive(true);
        setting.SetActive(true);
        tabtostart.SetActive(true);
        leaderboard.SetActive(true);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(false);
        // player.gravityScale = 0.2f;
        yield return new WaitForSeconds(0);
        PlayerPrefs.SetInt("FixAngle", 0);
        // player.gravityScale=0.2f;
        Debug.LogError("3 kor end");
    }
    public IEnumerator FourScreen()
    {
        Debug.Log("4 kor");
        PlayerPrefs.SetInt("FixAngle", 1);
        setting.SetActive(false);
        tabtostart.SetActive(false);
        leaderboard.SetActive(false);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(false);
        Screenpanel4.SetActive(true);
        player.gravityScale = 0f;
        PlayerPrefs.SetInt("force", 1);
        yield return new WaitForSecondsRealtime(10);
        playersc.InForce();

        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        PlayerPrefs.SetInt("force", 0);
        Time.timeScale = 1;
        PlayerPrefs.SetInt("FixAngle", 1);
        setting.SetActive(true);
        tabtostart.SetActive(true);
        leaderboard.SetActive(true);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(false);
        Screenpanel4.SetActive(false);
        lockin = true;

        Debug.Log("4 kor end");
    }
    public IEnumerator FiveScreen()
    {
        PlayerPrefs.SetInt("feedbackoff", 1);
        Debug.Log("5 kor");
        lockin = false;
        PlayerPrefs.SetInt("FixAngle", 1);
        PlayerPrefs.SetInt("gameoveroff", 1);
        setting.SetActive(false);
        tabtostart.SetActive(false);
        leaderboard.SetActive(false);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(false);
        Screenpanel4.SetActive(false);
        Screenpanel5.SetActive(true);
        player.gravityScale = 0f;
        yield return new WaitForSecondsRealtime(0);
        playersc.InForce();

        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        PlayerPrefs.SetInt("FixAngle", 0);
        PlayerPrefs.SetInt("gameoveroff", 0);
        setting.SetActive(false);
        tabtostart.SetActive(false);
        leaderboard.SetActive(false);
        Screenpanel2.SetActive(false);
        Screenpanel3.SetActive(false);
        Screenpanel4.SetActive(false);
        Screenpanel5.SetActive(false);
        lockin = true;
        Debug.Log("5 kor end");
        //if (PlayerPrefs.GetInt("gameoveroff",0)==1)
    }
    public IEnumerator SixScreen()
    {
        Debug.Log("6 kor");
        PlayManager.instance.screenshot();
        WebDavSTA.instance.ProverkaLocalFolder();
        yield return StartCoroutine(ScreenshotHandler.instance.Screenwait());
        yield return new WaitForSecondsRealtime(0);
        lockin = false;
        Debug.Log("6 kor end");
        PlayerPrefs.SetInt("feedbackoff", 0);
    }
    public void InMode()
    {
        PlayerPrefs.SetInt("AutoScreen", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }public void modescreen()
    {
        PlayerPrefs.SetString("console", "true");
        PlayerPrefs.SetString("screen", "true");
    }
    public void OutMode()
    {
        PlayerPrefs.SetInt("AutoScreen", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void timesscale()
    {
        PlayerPrefs.SetInt("force", 1);

    }
    public void outpause()
    {
        Time.timeScale = 1;
    }
    // Update is called once per frame

}
