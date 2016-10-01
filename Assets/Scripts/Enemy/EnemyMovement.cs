﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
        //player = GameObject.FindGameObjectWithTag ("Player").transform;
        
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }


    void Update ()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        
        
        RaycastHit floorHit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out floorHit))
        {
            nav.SetDestination(floorHit.point);
        }
        
       
    }
}
