/*
 *                    CRIMINAL CATS
 *                    Author: Negar Saeidi
 *                    Student number : 101261396
 *                    Date last modified: 10/22/2021
 *                    Rivision history: 1st version : 5 functions added for listening to the action of pressing each button
 *                        --**onGameOverButton function added to test the transition from main game scene to the game over scene**--    
 *                                      2nd version : added the functionslity of playing an audio clip whenever any button gets pressed
 *                                      
 *                    Name of this Script: sceneController: transition between scenes
 *                    
 *                    
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneContoller : MonoBehaviour
{
    public AudioClip click;
    public void onStartButton()
    {

        GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("Main");
    }
    public void onTutorialButton()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
       SceneManager.LoadScene("Tutorial");
    }
    public void onBackButton()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("MainMenu");
    }
    public void onPlayAgainButton()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("Main");
    }
    public void onMainMenuButton()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("MainMenu");
    }
    //Test
    public void onGameOverButton()
    {
        GetComponent<AudioSource>().PlayOneShot(click);
        SceneManager.LoadScene("GameOver");
    }
  
}






