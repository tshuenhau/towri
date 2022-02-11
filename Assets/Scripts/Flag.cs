using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    Planet planet;
    // Start is called before the first frame update
    void Awake()
    {
        planet = FindObjectOfType<Planet>();
    }

    // Update is called once per frame
    void Update()
    {
        if(planet.GetDirection() == -1){
            transform.localScale = new Vector2(-1f,1f);
        }
        else if(planet.GetDirection() == 1){
            transform.localScale = new Vector2(1f,1f);
        }
    }
}
