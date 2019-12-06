using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip selectSound;
    public AudioClip clickSound;
    private AudioSource buttonAudio;

    private bool mouseEnter;

    void Start()
    {
        buttonAudio = GetComponent<AudioSource>();
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

    public void OpenLevelSelectMenu()
    {
        for(int i=0; i < transform.GetChildCount(); i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
