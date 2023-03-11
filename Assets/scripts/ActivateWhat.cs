using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhat : MonoBehaviour {

    bool pushed;
    bool done = true;
    [SerializeField] Animator[] MoveablePlatforms;
    [SerializeField] float waitBetweenPlat;
    Coroutine PlatMovement;

    
	void Start ()
    {
      
    }

    

    void Update ()
    {
        pushed = GetComponent<Animator>().GetBool("IsPressed");

        if (done)
        {
            PlatMovement = StartCoroutine(ExtendandHold());
        }

        


    }

    IEnumerator ExtendandHold()
    {
        done = false;
        if (pushed)
        {
            for (int plat = 0; plat < MoveablePlatforms.Length; plat++)
            {

                
                MoveablePlatforms[plat].SetBool("Extended", true);
                yield return new WaitForSeconds(waitBetweenPlat);
               
               
            }
            
        }
        else 
        {
            for (int plat = 0; plat < MoveablePlatforms.Length; plat++)
            {
                
                MoveablePlatforms[plat].SetBool("Extended", false);
                yield return null;

            }
           
        }
        

        done = true;
        StopCoroutine(PlatMovement);

    }
    

}
