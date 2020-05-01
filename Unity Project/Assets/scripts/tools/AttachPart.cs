using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPart : MonoBehaviour
{

    [SerializeField]
    GameObject part;

    [SerializeField]
    GameObject previewObject;

    [SerializeField]
    float rotateSpeed = .1f;

    [SerializeField]
    float groundYOffset = 4.1f;

    Vector3 currentPartRotation = Vector3.zero;
    Vector3 currentPreviewRotation;





    bool setPreview = false;
    // Start is called before the first frame update
    void Start()
    {
        currentPreviewRotation = previewObject.transform.eulerAngles;
    }


    public void OnTurnToolOn(GameObject pointer){

    }

    public void OnTurnToolOff(GameObject pointer){

    }
    
    Vector3 mouseDistance = Vector2.zero;
    Vector3 mouseStart = Vector2.zero;

    //Vector3 hitRotation = Vector3.zero;

    void Update(){



        if(Input.GetMouseButtonDown(1)){
            mouseStart = Input.mousePosition;
            mouseDistance = Vector2.zero;

        }
        if(Input.GetMouseButton(1)){
            Vector2 currentMouse = Input.mousePosition;

            mouseDistance.x += currentMouse.x - mouseStart.x;
            mouseDistance.y += currentMouse.y - mouseStart.y;

            if(mouseDistance.x > 500){
                currentPartRotation.x += 90;
                mouseDistance.x = 0;
            }

            if(mouseDistance.y > 100){
                currentPartRotation.y += 90;
                mouseDistance.y = 0;
            }
            

        }


        if (Input.GetKeyDown("q"))
        {
            currentPartRotation.x += 45;
        }

        if (Input.GetKeyDown("e"))
        {
            currentPartRotation.y += 45;
        }


        /*
        Vector3 targetAngle = currentPartRotation;

        targetAngle += hitRotation; 

        currentPreviewRotation = new Vector3(
             Mathf.LerpAngle(currentPreviewRotation.x, targetAngle.x, rotateSpeed * Time.deltaTime),
             Mathf.LerpAngle(currentPreviewRotation.y, targetAngle.y, rotateSpeed * Time.deltaTime),
             Mathf.LerpAngle(currentPreviewRotation.z, targetAngle.z, rotateSpeed * Time.deltaTime));

     //   previewObject.transform.eulerAngles = currentPreviewRotation;
     */


    }

    // Update is called once per frame
    void LateUpdate()
    {
  
        
    }

    ConnectionPoint currentHitConnectionPoint;

    void SetConnectedPartTransform(GameObject g, GameObject hit){
        previewObject.transform.eulerAngles = hit.GetComponent<ConnectionPoint>().GetRobotPart().transform.eulerAngles;
            g.transform.position = hit.GetComponent<ConnectionPoint>().GetRobotPart().transform.position;
            g.transform.SetParent(hit.GetComponent<ConnectionPoint>().GetRobotPart().transform);
            g.transform.localEulerAngles += currentPartRotation;
            g.transform.position = hit.GetComponent<ConnectionPoint>().GetConnectPosition();

    }

    public void UseHit(GameObject pointer ){

        Pointer p = pointer.GetComponent<Pointer>();

        GameObject hit = p.hit.collider.gameObject;

        if(hit.GetComponent<ConnectionPoint>()){
            

            HideConnectionPoint();
            ShowConnectionPoint(hit.GetComponent<ConnectionPoint>());
           // hitRotation = p.hit.collider.gameObject.transform.eulerAngles;
            SetConnectedPartTransform(previewObject, hit);
            
    
        }
        else {
            Vector3 pos = previewObject.transform.position;
            pos = p.hit.point;
            pos.y += groundYOffset;
            previewObject.transform.position = pos;
            HideConnectionPoint();

            //previewObject.transform.eulerAngles = Vector3.zero;

        }


    }

    void HideConnectionPoint(){
        if(currentHitConnectionPoint){
            currentHitConnectionPoint.HideConnectionPoint();
            currentHitConnectionPoint = null;
            
            
        }
        
    }

    void ShowConnectionPoint(ConnectionPoint cp){
        currentHitConnectionPoint = cp;
        currentHitConnectionPoint.ShowConnectionPoint();

    }

    public void UseMiss(GameObject pointer){
        HideConnectionPoint();
        //hitRotation = Vector3.zero;
        
    }
    
    public void UseTool(GameObject pointer ){

       

        Pointer p = pointer.GetComponent<Pointer>();
        
        GameObject hit = p.hit.collider.gameObject;
        if(previewObject.GetComponent<ErrorCube>().IsTouchingAnything()) {
                return;
        }

        /*
        if(hit.GetComponent<ConnectionPoint>() && 
        (previewObject.GetComponent<ErrorCube>().IsTouchingAnythingInvalid(
            hit.GetComponent<ConnectionPoint>().GetRobotPart().partGroup))){
                return;
        }
        else {
            
        }
        */
        
        GameObject clone;
        clone = Instantiate(part);
        
        //clone.transform.SetParent(clone.GetComponent<RobotPart>().partGroup.gameObject.transform);

  //   clone.GetComponent<RobotPart>().partGroup = 
    //            PartGroup.CreateNewPartGroup(previewObject.transform.position, Vector3.zero, newHead).GetComponent<PartGroup>();

        if(hit.GetComponent<ConnectionPoint>()){

            Rigidbody rb = clone.GetComponent<Rigidbody>();

            ConnectionPoint connection = hit.GetComponent<ConnectionPoint>();

            clone.transform.position = previewObject.transform.position;
            clone.transform.eulerAngles = previewObject.transform.eulerAngles;

           // SetConnectedPartTransform(clone, hit);
            /*
            clone.transform.position = connection.GetConnectPosition();
            clone.transform.eulerAngles = p.hit.collider.gameObject.transform.eulerAngles;
            clone.transform.localEulerAngles += currentPartRotation;
            */
            
            clone.GetComponent<RobotPart>().robotHead = hit.GetComponent<ConnectionPoint>().GetRobotPart().robotHead;

            hit.GetComponent<ConnectionPoint>().SetJoint(p, clone, connection, hit.GetComponent<ConnectionPoint>().GetPartGroup());

        }
        else {
            RobotHead newHead = RobotHead.CreateNewRobotHead();

            clone.GetComponent<RobotPart>().partGroup = 
                PartGroup.CreateNewPartGroup(previewObject.transform.position, Vector3.zero, newHead).GetComponent<PartGroup>();


            clone.transform.SetParent(clone.GetComponent<RobotPart>().partGroup.transform);
           
            clone.transform.position = previewObject.transform.position;
            clone.transform.eulerAngles = currentPartRotation;
            
            newHead.AddRobotPartgroup( clone.GetComponent<RobotPart>().partGroup );

        }
        
    }
}
