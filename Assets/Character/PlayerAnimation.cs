using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public int maxHealth;
    public int maxStamina;

    void Update()
    {
        // Character Animation
        if (Input.GetKeyDown("1"))
        {
            gameObject.GetComponent<Animator>().Play("Player Run");
        }   
    
        if (Input.GetKeyDown("2"))
        {
            gameObject.GetComponent<Animator>().Play("Player Jump");
        }

         if (Input.GetKeyDown("3"))
        {
            gameObject.GetComponent<Animator>().Play("Player Attack 1");
        }      
         
         if (Input.GetKeyDown("4"))
        {
            gameObject.GetComponent<Animator>().Play("Player Attack 2");
        }

        //

    }
}