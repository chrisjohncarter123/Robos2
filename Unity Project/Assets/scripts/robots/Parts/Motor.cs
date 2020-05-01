using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{

    [SerializeField]
    HingeJoint2D joint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed(float speed){
        JointMotor2D motor = joint.motor;
        motor.motorSpeed = speed;
        joint.motor = motor;
    
    }


}
