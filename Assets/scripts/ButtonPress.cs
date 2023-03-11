using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour {

   
    Animator animator;
    BoxCollider2D box;

	void Start () {
        animator = GetComponentInParent<Animator>();
        box = GetComponent<BoxCollider2D>();
	}

    private void Update()
    {
     
        if (box.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            animator.SetBool("IsPressed", true);
         
        }
        else
        {
            animator.SetBool("IsPressed", false);

        }
    }



}
