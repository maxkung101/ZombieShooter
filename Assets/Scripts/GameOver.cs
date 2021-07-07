using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text numPoints;
    public GameObject highScoreDescription;

    private int score, isNewScore;

    // Start is called before the first frame update
    private void Start()
    {
        score = PlayerPrefs.GetInt("VR Zombie Shooter Defender - FinalScore", 0);
        numPoints.text = score.ToString();
        highScoreDescription.SetActive(false);
        isNewScore = PlayerPrefs.GetInt("VR Zombie Shooter Defender - IsNewScore", 0);
        if (isNewScore == 1)
        {
            highScoreDescription.SetActive(true);
            PlayerPrefs.SetInt("VR Zombie Shooter Defender - IsNewScore", 0);
        }
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - FinalScore", 0);
    }
}
