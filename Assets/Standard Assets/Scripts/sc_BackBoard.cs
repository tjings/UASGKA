using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class sc_BackBoard : MonoBehaviour
{
    AudioSource audioData;
    
    void Start(){
        audioData = GetComponent<AudioSource>();
    }

    void OnTriggerEnter() //if ball hits board
    {
        audioData.Play(0);
    }
}
