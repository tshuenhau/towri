using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverDisplay : MonoBehaviour
{
    TextMeshProUGUI gameOverText;
    GameSession gameSession;
    string display;
    
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        gameOverText= GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gameOverText.text = display;
    }

    public void updateDisplay(string text){
        display = text;
    }
}
