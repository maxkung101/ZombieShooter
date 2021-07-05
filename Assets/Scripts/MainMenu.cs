using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] themeList, mainUI, confirmUI;
    public GameObject cycleLeft, cycleRight;
    public TMP_Text record;

    private int index, highScore;
    private float pauseTimer, pauseTimer2, endPause, endPause2;
    private bool timeToConfirm, timeToMain, cyclingLeft, cyclingRight;

    // Start is called before the first frame update
    private void Start()
    {
        pauseTimer = 0;
        pauseTimer2 = 0;
        endPause = 1;
        endPause2 = 0.5f;
        timeToConfirm = false;
        timeToMain = false;
        cyclingLeft = false;
        cyclingRight = false;
        ConfirmToggleOff();
        // We toggle off their renderer.
        foreach (GameObject go in themeList)
        {
            go.SetActive(false);
        }

        // We toggle on the playerpref index.
        index = PlayerPrefs.GetInt("VR Zombie Shooter Defender - ThemeSelected", 1);
        themeList[index].SetActive(true);

        // We toggle on the high score.
        highScore = PlayerPrefs.GetInt("VR Zombie Shooter Defender - HighScore", 0);
        record.text = highScore.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeToConfirm)
        {
            if (pauseTimer >= endPause)
            {
                timeToConfirm = false;
                pauseTimer = 0;
                ConfirmToggleOn();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        if (timeToMain)
        {
            if (pauseTimer >= endPause)
            {
                timeToMain = false;
                pauseTimer = 0;
                MainToggleOn();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        if (cyclingLeft)
        {
            if (pauseTimer2 >= endPause2)
            {
                cyclingLeft = false;
                pauseTimer2 = 0;
                ToggleLeft();
                cycleLeft.GetComponent<BoxCollider>().enabled = true;
                cycleRight.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                pauseTimer2 += Time.deltaTime;
            }
        }

        if (cyclingRight)
        {
            if (pauseTimer2 >= endPause2)
            {
                cyclingRight = false;
                pauseTimer2 = 0;
                ToggleRight();
                cycleLeft.GetComponent<BoxCollider>().enabled = true;
                cycleRight.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                pauseTimer2 += Time.deltaTime;
            }
        }
    }

    public void HitLeft()
    {
        cycleLeft.GetComponent<BoxCollider>().enabled = false;
        cycleRight.GetComponent<BoxCollider>().enabled = false;
        cyclingLeft = true;
    }

    public void HitRight()
    {
        cycleLeft.GetComponent<BoxCollider>().enabled = false;
        cycleRight.GetComponent<BoxCollider>().enabled = false;
        cyclingRight = true;
    }

    private void ToggleLeft()
    {
        // Toggle off the current model.
        themeList[index].SetActive(false);

        index -= 1;
        if (index < 0)
        {
            index = themeList.Length - 1;
        }

        // Toggle on the new model.
        themeList[index].SetActive(true);
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - ThemeSelected", index);
    }

    private void ToggleRight()
    {
        // Toggle off the current model.
        themeList[index].SetActive(false);

        index += 1;
        if (index > themeList.Length - 1)
        {
            index = 0;
        }

        // Toggle on the new model.
        themeList[index].SetActive(true);
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - ThemeSelected", index);
    }

    public void ResetHighScore()
    {
        highScore = 0;
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - HighScore", highScore);
        record.text = highScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void MainToggleOn()
    {
        foreach (GameObject go in mainUI)
        {
            go.SetActive(true);
        }
    }

    public void MainToggleOff()
    {
        foreach (GameObject go in mainUI)
        {
            go.SetActive(false);
        }
        timeToConfirm = true;
    }

    private void ConfirmToggleOn()
    {
        foreach (GameObject go in confirmUI)
        {
            go.SetActive(true);
        }
    }

    public void ConfirmToggleOff()
    {
        foreach (GameObject go in confirmUI)
        {
            go.SetActive(false);
        }
        timeToMain = true;
    }
}