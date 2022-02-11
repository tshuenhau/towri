using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string CONTINUES_KEY = "continues key";
    const string HIGHSCORE_KEY = "highscore key";

    void Start(){
        PlayerPrefs.SetInt(CONTINUES_KEY,PlayerPrefs.GetInt(CONTINUES_KEY, 3));

    }


    public static void UpdateContinues(int numContinues){
        PlayerPrefs.SetInt(CONTINUES_KEY, PlayerPrefs.GetInt(CONTINUES_KEY) + numContinues);
    }
    public static int GetContinues(){
        return PlayerPrefs.GetInt(CONTINUES_KEY);
    }

    public static void UpdateHighScore(int score){
        PlayerPrefs.SetInt(HIGHSCORE_KEY, score);
    }

    public static int GetHighScore(){
        return PlayerPrefs.GetInt(HIGHSCORE_KEY);
    }

}
