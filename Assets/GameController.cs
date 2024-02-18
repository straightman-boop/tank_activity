using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public GameObject gameOverScreen;
    public GameObject phase2;

    public TextMeshProUGUI levelNumber;

    public AudioSource loseFX;
    public AudioSource bgFX;

    int shipsDestroyed = 0;

    bool level1Over = false;

    public AudioSource bossMusic;

    public int bossHealth = 100;
    public int playerDmg = 5;

    public Slider bossSlider;
    public GameObject healthBar;

    public bool isGamOver = false;
    public bool gameWin = false;

    public GameObject gameWinScreen;
    public AudioSource bossBGM;
    public AudioSource winSFX;
    public GameObject bossPrefab;

    public int shipsNum;

    public float speedPowerUp = 6f;
    public float speedDuration = 5f;
    float speedCooldown;
    public bool speedOn;

    public GameObject shield;
    float shieldDur = 7f;
    float shieldCool;

    bool isShield = false;

    public GameObject shield2;
    float shieldDur2 = 7f;
    float shieldCool2;

    bool isShield2 = false;

    private void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
        }

        else if (gameController != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bossSlider.minValue = 0;
        bossSlider.maxValue = bossHealth;
        bossSlider.value = bossHealth;

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            shipsNum = 1;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            shipsNum = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(shipsNum);

        if (isGamOver == false && shipsNum == 0)
        {
            GameOver();
        }

        if (shipsDestroyed == 5 && level1Over == false)
        {
            StartCoroutine(DelayStartLevel());
            level1Over = true;
        }

        //Debug.Log(bossHealth);

        if (bossHealth <= 0)
        {
            GameWin();
        }

        if (speedOn == true)
        {
            speedCooldown -= Time.deltaTime;
            if (speedCooldown <= 0)
            {
                speedOn = false;
            }
        }

        if (isShield == true)
        {
            shield.SetActive(true);
            shieldCool -= Time.deltaTime;

            if (shieldCool <= 0)
            {
                isShield = false;
                shield.SetActive(false);
            }
        }

        if (isShield2 == true)
        {
            shield2.SetActive(true);
            shieldCool2 -= Time.deltaTime;

            if (shieldCool2 <= 0)
            {
                isShield2 = false;
                shield2.SetActive(false);
            }
        }

    }

    public void ShieldPickUp()
    {
        isShield = true;
        shieldCool = shieldDur;
    }

    public void Shield2PickUp()
    {
        isShield2 = true;
        shieldCool2 = shieldDur2;
    }

    public void GameWin()
    {
        bossBGM.Stop();
        gameWin = true;
        gameWinScreen.SetActive(true);
        winSFX.Play();
        Destroy(bossPrefab);
    }

    public void GameOver()
    {
        isGamOver = true;
        bgFX.Stop();
        gameOverScreen.SetActive(true);
        loseFX.Play();

        EnemySpawnerScript.enemySpawner.enabled = false;
        if (level1Over == true)
        {
            BossSpawnerScript.bossSpawnerScript.enabled = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShipDestroyed()
    {
        shipsDestroyed++;
    }

    void StartLevel2()
    {
        Debug.Log("LEVEL 2 HAS BEGUN!");
        phase2.SetActive(true);

        EnemySpawnerScript.enemySpawner.enabled = false;
        healthBar.SetActive(true);
        bgFX.Stop();
        bossMusic.Play();
    }

    IEnumerator DelayStartLevel()
    {
        yield return new WaitForSeconds(1);
        levelNumber.text = " ";
        yield return new WaitForSeconds(5);
        levelNumber.text = "Level 2";
        yield return new WaitForSeconds(1);
        StartLevel2();
    }

    public void DecrementBossHealth()
    {
        bossHealth -= playerDmg;
        bossSlider.value = bossHealth;
    }

    public void IncreaseSpeed(string player)
    {
        if (player == "Player1")
        {
            PlayerMovement.playerController.speed = speedPowerUp;
            speedOn = true;
            speedDuration = speedCooldown;
        }

        if (player == "Player2")
        {
            Player2Movement.playerController.speed = speedPowerUp;
            speedOn = true;
            speedDuration = speedCooldown;
        }
    }

}
