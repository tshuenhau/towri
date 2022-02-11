using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    bool triggered = false;
    bool start = true;
    bool success = false;
    Satelite satelite;
    GameSession gameSession;
    AudioSource audioSource;
    Controller controller;
    private void Awake()
    {
        controller = FindObjectOfType<Controller>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
        satelite = collision.gameObject.GetComponent<Satelite>();
        //controller.HandleSuccess(satelite);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!success)
        {
            controller.GameOver();
        }
        //controller.GameOver();
        triggered = false;
    }
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
            if (Input.touchCount > 0){
                if(Input.GetTouch(0).phase == TouchPhase.Began){
                    Time.timeScale = 0;
                    if (!triggered){
                        controller.TooSoon();
                    }
                    else{
                        Time.timeScale = 1;
                        success = true;
                        controller.HandleSuccess(satelite);
                        success = false;
                    }
                    
                }
            }
        }        

    }

    public void toggleStart(bool val){
        start = val;
    }

}
