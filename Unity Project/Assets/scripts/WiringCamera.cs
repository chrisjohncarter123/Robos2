using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiringCamera : MonoBehaviour
{

    [SerializeField]
    int robotLayer = 8;

    [SerializeField]
    int wiringShowLayer = 9;

    [SerializeField]
    RobotHead robotHead;

    [SerializeField]
    float rotationSpeed = 10;

    [SerializeField]
    float zoomSpeed = 10;

     [SerializeField]
    float startZoom = 1.5f;

    [SerializeField]
    Transform cameraTarget;

    [SerializeField]
    Vector3 currentCameraRotation;

    [SerializeField]
    float currentCameraZoom;

    


    // Start is called before the first frame update    Camera cam;
    Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
        currentCameraZoom = startZoom;
        

    }

    public void SetInitialTransform(){
        currentCameraZoom = 100;
        currentCameraRotation = new Vector3(0, 90, 0); //overhead view
        
        Update();

        //int layerMask = 1 << 9; //wiring layer


        Vector3 fromPosition = transform.position;
        Vector3 toPosition = cameraTarget.position;
        Vector3 direction = toPosition - fromPosition;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, direction, out hit, Mathf.Infinity))
        {
            currentCameraZoom = Vector3.Distance(hit.point, robotHead.transform.position) + startZoom;
            currentCameraRotation = new Vector3(0, 90, 0); //overhead view

        }

        Update();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 euler = Vector3.zero;
        Vector3 position = Vector3.zero;

        position.z = currentCameraZoom;

        transform.position = RotatePointAroundPivot(
            position,
            cameraTarget.position,
            currentCameraRotation);

         transform.LookAt(cameraTarget);

    }
    public void UpdateWiringCameraRotation(Vector3 change){
        currentCameraRotation += change * rotationSpeed * Time.deltaTime;
   
    }
    public void UpdateWiringCameraZoom(float change){
        currentCameraZoom += change * zoomSpeed * Time.deltaTime;
    }

     Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles ) {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
 }


    public void TurnWiringCameraOn(){
        //SetInitialTransform();
        

    }

    public void TurnWiringCameraOff(){
        
    }
    public void UpdateWiringCamera(){

    }
    public void SetRobotHead(GameObject robotHead){
        this.robotHead = robotHead.GetComponent<RobotHead>();
        SetInitialTransform();
    }

    /*
    public void StartWiringCamera(){
        SetInitialTransform();
    }
    */

    public void SetRobotHead(RobotHead robotHead){
        this.robotHead = robotHead;
        SetInitialTransform();
    }

    void OnPreCull()
    {
        robotHead.SetWiringLayer();
    }

    // Set it to true so we can watch the flipped Objects
    void OnPreRender()
    {
     
    }

    // Set it to false again because we dont want to affect all other cammeras.
    void OnPostRender()
    {

        robotHead.SetRobotLayer();
    }

    
}
