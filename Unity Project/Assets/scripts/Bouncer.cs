using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{


    [SerializeField]
    float speed;



    [SerializeField]
    Rigidbody2D head;




    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        
        head.AddTorque(speed);
   

        
    }
}
