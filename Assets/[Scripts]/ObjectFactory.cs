/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : create object function added
 *                    Name of this Script: ObjectFactory : Based on the type instantiate the object and add it to its pool
 *                    
 *                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ObjectFactory : MonoBehaviour
{
    [Header("object types")]
    public GameObject[] catObject;
    public GameObject pickupObject;
  
    public GameObject createObject(ObjectType type = ObjectType.CAT)
    {
        GameObject temp_obj = null;
        switch (type)
        {
            case ObjectType.CAT:
                int rand = Random.Range(0, 3);
                temp_obj = Instantiate(catObject[rand]);
                break;
            case ObjectType.FUEL:
                temp_obj = Instantiate(pickupObject);
                break;
        }
        temp_obj.transform.parent = transform;
        temp_obj.SetActive(false);
        return temp_obj;
    }
}
