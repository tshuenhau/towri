using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinuesUsedDisplay : MonoBehaviour
{
    TextMeshProUGUI continuesUsedText;
    GameSession gameSession;
    // Start is called before the first frame update
    void Awake()
    {
        gameSession = FindObjectOfType<GameSession>();
        continuesUsedText= GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        continuesUsedText.text = gameSession.GetContinuesUsed().ToString() + " continues used";

    }
}
