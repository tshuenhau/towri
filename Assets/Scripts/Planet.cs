using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    float speed = 130;
    float rotateSpeed = 0;
    int direction = -1;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame(){
        yield return new WaitForSeconds(0.1f);
        rotateSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(direction * Vector3.forward * rotateSpeed * Time.deltaTime);

    }

    public void ChangeDirection()
    {
        direction = -direction;
    }
    public void ChangeSpeed(int val) {
        rotateSpeed += val;

    }
    public int GetDirection(){
        return direction;
    }
}