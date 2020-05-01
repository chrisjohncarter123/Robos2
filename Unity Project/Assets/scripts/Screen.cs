using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
    public RobotPart robotPart;

    public GameObject screen;

    public Vector3 localScreenRotation = new Vector3(45, 180, 0);

    public DistanceMode distanceMode = DistanceMode.Static;

    public Vector3 menuPositionOffset;

    public float menuDistanceOffset;

    public enum DistanceMode{
        Static,
        Dynamic
    }

    bool turnedOn = false;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TurnScreenOff(){
        screen.SetActive(false);

    }
    public void TurnScreenOnSelf(){
        turnedOn = true;
        TurnScreenOn(robotPart.transform);

    }

    public void TurnScreenOn(Transform target){
        turnedOn = true;
        screen.SetActive(true);
        Camera camera = Camera.main;

        transform.position = target.position;
        
        transform.position += menuPositionOffset;

        if(distanceMode == DistanceMode.Dynamic){
            Vector3 direction = Vector3.Normalize(camera.transform.position - transform.position);
            float distance = Vector3.Distance(camera.transform.position, transform.position);
            float offset = distance - menuDistanceOffset;
            transform.position += direction * offset;

        }
    
        transform.LookAt(camera.transform.position);
        transform.localEulerAngles += localScreenRotation;
    }
}
