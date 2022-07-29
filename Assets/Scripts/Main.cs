using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{

    public GameObject spinner, player, trigger, explosion;
    public TMP_Text counter, highscore, countdown, result, newHighscore;
    public Button restart, quit;
    public GameObject mainCam, secondCam;

    private int highscoreValue;

    private IEnumerator countdownTimer;

    void Start()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscoreValue = PlayerPrefs.GetInt("highscore");
        } else
        {
            highscoreValue = 0;
        }
        highscore.text = "TO BEAT: " + convertIntTo4DigitString(highscoreValue);

        mainCam.SetActive(true);
        secondCam.SetActive(false);

        counter.enabled = false;
        highscore.enabled = false;
        result.enabled = false;
        newHighscore.enabled = false;

        restart.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);

        restart.onClick.AddListener(() => doRestart());
        quit.onClick.AddListener(() => doQuit());

        countdownTimer = doCountdown();
        StartCoroutine(countdownTimer);
    }

    IEnumerator doCountdown()
    {
        countdown.enabled = true;
        countdown.text = "3";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "2";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "1";
        yield return new WaitForSecondsRealtime(1);
        countdown.text = "START";

        counter.enabled = true;
        highscore.enabled = true;

        spinner.GetComponent<Rotate>().setRunning(true);
        player.GetComponent<Jump>().setRunning(true);

        yield return new WaitForSecondsRealtime(1);

        countdown.text = "";
        countdown.enabled = false;
    }


    void Update()
    {
        
    }

    public void incCounter()
    {
        int c = int.Parse(counter.text);
        c++;
        counter.text = convertIntTo4DigitString(c);
    }

    public void incRotationFactor(int addToFact)
    {
        spinner.GetComponent<Rotate>().incRotationFactor(addToFact);
    }

    public string convertIntTo4DigitString(int i)
    {
        if (i < 10)
        {
            return "000" + i;
        }
        else if (i < 100)
        {
            return "00" + i;
        }
        else if (i < 1000)
        {
            return "0" + i;
        }
        else
        {
            return "" + i;
        }
    }

    public void toggleEnd()
    {
        mainCam.SetActive(false);
        secondCam.SetActive(true);

        Vector3 pos = player.transform.position;
        player.SetActive(false);
        Instantiate(explosion, pos, Quaternion.identity);

        string score = counter.text;

        result.text = "SCORE:\n" + score;

        counter.enabled = false;
        highscore.enabled = false;
        result.enabled = true;

        restart.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);

        if (int.Parse(score) > highscoreValue)
        {
            newHighscore.enabled = true;
            PlayerPrefs.SetInt("highscore", int.Parse(score));
            PlayerPrefs.Save();
        }
    }

    public void doRestart()
    {
        SceneManager.LoadScene("Game");
    }

    public void doQuit()
    {
        SceneManager.LoadScene("TitleScreen");
    }

}
