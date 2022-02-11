using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : MonoBehaviour
{
    int direction;
    Animator animator;
    void Awake()
    {
        direction = Random.Range(0,2)*2-1;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * Vector3.forward * 20f * Time.deltaTime);

    }

    public void destroy(){
        Destroy(gameObject);
    }


}
