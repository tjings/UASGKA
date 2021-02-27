using UnityEngine;
using UnityEngine.UI;
using System.Collections;
 
public class sc_Basket : MonoBehaviour
{
    public Text score;
    public int _score = 0;
    AudioSource audioData;
    
    [SerializeField] private Animator Animator, Animator2;
    
    void Start(){
        audioData = GetComponent<AudioSource>();
    }
 
    void OnTriggerEnter()
    {
        int currentScore = int.Parse(score.text) + 2; //add 2 to the score
        score.text = currentScore.ToString();
        _score = _score +2;
        Animator.SetBool("isClapping", true);
        Animator2.SetBool("isClapping", true);
    }

    void OnTriggerExit(){
        Animator.SetBool("isClapping", false);
        Animator2.SetBool("isClapping", false);
        audioData.Play(0);
    }
}