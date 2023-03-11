using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemyAi : MonoBehaviour {

    [SerializeField] bool Actives;
    [SerializeField] EnemyAi[] Enemies;

    private void OnTriggerEnter2D(Collider2D collision)
    {



        foreach(EnemyAi select in Enemies)
        {
            try
            {
                select.Active = Actives;
            }
            catch
            {

            }

            
        }

    }
}
