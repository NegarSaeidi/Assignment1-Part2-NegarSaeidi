using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class ObjectManager : MonoBehaviour
{
    public Queue<GameObject> catObjPool;
    public Queue<GameObject> fuelObjPool;
    public int catObjNumber;
    public int fuelObjNumber;
    private ObjectFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        catObjPool = new Queue<GameObject>(); // creates an empty Queue
        fuelObjPool = new Queue<GameObject>();
        factory = GetComponent<ObjectFactory>();
      
    }


    private void AddObject(ObjectType type = ObjectType.CAT)
    {

        switch (type)
        {
            case ObjectType.CAT:
                var temp = factory.createObject(ObjectType.CAT);
                catObjPool.Enqueue(temp);
                catObjNumber++;
                break;
            case ObjectType.FUEL:
                var temp_obj = factory.createObject(ObjectType.FUEL);
                fuelObjPool.Enqueue(temp_obj);
                fuelObjNumber++;


                break;
        }

    }

    /// <summary>
    /// This method removes a bullet prefab from the bullet pool
    /// and returns a reference to it.
    /// </summary>
    /// <param name="spawnPosition"></param>
    /// <returns></returns>
    public GameObject GetObjet(Vector2 spawnPosition, ObjectType type = ObjectType.CAT)
    {
        GameObject temp = null;
        switch (type)
        {
            case ObjectType.CAT:
                if (catObjPool.Count <1)
                {
                    AddObject(ObjectType.CAT);

                }

                temp = catObjPool.Dequeue();
                temp.transform.position = spawnPosition;
                temp.SetActive(true);

                break;
            case ObjectType.FUEL:

                if (fuelObjPool.Count < 1)
                {

                    AddObject(ObjectType.FUEL);
                }

                temp = fuelObjPool.Dequeue();
                temp.transform.position = spawnPosition;
                temp.SetActive(true);

                break;
        }
        return temp;

    }

    /// <summary>
    /// This method returns a bullet back into the bullet pool
    /// </summary>
    /// <param name="returnedObj"></param>
    public void ReturnObject(GameObject returnedObj, ObjectType type = ObjectType.CAT)
    {
        returnedObj.SetActive(false);
        switch (type)
        {
            case ObjectType.CAT:

                catObjPool.Enqueue(returnedObj);
                break;
            case ObjectType.FUEL:

                fuelObjPool.Enqueue(returnedObj);
                break;
        }

    }
}
