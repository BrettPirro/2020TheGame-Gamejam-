using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    public bool Active = false;
    float randomX;
    float randomY;
    [SerializeField] float speed;
    Vector2 CurrentPos;
    Vector2 UpdatedPos;
    bool genDone = false;
   

	void Start ()
    {
        CurrentPos = transform.position;

    }
	
	
	void Update ()
    {

        if (Active)
        {

            if (!genDone)
            {
                StartCoroutine(RandomGen());
            }
            transform.position = Vector2.MoveTowards(transform.position, UpdatedPos, speed * Time.deltaTime);
            Movment();  
        }




    }

    private void Movment()
    {
        
    }

    IEnumerator RandomGen()
    {
       
        genDone = true;
        randomX = Random.Range(-2f, 2f)+transform.position.x;
        randomY = Random.Range(-2f, 2f) + transform.position.y;
        UpdatedPos = new Vector2(randomX, randomY);
        yield return new WaitForSeconds(1f);
        UpdatedPos = CurrentPos;
        yield return new WaitForSeconds(1f);

        genDone = false;

    }




}
