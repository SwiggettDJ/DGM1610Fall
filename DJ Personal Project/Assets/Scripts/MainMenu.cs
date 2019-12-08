using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public AudioClip selectSound;
    public AudioClip clickSound;
    private AudioSource buttonAudio;

    private MainMenu menuToOpen;

    private bool mouseEnter;

    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void SelectSound()
    {
        buttonAudio.PlayOneShot(selectSound, 1);
    }
    public void ClickSound()
    {
        buttonAudio.PlayOneShot(clickSound, 1);
    }

    public void PlayLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SwitchMenu()
    {
        if (name == "Main Menu")
        {
            menuToOpen = GameObject.Find("Level Select Menu").GetComponent<MainMenu>();
        }
        if (name == "Level Select Menu")
        {
            menuToOpen = GameObject.Find("Main Menu").GetComponent<MainMenu>();
        }

        for (int i=0; i < transform.GetChildCount(); i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < menuToOpen.transform.GetChildCount(); i++)
        {
            menuToOpen.transform.GetChild(i).gameObject.SetActive(true);
        }
        if (name == "Main Menu")
        {
            GameObject.Find("HighScore 01").GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetInt("HighScore01");
            GameObject.Find("HighScore 02").GetComponent<TextMeshProUGUI>().text = "HighScore: " + PlayerPrefs.GetInt("HighScore02");
        }
    }
}
