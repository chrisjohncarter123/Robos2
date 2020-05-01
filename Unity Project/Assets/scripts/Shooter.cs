using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    [SerializeField]
    GameObject ball;

    [SerializeField]
    float power;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")){

            GameObject clone;
            clone = Instantiate(ball, transform.position, transform.rotation);
            clone.GetComponent<Rigidbody>().AddForce(transform.forward * power);
        
        }
    }
}
