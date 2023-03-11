using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SavePosAfterCheckReload : MonoBehaviour {


    int SceneIndex;

    private void Awake()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
       
    }

    private void Start()
    {
        if (!(SceneIndex == SceneManager.GetActiveScene().buildIndex))
        {
            Destroy(gameObject);
        }

        int instances =FindObjectsOfType<SavePosAfterCheckReload>().Length;

        if (instances>1)
        {
            Destroy(gameObject);
        }
        
        else
        {
            DontDestroyOnLoad(gameObject);

        }


        

    }

    
   

    

    public GameObject MySelf()
    {
        return gameObject;
    }
	
	
}
