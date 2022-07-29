using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{

    public Button quit, play, credits;

    void Start()
    {
        quit.onClick.AddListener(() => Application.Quit());
        play.onClick.AddListener(() => SceneManager.LoadScene("Game"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
