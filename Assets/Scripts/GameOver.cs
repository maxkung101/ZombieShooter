using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text numPoints;

    private int score;

    // Start is called before the first frame update
    private void Start()
    {
        score = PlayerPrefs.GetInt("VR Zombie Shooter Defender - FinalScore", 0);
        numPoints.text = score.ToString();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - FinalScore", 0);
    }
}
