/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : move function and checkbound added
 *                    Name of this Script: ObjectBehaviour : Based on the type and direction of the object , moves the object in its direction
 *                    
 *                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    public ObjectType type;

    [Header("object Movement")]
    [Range(0.0f, 0.5f)]
    public float speed;
    public Bounds objBounds;
    public ObjectDirection direction;

    private ObjectManager objManagerr;
    private Vector3 objVelocity;

    // Start is called before the first frame update
    void Start()
    {
        objManagerr = GameObject.FindObjectOfType<ObjectManager>();

        switch (direction)
        {
            case ObjectDirection.UP:
                objVelocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case ObjectDirection.DOWN:
                objVelocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            case ObjectDirection.NONE:
                objVelocity = new Vector3(0.0f, 0.0f, 0.0f);
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += objVelocity;
    }

    private void CheckBounds()
    {
        // checks bottom bounds
        //if (transform.position.y < objBounds.max)
        //{
        if(transform.position.y< -9.24f)
            objManagerr.ReturnObject(this.gameObject, type);
        //}

        // check top bounds
        if (transform.position.y > 9.24f)
        //{
            objManagerr.ReturnObject(this.gameObject, type);
        //}
    }
}