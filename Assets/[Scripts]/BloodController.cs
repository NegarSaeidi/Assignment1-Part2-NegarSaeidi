/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : DestroyObject function added
 *                    Name of this Script: BloodController : destroys the could texture that appears when a cat dies after 1.0 sec
 *                    
 *                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{
    void Update()
    {
        Invoke("DestroyObject", 1.0f);
    }
   public void DestroyObject()
   {
        Destroy(this.gameObject);
   }
}
