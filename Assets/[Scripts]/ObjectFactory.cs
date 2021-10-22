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
