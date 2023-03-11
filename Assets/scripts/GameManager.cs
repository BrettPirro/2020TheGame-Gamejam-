using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {



        bool IsPaused=false;
    [SerializeField] GameObject PauseMenu;
    
	
	void Update ()
    {
        Pause();

    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !IsPaused)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused)
        {
            Time.timeScale = 1;
            PauseMenu.SetActive(false);
            IsPaused = false;
        }
    }
}
