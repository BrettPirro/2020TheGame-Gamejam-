using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]float playerspeed;
    [SerializeField] float JumpHeight;
    [SerializeField] float dashPower;
    Rigidbody2D rigidBody2D;
    BoxCollider2D feet;
    Animator animator;
    bool ItsDone=true;
    bool DashDone = true;
    Coroutine JumpPause;
    Coroutine DashCoolDown;
    CapsuleCollider2D body;
    bool PlayerDead = false;
    GameObject DustParent;
    [SerializeField]GameObject Spawnpoint, dust;

    [SerializeField] AudioClip JumpAud;
    [SerializeField] AudioClip DieAud;

    private void Awake()
    {
        
    }

    void Start () {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        feet = GetComponent<BoxCollider2D>();
        body = GetComponent<CapsuleCollider2D>();

       try
        {
            transform.position = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckPointManager>().LastCheckPoint;
        }
        catch
        {

        }
            
        

        if (!DustParent)
        {
            DustParent = new GameObject("DustParent");
        }

    }
	

	void Update ()
    {

        if (!PlayerDead)
        {
            Running();
            Jump();
            Dash();

        }




    }

    private void Jump()
    {

        if (ItsDone)
        {
            JumpPause = StartCoroutine(JumpAndPause());
            
        }

        if (!(rigidBody2D.velocity.y == 0))
        {
            animator.SetBool("IsPlayerJumping", true);
        }
        else
        {
            animator.SetBool("IsPlayerJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(JumpAud, transform.position);
        }


    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)&& DashDone)
        {
            
            DashCoolDown = StartCoroutine(Dashing());

        }
    }



    private void Running()
    {

        rigidBody2D.velocity = new Vector2(playerspeed * Input.GetAxis("Horizontal"), rigidBody2D.velocity.y);

        SpriteFlip();

        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector2(1, 1);

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector2(-1, 1);

        }

    }

    private void SpriteFlip()
    {
        if (!(Input.GetAxis("Horizontal") == 0))
        {
            animator.SetBool("IsPlayerRunning", true);
        }
        else
        {
            animator.SetBool("IsPlayerRunning", false);
        }
    }

    
    IEnumerator JumpAndPause()
    {
       
        if (feet.IsTouchingLayers(LayerMask.GetMask("Ground")) )
        {
            rigidBody2D.velocity += new Vector2(0, JumpHeight * Input.GetAxis("Jump"));
           
            ItsDone = false;
         
            yield return new WaitForSeconds(.1f);
            ItsDone = true;
            StopCoroutine(JumpPause);
        }
    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (body.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Dead()
    {

        animator.SetTrigger("Death");
        PlayerDead = true;
        rigidBody2D.velocity = new Vector2(0, 0);
        AudioSource.PlayClipAtPoint(DieAud, transform.position);
        yield return new WaitForSeconds(1f);
        FindObjectOfType<LevelLoader>().levelReload();
     
        
    }



    IEnumerator Dashing()
    {
        
      
             DashDone = false;
       
              

            
          
            
            for (int i = 0; i <= 7; i++)
            {
                
            GameObject Dusts = Instantiate(dust, Spawnpoint.transform.position, Quaternion.identity,DustParent.transform) as GameObject;
            rigidBody2D.velocity += new Vector2(dashPower * -transform.localScale.x, 0);
            yield return new WaitForSeconds(.001f);
            }
            
            yield return new WaitForSeconds(.2f);

            DashDone = true;
            
       

        StopCoroutine(DashCoolDown);


    }



}
