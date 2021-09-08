using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float power = 40;
    private float rotationSpeed = 120;
    private float angleOfRotation = 5;

    public GameObject setting;
    public GameObject ItemEffectPrefab;
    public GameObject DeadEffectPrefab;
    public GameObject shieldObj;
    public GameObject shieldFadeOutObj;
    public GameObject startPanel;
    public GameObject tabToStart;

    public ParticleSystem engine;
    public ParticleSystem powerJumpParticle;

    [Space(10)]
    public Scrollbar scrollBarPower;
    public Scrollbar scrollRotationSpeed;
    public Scrollbar scrollAngleOfRotation;

    [Space(10)]
    public float specialJumpPower = 25f;

    [HideInInspector]
    public bool isWaiting = true;
    bool isJumping = false;
    float angle = 0;
    float hueValue = 0;

    Rigidbody2D rigid;

    AudioSource audioSource;

    void Start()
    {
        powerJumpParticle.Stop();

        hueValue = Random.Range(0, 1f);
        ChangeBackgroundColor();

        audioSource = GetComponent<AudioSource>();

        rigid = GetComponent<Rigidbody2D>();
        rigid.isKinematic = true;
        //if (PlayerPrefs.GetFloat("Power1") > 1)
        scrollBarPower.value = (PlayerPrefs.GetFloat("Power1", 7) - 1) / 9;
        scrollRotationSpeed.value = (PlayerPrefs.GetFloat("RotationSpeed1", 3) - 1) / 9;
        scrollAngleOfRotation.value = (PlayerPrefs.GetFloat("AngleOfRotation1", 3) - 1) / 9;




















        //else
        //  PlayerPrefs.SetFloat("Power1", 1);
        /*
        if (PlayerPrefs.GetFloat("RotationSpeed1") > 1)
            scrollRotationSpeed.value = (PlayerPrefs.GetFloat("RotationSpeed1") - 1) / 9;
        else
            PlayerPrefs.SetFloat("RotationSpeed1", 3);

        if (PlayerPrefs.GetFloat("AngleOfRotation1") > 1)
            scrollAngleOfRotation.value = (PlayerPrefs.GetFloat("AngleOfRotation1") - 1) / 9;
        else
            PlayerPrefs.SetFloat("AngleOfRotation1", 3);
        */
        rotationSpeed = rotationSpeed + PlayerPrefs.GetFloat("RotationSpeed1") * 10;

    }

    void Update()
    {
        RotatePlayer();

        DeceleratePlayer();

        if (transform.position.y < Camera.main.transform.position.y - DisplayManager.DISPLAY_HEIGHT / 2)
        {
            GameOver();
        }
    }

    public void InForce()
    {
        PlayManager.counter++;

        tabToStart.SetActive(false);

        if (isWaiting)
        {
            isWaiting = false;
            rigid.isKinematic = false;
            setting.SetActive(false);
        }

        GameObject.Find("Manager").GetComponent<PlayManager>().PlayJumpClip();
        AcceleratePlayer(angle, power * (PlayerPrefs.GetFloat("Power1", 3) / 4));
        ChangeBackgroundColor();
    }

    void RotatePlayer()
    {
        if (isWaiting == true) return;

        if (isJumping == false)
        {
            if (PlayerPrefs.GetInt("FixAngle", 0) == 1)
            {
                angle = 0;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else if (PlayerPrefs.GetInt("FixAngle", 0) == 2)
            {
                angle = 65;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 65));
            }
            else
            {
                angle += rotationSpeed * Time.deltaTime;
                if (angle > angleOfRotation * PlayerPrefs.GetFloat("AngleOfRotation1") + 70)
                {
                    angle = angleOfRotation * PlayerPrefs.GetFloat("AngleOfRotation1") + 70;
                    rotationSpeed *= -1;
                }
                if (angle < -angleOfRotation * PlayerPrefs.GetFloat("AngleOfRotation1") - 70)
                {
                    angle = -angleOfRotation * PlayerPrefs.GetFloat("AngleOfRotation1") - 70;
                    rotationSpeed *= -1;
                }
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        }
    }

    void AcceleratePlayer(float ang, float power)
    {
        Vector3 direction = Quaternion.AngleAxis(ang, Vector3.forward) * Vector3.up;
        rigid.velocity = direction * power;

        engine.Play();
    }

    void ChangeBackgroundColor()
    {
        hueValue += 0.002f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.5f, 0.7f);
    }


    void DeceleratePlayer()
    {
        if (rigid.velocity.magnitude > 0.03f)
        {
            rigid.velocity = rigid.velocity * 0.63f;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Obstacle")
        {
            GameOver();
        }

        if (other.gameObject.tag == "Item")
        {
            StartCoroutine(PowerJump());
            Destroy(Instantiate(ItemEffectPrefab, transform.position, Quaternion.identity), 1.0f);
            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

    void GameOver()
    {

        gameObject.SetActive(false);

        GameObject.Find("Manager").GetComponent<PlayManager>().PlayDeadClip();
        Destroy(Instantiate(DeadEffectPrefab, transform.position, Quaternion.identity), 1.5f);
        GameObject.Find("Manager").GetComponent<PlayManager>().GameOver();
        tabToStart.SetActive(true);

    }


    IEnumerator PowerJump()
    {
        if (gameObject.activeSelf == false) yield break;

        isJumping = true;

        angle = 0;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obj in objects)
        {
            if (obj.name == "Rectangle") obj.GetComponent<BoxCollider2D>().enabled = false;
            if (obj.name == "Square") obj.GetComponent<BoxCollider2D>().enabled = false;
        }
        Debug.LogWarning("Нахуярил");

        GameObject.Find("Manager").GetComponent<PlayManager>().PlayItemClip();
        AcceleratePlayer(0, specialJumpPower);

        powerJumpParticle.Play();
        shieldObj.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        if (PlayerPrefs.GetInt("force", 0) == 1)
        {
            Time.timeScale = 0;
        }
        yield return new WaitForSeconds(0.2f);
        isJumping = false;


        yield return new WaitForSeconds(1.0f);

        GameObject[] objectss = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obj in objectss)
        {
            if (obj.name == "Rectangle") obj.GetComponent<BoxCollider2D>().enabled = true;
            if (obj.name == "Square") obj.GetComponent<BoxCollider2D>().enabled = true;
        }
        Debug.LogWarning("разхуярил");

        shieldObj.SetActive(false);

        shieldFadeOutObj.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        shieldFadeOutObj.SetActive(false);

        yield break;
    }
}
