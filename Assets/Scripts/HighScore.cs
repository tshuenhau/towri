using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
    TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText= GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "High Score: " + PlayerPrefsController.GetHighScore().ToString();
    }
}
