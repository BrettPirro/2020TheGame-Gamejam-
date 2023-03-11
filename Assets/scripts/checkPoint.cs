using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {

    private CheckPointManager cpm;
    [SerializeField]Sprite Passed;
    

    private void Start()
    {
        cpm = GameObject.FindGameObjectWithTag("CPM").GetComponent<CheckPointManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = Passed;
        cpm.LastCheckPoint = transform.position;
    }
}
