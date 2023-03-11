using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour {

    GameObject player;
    
    float StartPos;
    [SerializeField] float parrallaxVal;

	void Start () {
        player=FindObjectOfType<Player>().gameObject;
     
        StartPos = gameObject.transform.position.x;
    }
	
	
	void Update ()
    {
        float distance = player.transform.position.x * parrallaxVal;
        Vector2 Newposition = new Vector2(StartPos + distance, transform.position.y);
        transform.position = Newposition;

    }
}
