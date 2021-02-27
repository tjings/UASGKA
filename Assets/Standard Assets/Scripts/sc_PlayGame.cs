using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sc_PlayGame : MonoBehaviour
{
   public AudioSource audioData;

   public void playEasy()
   {
       SceneManager.LoadScene("Easy");
       audioData.PlayOneShot(audioData.clip);
   }

   public void playMed()
   {
       SceneManager.LoadScene("Medium");
       audioData.PlayOneShot(audioData.clip);
   }

   public void playHard()
   {
       SceneManager.LoadScene("Hard");
       audioData.PlayOneShot(audioData.clip);
   }

   public void clickSound()
   {
       audioData.PlayOneShot(audioData.clip);
   }

   public void replay()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       audioData.PlayOneShot(audioData.clip);
   }

   public void MainMenu()
   {
       SceneManager.LoadScene("MainMenu");
       audioData.PlayOneShot(audioData.clip);
   }

   public void exitgame()
   {
       audioData.PlayOneShot(audioData.clip);
       Debug.Log("Quit");
       Application.Quit();
   }
}
