using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour {

  


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        FindObjectOfType<LevelLoader>().NextLevel();
    }

}
