using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    static bool initial = true;
    int score = 0;
    int continueCount = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public bool getInitial(){
        return initial;
    }
    public void toggleInitial(){
        initial = false;
    }
    public int GetScore()
    {
        return score;
    }
    public int GetContinuesUsed()
    {
        return continueCount;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }
    public void AddToContinuesUsed()
    {
        continueCount += 1;
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update()
    {
        
    }
}
