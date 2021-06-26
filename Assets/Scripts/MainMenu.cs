using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] themeList, mainUI, confirmUI;
    public TMP_Text record;

    private int index, highScore;

    // Start is called before the first frame update
    private void Start()
    {
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

    public void ToggleLeft()
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

    public void ToggleRight()
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

    public void MainToggleOn()
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
    }

    public void ConfirmToggleOn()
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
    }
}