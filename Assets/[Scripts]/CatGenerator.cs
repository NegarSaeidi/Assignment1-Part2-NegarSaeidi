/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : in the fixedUpdate function, based on the delayFrame, a cat will be appeared on the scene at a random location
 *                    Name of this Script: CatGenerator: spwans cats at different locations on the scene
 *                    
 *                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGenerator : MonoBehaviour
{
      
        public int frameDelay;
        public GameObject[] spawnLocations;
        private float startingPoint;
        private float randomSpeed;
       private ObjectManager objectManager;

        // Start is called before the first frame update
        void Start()
        {
           
            objectManager = GameObject.FindObjectOfType<ObjectManager>();
        }

        void FixedUpdate()
        {
            if (Time.frameCount % frameDelay == 0)
            {

            int rand = Random.Range(0, 3);

           objectManager.GetObjet(spawnLocations[rand].transform.position);
            }
        }
    }


