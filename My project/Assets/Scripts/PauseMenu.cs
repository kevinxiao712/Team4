using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool ispaused;
    // Start is called before the first frame update
    void Start()
    {
        ispaused=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ispaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            
        }
    }
    public void Resume()
    {
            ispaused=false;
            pauseMenu.SetActive(false);
            Time.timeScale=1;
            
    }
    public void Pause()
    {
            ispaused=true;
            pauseMenu.SetActive(true);
            Time.timeScale=0;
            
    }
    public void Quit()
    {
           
            Application.Quit();
    }
}
