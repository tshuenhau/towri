using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContinuesAvailable : MonoBehaviour
{
    TextMeshProUGUI continuesAvailableText;
    // Start is called before the first frame update
    void Awake()
    {
        continuesAvailableText= GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        continuesAvailableText.text = PlayerPrefsController.GetContinues().ToString() + " continues available";
    }
}
