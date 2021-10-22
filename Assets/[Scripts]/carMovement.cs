/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : simple movement added for testing
 *                                      2nd version : changing the input type to touch
 *                                      3rd version : added the collision check between cats and player, fuels and player
 *                                      version 4th : score update function added
 *                    Name of this Script: carMovement: control the simple movement of car by touch input
 *                    
 *                    
 */                   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class carMovement : MonoBehaviour
{
    public float maxXBound;
    public float minXBound;

    public GameObject redScreen;
    public AudioClip pickupAudio;
    public AudioClip catAudio;
    public AudioClip pinAudio;
    public AudioClip engine;
    public Text scoreField;
    private float score;

    public GameObject[] hearts;
    private int heartIndex ;

    public GameObject[] fuelsBar;
    private int fuelsIndex;
    private float vel;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 1;
        vel = 1;
        heartIndex = 0;
        fuelsIndex = fuelsBar.Length-1;
    }

    // Update is called once per frame
    void Update()
    {
        FuelUsage();
        moveByTouch();
        updateScore();
        if (heartIndex == 2)
            redScreen.SetActive(true);
        else
            redScreen.SetActive(false); ;

    }
    private void updateScore()
    {
        score += Time.deltaTime*vel ;
        int temp = (int)score;
        scoreField.text=temp.ToString();
    }
    private void moveByTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));



                if (touchedPos.x > transform.position.x)
                {
                 
                    if (transform.position.x < maxXBound)
                        transform.position = new Vector3(transform.position.x + 1.15f, transform.position.y, transform.position.z);
                      
                }
                else
                {
                    if (transform.position.x > minXBound)
                        transform.position = new Vector3(transform.position.x - 1.15f, transform.position.y, transform.position.z);
                }


            }
        }
    }
    private void FuelUsage()
    {
        timer +=Time.deltaTime;
      
      
            if (timer>10)
            {
                timer = 0;
            if (fuelsIndex > 0)
            {
                fuelsBar[fuelsIndex].SetActive(false);
                fuelsIndex--;
            }
            else if (fuelsIndex == 0)
            {
                PlayerPrefs.SetFloat("score", score);
                SceneManager.LoadScene("GameOver");
              
            }
            }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "cat")
        {
            if (heartIndex < hearts.Length - 1)
            {
                Destroy(hearts[heartIndex]);
                heartIndex++;
                GetComponent<AudioSource>().PlayOneShot(catAudio);
            }
            else if (heartIndex == hearts.Length - 1)
            {
                PlayerPrefs.SetFloat("score", score);
                SceneManager.LoadScene("GameOver");

            }

        }
        else if (other.gameObject.tag == "fuel")
        {

            GetComponent<AudioSource>().PlayOneShot(pickupAudio);
            if (fuelsIndex < 7)
            {
                fuelsIndex++;
                fuelsBar[fuelsIndex].SetActive(true);
            }


        }
        else if (other.gameObject.tag == "pin")
        {
            if (heartIndex < hearts.Length - 1)
            {
                Destroy(hearts[heartIndex]);
                heartIndex++;
                GetComponent<AudioSource>().PlayOneShot(pinAudio);
            }
            else if (heartIndex == hearts.Length - 1)
            {
                PlayerPrefs.SetFloat("score", score);
                SceneManager.LoadScene("GameOver");

            }

        }

        else
        {
            GetComponent<AudioSource>().PlayOneShot(engine);
        }
    }
}
