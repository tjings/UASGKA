using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sc_GameController : MonoBehaviour
{

    //public sc_Player player;
    private float respawnTime = 5f;
    public GameObject ball;
    public GameObject clone;
    public GameObject playerCamera;
    public GameObject win;
    public Text availableShotsGO;
    public sc_Basket score;
    public int availableShots = 5;
    private Vector3 startingPosition;
    public float ballDistance = 5f;
    public float throwSpeed = 800f;
    public int goals = 10;
    public bool holdingBall = true;

    // Start is called before the first frame update
    void Start()
    {
        respawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        startingPosition = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
        availableShotsGO.text = availableShots.ToString();
        if(holdingBall){
            clone.transform.position = startingPosition;
            if(Input.GetMouseButtonDown(0))
            {
                availableShots--;
                holdingBall = false;
                clone.GetComponent<Rigidbody> ().useGravity = true;
                clone.GetComponent<Rigidbody> ().AddForce(playerCamera.transform.forward * throwSpeed);
            }  
        }

        if(score._score != goals && availableShots != 0){
            if(holdingBall == false && clone.transform.position.y < 3.1){
                respawnTime -= Time.deltaTime;
                if(Input.GetMouseButtonDown(0)){
                    respawnTime -= respawnTime/2;
                }
                if(respawnTime <= 0){
                    Destroy(clone);
                    respawnBall();
                    respawnTime = 5f;
                }
            }
        }
        
        if(score._score == goals){
            Invoke("won", 8);
        }

        if(score._score != goals && availableShots == 0){
            Invoke("over", 8);
        }
    }

    void won(){
        win.SetActive(true);
    }
    void respawnBall() {
        startingPosition = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;
        clone = Instantiate(ball, startingPosition, transform.rotation);
        holdingBall = true;
        clone.GetComponent<Rigidbody> ().useGravity = false;
    }
    void over()
    {
        if(score._score == goals){
           won(); 
        }if(score._score < goals){
            SceneManager.LoadScene("GameOver");    
        }
    }
}
