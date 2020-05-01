using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachTool : MonoBehaviour
{

    [SerializeField]
    GameObject previewObject;

    [SerializeField]
    GameObject selectPreviewObject;

    GameObject selectObject;

    [SerializeField]
    float rotateSpeed = .1f;

    [SerializeField]
    float groundYOffset = 4.1f;

    Vector3 currentPartRotation = Vector3.zero;
    Vector3 currentPreviewRotation;

    AttachState attachState;
    enum AttachState{
        None,
        Selected
    }


    bool setPreview = false;
    // Start is called before the first frame update
    void Start()
    {
        attachState = AttachState.None;
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
        

        if(hit.GetComponent<ConnectionPoint>()){
             if(attachState == AttachState.None){
                selectObject = hit.GetComponent<ConnectionPoint>().GetRobotPart().gameObject;
                attachState = AttachState.Selected;
                selectPreviewObject.transform.SetParent(selectObject.transform);
                selectPreviewObject.transform.eulerAngles = selectObject.transform.eulerAngles;
                selectPreviewObject.SetActive(true);
            
             }
             else if(attachState == AttachState.Selected){

                if(previewObject.GetComponent<ErrorCube>().IsTouchingAnything()) {
                    return;
                }

                Rigidbody rb = selectObject.GetComponent<Rigidbody>();

                ConnectionPoint connection = hit.GetComponent<ConnectionPoint>();

                selectObject.transform.position = previewObject.transform.position;
                selectObject.transform.eulerAngles = previewObject.transform.eulerAngles;
                
                selectObject.GetComponent<RobotPart>().robotHead = hit.GetComponent<ConnectionPoint>().GetRobotPart().robotHead;

                hit.GetComponent<ConnectionPoint>().SetJoint(p, selectObject, connection, hit.GetComponent<ConnectionPoint>().GetPartGroup());

             }

        }
        
    }
}
