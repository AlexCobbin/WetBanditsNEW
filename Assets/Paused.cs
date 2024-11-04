using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Paused : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        if (Input.GetKey(KeyCode.Escape) && isPaused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
        }
    }

    public void Play()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1.0f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
