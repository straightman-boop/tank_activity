using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsScript : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static PlayerStatsScript playerStats;
    int score;

    public int playerLife;
    public int maxLife;

    public Image[] life;
    public Sprite fullLife;
    public Sprite emptyLife;

    void Awake()
    {
        if (playerStats == null)
        {
            playerStats = this;
        }

        else if (playerStats != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
    }

    public void UpdateScore()
    {
        score += 100;
        string scoreStr = string.Format("{0:0000000}", score);
        scoreText.text = "Score: " + scoreStr;

    }

    void UpdateLife()
    {
        if (playerLife > maxLife)
        {
            playerLife = maxLife;
        }

        for (int i = 0; i < life.Length; i++)
        {

            if (i < playerLife)
            {
                life[i].sprite = fullLife;
            }
            else
            {
                life[i].sprite = emptyLife;
            }

            if (i < maxLife)
            {
                life[i].enabled = true;
            }
            else
            {
                life[i].enabled = false;
            }

        }
    }

}
