using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject roof, planet;
    int prevAng;
    int buffer = 120;
    [SerializeField] GameObject[] satelites;

   void Awake()
    {
        roof = FindObjectOfType<Roof>().gameObject;
        planet = FindObjectOfType<Planet>().gameObject;


    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnSatelite(0);
    }

    // Update is called once per frame
    void Update()
    {
        /*for(int i =0; i < 10 ; i++){
            SpawnSatelite(1);

        }
        for(int i =0; i < 10 ; i++){
            SpawnSatelite(-1);

        }
    */
    }

    public void SpawnSatelite(int direction){
        int sateliteIndex = Random.Range(0, satelites.Length);
        Vector2 roofPos = roof.transform.position;
        Vector2 planetPos = planet.transform.position;
        Vector3 pos = RandomCircle(planetPos, Vector2.Distance(roofPos,planetPos), direction);
        Instantiate(satelites[sateliteIndex], pos,Quaternion.identity);
    }
    public Vector2 RandomCircle(Vector2 center, float radius, int direction){
        int ang;
        if(direction != 0){
            /*
            ang = Random.Range(0,360);
            int distance = Distance(ang, prevAng);

            if(distance < buffer && distance > 0){
                ang += buffer;
            }
            else if(distance > -buffer && distance < 0){
                ang -= buffer;
            }
            else if(distance == 0){
                int rand = Random.Range(0,2)*2-1;
                ang += (buffer*rand);

            }
            if(ang > 360){
                ang -= 360;
            }
            else if(ang < 0){
                ang += 360;
            }
            prevAng = ang;

    */


            ang = Random.Range(buffer, 360-buffer);
            if(direction > 0){
                ang += prevAng;
                if(ang > 360){
                    ang -= 360;
                }
            }
            else if(direction < 0){
                ang = prevAng - ang;
                if(ang < 0){
                    ang += 360;
                }
            }
            prevAng = ang;


                
        }

        else{
            ang = Random.Range(90,150);
            prevAng = ang;           
        }
        radius = radius + (float)0.25;
        Vector2 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }
    /*
    public static int Distance(int a, int b) { // a = new angle; b = old angle;
        int phi = Mathf.Abs(b - a) % 360;       // This is either the distance or 360 - distance
        int distance = phi > 180 ? 360 - phi : phi;
        int sign = (a - b >= 0 && a - b <= 180) || (a - b <= -180 && a- b>= -360) ? 1 : -1; 
        distance *= sign;
        return distance;
    }
    */
}