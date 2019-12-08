using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckPointChecker : MonoBehaviour
{
    private PlayerController player;
    public CheckPoint lastCheckPoint;

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreHighlightText;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI parText;
    public TextMeshProUGUI parHighlightText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        foreach (GameObject test in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {
            if (test.GetComponent<CheckPoint>().order == 1)
            {
                lastCheckPoint = test.GetComponent<CheckPoint>();
                foreach (GameObject secondTest in GameObject.FindGameObjectsWithTag("CheckPoint"))
                {
                    if (secondTest.GetComponent<CheckPoint>().order == lastCheckPoint.order + 1)
                    {
                        //turn on next checkpoint
                        secondTest.GetComponent<CheckPoint>().Toggle();
                    }
                }
            }
        }
        transform.position = lastCheckPoint.pos;
        parText.text = "Par: " + lastCheckPoint.nextPar;
        parHighlightText.text = "Par: " + lastCheckPoint.nextPar;

        player.transform.position = lastCheckPoint.pos;
        player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            HighScoreText.text = "HighScore " + PlayerPrefs.GetInt("HighScore01", 0);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            HighScoreText.text = "HighScore " + PlayerPrefs.GetInt("HighScore02", 0);
        }
    }


    public void Check(Collider other)
    {
        //set score and put the jump count back at 0
        score += lastCheckPoint.nextPar - player.totalJumps;
        player.setJumps(0);

        //Makes the new checkpoint the current one and activates the next one in the order
        lastCheckPoint = other.GetComponent<CheckPoint>();

        parText.text = "Par: " + lastCheckPoint.nextPar;
        parHighlightText.text = "Par: " + lastCheckPoint.nextPar;

        scoreText.text = "Score: " + score;
        scoreHighlightText.text = "Score: " + score;


        foreach (GameObject test in GameObject.FindGameObjectsWithTag("CheckPoint"))
        {
            if (test.GetComponent<CheckPoint>().order == lastCheckPoint.order + 1)
            {
                //turn next checkpoint on
                test.GetComponent<CheckPoint>().Toggle();
            }
            
        }
        if (lastCheckPoint.nextPar == 0)
        {
            //If this is the last checkpoint load level select and set highscore
            if (score > PlayerPrefs.GetInt("HighScore01", 0) && SceneManager.GetActiveScene().buildIndex == 1)
            {
                PlayerPrefs.SetInt("HighScore01", score);
                //PlayerPrefs.SetInt("LastLevel", 1);
            }
            if (score > PlayerPrefs.GetInt("HighScore02", 0) && SceneManager.GetActiveScene().buildIndex == 2)
            {
                PlayerPrefs.SetInt("HighScore02", score);
                //PlayerPrefs.SetInt("LastLevel", 2);
            }
            StartCoroutine(EndLevel());
        }

    }

    public void OpenMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public IEnumerator EndLevel()
    {
        Time.timeScale = .5f;
        yield return new WaitForSeconds(1f);
        OpenMenu();
    }
}
