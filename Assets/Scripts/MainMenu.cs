using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject[] themeList, mainUI, confirmUI;
    public GameObject cycleLeft, cycleRight, resetBtn, yesBtn, noBtn, musicBtn, pointerGUI, pointerBtn, pointerBackBtn, languageGUI, languageBtn, languageBackBtn, canvas;
    public TMP_Text record, musicStatus, canvasText;
    public string[] on_txt, off_txt, canvasPoint_txt, canvasLang_txt;

    private int index, highScore, musicIsOn, id;
    private float pauseTimer, pauseTimer2, pauseTimer3, endPause, endPause2;
    private bool timeToConfirm, timeToMain, cyclingLeft, cyclingRight, musicActivation, timeToPointer, timeFromPointer, timeToLanguage, timeFromLanguage;
    private string onText, offText;

    // Use this for initialization
    private void Awake()
    {
        Application.targetFrameRate = 10;
    }

    // Start is called before the first frame update
    private void Start()
    {
        id = PlayerPrefs.GetInt("VR Zombie Shooter Defender - SelectedLanguage", 0);
        onText = on_txt[id];
        offText = off_txt[id];

        yesBtn.GetComponent<BoxCollider>().enabled = false;
        noBtn.GetComponent<BoxCollider>().enabled = false;
        pointerBackBtn.GetComponent<BoxCollider>().enabled = false;
        languageBackBtn.GetComponent<BoxCollider>().enabled = false;
        pauseTimer = 0;
        pauseTimer2 = 0;
        pauseTimer3 = 0;
        endPause = 1;
        endPause2 = 0.5f;
        timeToConfirm = false;
        timeToMain = false;
        cyclingLeft = false;
        cyclingRight = false;
        musicActivation = false;
        timeToPointer = false;
        timeFromPointer = false;
        timeToLanguage = false;
        timeFromLanguage = false;
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

        // We toggle on the in game music.
        musicIsOn = PlayerPrefs.GetInt("VR Zombie Shooter Defender - Music", 0);
        if (musicIsOn == 0)
        {
            musicStatus.text = offText;
        }
        else
        {
            musicStatus.text = onText;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Turn on the confirm GUI.
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

        // Turn off the confirm GUI.
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

        // Turn on the pointer GUI.
        if (timeToPointer)
        {
            if (pauseTimer >= endPause)
            {
                timeToPointer = false;
                pauseTimer = 0;
                PointerToggleOn();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        // Turn off the pointer GUI.
        if (timeFromPointer)
        {
            if (pauseTimer >= endPause)
            {
                timeFromPointer = false;
                pauseTimer = 0;
                MainToggleOn2();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        // Turn on the language GUI.
        if (timeToLanguage)
        {
            if (pauseTimer >= endPause)
            {
                timeToLanguage = false;
                pauseTimer = 0;
                LanguageToggleOn();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        // Turn off the language GUI.
        if (timeFromLanguage)
        {
            if (pauseTimer >= endPause)
            {
                timeFromLanguage = false;
                pauseTimer = 0;
                MainToggleOn3();
            }
            else
            {
                pauseTimer += Time.deltaTime;
            }
        }

        // Cycle theme left
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

        // Cycle theme right
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

        // Toggle in-game music
        if (musicActivation)
        {
            if (pauseTimer3 >= endPause2)
            {
                musicActivation = false;
                pauseTimer3 = 0;
                ToggleMusic();
                musicBtn.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                pauseTimer3 += Time.deltaTime;
            }
        }
    }

    public void HitMusic()
    {
        musicBtn.GetComponent<BoxCollider>().enabled = false;
        musicActivation = true;
    }

    private void ToggleMusic()
    {
        if (musicIsOn == 0)
        {
            PlayerPrefs.SetInt("VR Zombie Shooter Defender - Music", 1);
            musicIsOn = 1;
            musicStatus.text = onText;
        }
        else
        {
            PlayerPrefs.SetInt("VR Zombie Shooter Defender - Music", 0);
            musicIsOn = 0;
            musicStatus.text = offText;
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

    private void MainToggleOn()
    {
        foreach (GameObject go in confirmUI)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in mainUI)
        {
            go.SetActive(true);
        }
        resetBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void MainToggleOff()
    {
        timeToConfirm = true;
        resetBtn.GetComponent<BoxCollider>().enabled = false;
    }

    private void ConfirmToggleOn()
    {
        foreach (GameObject go in mainUI)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in confirmUI)
        {
            go.SetActive(true);
        }
        yesBtn.GetComponent<BoxCollider>().enabled = true;
        noBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void ConfirmToggleOff()
    {
        timeToMain = true;
        yesBtn.GetComponent<BoxCollider>().enabled = false;
        noBtn.GetComponent<BoxCollider>().enabled = false;
    }

    private void MainToggleOn2()
    {
        pointerGUI.SetActive(false);
        canvas.SetActive(false);
        foreach (GameObject go in mainUI)
        {
            go.SetActive(true);
        }
        pointerBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void MainToggleOff2()
    {
        timeToPointer = true;
        pointerBtn.GetComponent<BoxCollider>().enabled = false;
    }

    private void PointerToggleOn()
    {
        foreach (GameObject go in mainUI)
        {
            go.SetActive(false);
        }
        pointerGUI.SetActive(true);
        canvasText.text = canvasPoint_txt[id];
        canvas.SetActive(true);
        pointerBackBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void PointerToggleOff()
    {
        timeFromPointer = true;
        pointerBackBtn.GetComponent<BoxCollider>().enabled = false;
    }

    private void MainToggleOn3()
    {
        languageGUI.SetActive(false);
        canvas.SetActive(false);
        foreach (GameObject go in mainUI)
        {
            go.SetActive(true);
        }
        languageBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void MainToggleOff3()
    {
        timeToLanguage = true;
        languageBtn.GetComponent<BoxCollider>().enabled = false;
    }

    private void LanguageToggleOn()
    {
        foreach (GameObject go in mainUI)
        {
            go.SetActive(false);
        }
        languageGUI.SetActive(true);
        canvasText.text = canvasLang_txt[id];
        canvas.SetActive(true);
        languageBackBtn.GetComponent<BoxCollider>().enabled = true;
    }

    public void LanguageToggleOff()
    {
        timeFromLanguage = true;
        languageBackBtn.GetComponent<BoxCollider>().enabled = false;
    }
}