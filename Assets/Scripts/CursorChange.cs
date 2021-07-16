using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CursorChange : MonoBehaviour
{
    public int index;

    public void ChangeColor()
    {
        PlayerPrefs.SetInt("VR Zombie Shooter Defender - SelectedColor", index);
        SceneManager.LoadScene("MainMenu");
    }
}
