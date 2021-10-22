/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : OnTriggerEnter2D and OnCollisionEnter2D functions added
 *                    Name of this Script: ObjectCollisions : detects collision between different types of objects in the scene and responds accordingly
 *                    
 *                    
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public GameObject blood;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "pin")
        {

            if (gameObject.tag == "cat")
            {

                transform.position = new Vector3(transform.position.x + 1.19f, transform.position.y, transform.position.z);
            }



        }

    }


    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "car")
        {
            if (gameObject.tag == "cat")
            {
                GameObject temp = Instantiate(blood);
                temp.transform.position = transform.position;
                Destroy(this.gameObject);
            }

            else if (gameObject.tag == "fuel")
            {

                Destroy(this.gameObject);
            }


        }
        else if (other.gameObject.tag == "cat")
        {
            if (gameObject.tag == "cat")
            {
                Destroy(this.gameObject);
            }
        }
    }
}