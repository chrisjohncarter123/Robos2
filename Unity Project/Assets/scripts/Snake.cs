using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{


    [SerializeField]
    float weightScale = 50;

    [SerializeField]
    float min;

    [SerializeField]
    float max;

    [SerializeField]
    float speed;

    [SerializeField]
    DistanceJoint2D joint;

    [SerializeField]
    Rigidbody2D head;

    [SerializeField]
    Rigidbody2D body;

    
    float distance;

    
    // Start is called before the first frame update
    void Start()
    {
        //joint = gameObject.GetComponent<DistanceJoint>();
        joint.autoConfigureDistance	= false;
        distance = min;
    }
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        //update trig
        float cos = Mathf.Cos(Time.time * speed);
        float sin = Mathf.Sin(Time.time * speed);

        if(cos >= 0)
        {
            distance += 1 * Time.deltaTime;
            body.mass = 100;
            head.mass = 1; 
        }
        else
        {
            distance -= 1 * Time.deltaTime;
            head.mass = 100;
            body.mass = 1; 
        }


        //update physics
        joint.distance = distance;
        head.AddForce(Vector2.up);
   

        
    }
}
