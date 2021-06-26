using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; set; } // static singleton
    public TMP_Text numPoints, health;

    private int score, life, highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("VR Zombie Shooter Defender - HighScore", 0);
        life = 100;
        numPoints.text = score.ToString();
        health.text = life.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public int GetScore()
    {
        return score;
    }

    public void UpdateScore(int x)
    {
        score = score + x;
        numPoints.text = score.ToString();
    }

    public int GetLife()
    {
        return life;
    }

    public void TakeDamage(int x)
    {
        life = life - x;
        if (life <= 0)
        {
            PlayerPrefs.SetInt("VR Zombie Shooter Defender - FinalScore", score);
            if (score > highScore)
            {
                PlayerPrefs.SetInt("VR Zombie Shooter Defender - HighScore", score);
            }
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            health.text = life.ToString();
        }
    }
}
