using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    GameObject LevelReload;
    GameObject CheckPointman;

    private void Awake()
    {
        try
        {
            LevelReload = FindObjectOfType<SavePosAfterCheckReload>().MySelf();
            CheckPointman = FindObjectOfType<CheckPointManager>().ItSelf();
        }
        catch
        {
            Debug.LogWarning("Checkpointmanager or scenepersist is not in scene");
        }

       
    }   



    public void NextLevel()
    {
        try
        {

            Destroy(LevelReload);
            Destroy(CheckPointman);
            GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckPointManager>().LastCheckPoint = new Vector2(-8.66f, -3.58f);
        }
        catch
        {
            Debug.Log("No ScenePersist destroyed cause there is nothing in the scene :)");
        }

       
        PlayerPrefsController.SaveCurrentLvlIndex(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
       
    }

    public void LoadSavedLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(PlayerPrefsController.GetLastLvlSavedIndex());

    }

    public void quit()
    {
        
        Application.Quit();
    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        Destroy(CheckPointman);
        Destroy(LevelReload);
        SceneManager.LoadScene("Main Menu");
        
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");

    }

    public void levelReload()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }


}
