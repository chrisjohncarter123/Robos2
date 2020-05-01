using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    Vector3 rotOffset;

    [SerializeField]
    public GameObject baseGameObject;

    public Rigidbody baseRigidBody;
    
    [SerializeField]
    public JointType jointType = JointType.Fixed;

    [SerializeField]
    Vector3 anchor;

    [SerializeField]
    Vector3 axis;

    [SerializeField]
    bool autoCalculateOffset = true;

    [SerializeField]
    float constantOffset = 4.1f;

    

    
    Renderer renderer;
  



    public enum JointType{
        Fixed,
        Motor,
        Elbow,
        BallAndSocket,
        Piston

    }

    public static void ResetPartGroups(){

        /*
            List partsToSort = AllPoints

            foreach(ConnectionPoint p in AllPoints){
                GameObject group1 = new PartGroup;
                foreach(Point connected to p){
                    Add Point to group1
                    remove Point from partsToSort

                }

            }
        */
    }

    
    public RobotPart GetRobotPart(){
        return baseGameObject.GetComponent<RobotPart>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        baseRigidBody = baseGameObject.GetComponent<Rigidbody>();

        renderer = GetComponent<Renderer>();
        HideConnectionPoint();


        //Calculate offset
        if(autoCalculateOffset){

            Vector3 distance = transform.localPosition;
            Vector3 normalized = Vector3.Normalize(distance);
            offset = normalized * constantOffset;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowConnectionPoint(){
        renderer.enabled = true;

    }

    public void HideConnectionPoint(){
        renderer.enabled = false;
    }

    public PartGroup GetPartGroup(){
        return baseGameObject.GetComponent<RobotPart>().partGroup;
    }

    public Vector3 GetConnectPosition(){
        Vector3 right = baseGameObject.transform.right * offset.x;
        Vector3 up = baseGameObject.transform.up * offset.y;
        Vector3 forward = baseGameObject.transform.forward * offset.z;
        return baseGameObject.transform.position + right + up + forward;
    }

    public Vector3 GetConnectRotation(){
        Vector3 rot = baseGameObject.transform.eulerAngles;
        rot.x += rotOffset.x;
        rot.y += rotOffset.y;
        rot.z += rotOffset.z;
        return rot;
    }

    public void SetJoint(Pointer p, GameObject clone, ConnectionPoint otherPoint, PartGroup oldPartGroup){

        RobotHead robotHead = otherPoint.GetRobotPart().robotHead;
            if( jointType == JointType.Fixed){
                clone.gameObject.transform.SetParent(oldPartGroup.transform);
                if(clone.gameObject.GetComponent<Rigidbody>()){
                    Destroy(clone.GetComponent<Rigidbody>());
                }

                clone.GetComponent<RobotPart>().partGroup = oldPartGroup;

            } else if (jointType == JointType.Motor) {

                GameObject newGroup = PartGroup.CreateNewPartGroup(clone.transform.position, Vector3.zero, robotHead);
                

                HingeJoint hingeJoint = newGroup.AddComponent<HingeJoint>();

                clone.gameObject.transform.SetParent(newGroup.transform);

                hingeJoint.connectedBody = oldPartGroup.gameObject.GetComponent<Rigidbody>();

                Vector3 difference = clone.transform.position - otherPoint.baseGameObject.GetComponent<RobotPart>().transform.position;


                Vector3 normalized = Vector3.Normalize(difference);
                normalized *= -1;



                hingeJoint.autoConfigureConnectedAnchor = false;
                //Set connected anchor equal to the difference in position between the two objects
                hingeJoint.connectedAnchor = otherPoint.baseGameObject.GetComponent<RobotPart>().transform.localPosition;
                hingeJoint.anchor = normalized;
                hingeJoint.axis = normalized;

                clone.GetComponent<RobotPart>().partGroup = newGroup.GetComponent<PartGroup>();;

           } else if (jointType == JointType.Elbow) {



                RobotHead newHead = RobotHead.CreateNewRobotHead();

                GameObject newGroup = PartGroup.CreateNewPartGroup(clone.transform.position, Vector3.zero, robotHead);

                HingeJoint hingeJoint = newGroup.AddComponent<HingeJoint>();

                clone.gameObject.transform.SetParent(newGroup.transform);

                hingeJoint.connectedBody = oldPartGroup.gameObject.GetComponent<Rigidbody>();

                Vector3 difference = clone.transform.position - otherPoint.baseGameObject.GetComponent<RobotPart>().transform.position;


                Vector3 normalized = Vector3.Normalize(difference);
                normalized *= -1;


                hingeJoint.autoConfigureConnectedAnchor = false;
                //Set connected anchor equal to the difference in position between the two objects
                hingeJoint.connectedAnchor = otherPoint.baseGameObject.GetComponent<RobotPart>().transform.localPosition;

                Vector3 left = Vector3.Cross(normalized, Vector3.up).normalized;
                hingeJoint.anchor = normalized;
                hingeJoint.axis = left;

                clone.GetComponent<RobotPart>().partGroup = newGroup.GetComponent<PartGroup>();;

           } 
           else if (jointType == JointType.BallAndSocket) {

               RobotHead newHead = RobotHead.CreateNewRobotHead();

                GameObject newGroup = PartGroup.CreateNewPartGroup(clone.transform.position, Vector3.zero, robotHead);

                ConfigurableJoint pistonJoint = newGroup.AddComponent<ConfigurableJoint>();

                clone.gameObject.transform.SetParent(newGroup.transform);

                pistonJoint.connectedBody = oldPartGroup.gameObject.GetComponent<Rigidbody>();

                Vector3 difference = clone.transform.position - otherPoint.baseGameObject.GetComponent<RobotPart>().transform.position;


                Vector3 normalized = Vector3.Normalize(difference);
                normalized *= -1;



                pistonJoint.autoConfigureConnectedAnchor = false;
                //Set connected anchor equal to the difference in position between the two objects
                pistonJoint.connectedAnchor = otherPoint.baseGameObject.GetComponent<RobotPart>().transform.localPosition;
                pistonJoint.anchor = normalized;
                pistonJoint.axis = normalized;

                pistonJoint.xMotion = ConfigurableJointMotion.Locked;
                pistonJoint.yMotion = ConfigurableJointMotion.Locked;
                pistonJoint.zMotion = ConfigurableJointMotion.Locked;

                pistonJoint.angularXMotion = ConfigurableJointMotion.Free;
                pistonJoint.angularYMotion = ConfigurableJointMotion.Free;
                pistonJoint.angularZMotion = ConfigurableJointMotion.Free;

                SoftJointLimit softJointLimit = new SoftJointLimit();
                softJointLimit.limit = 1f;
                pistonJoint.linearLimit = softJointLimit;

                JointDrive jd = new JointDrive();
           //     jd.maximumForce = 50000;
                jd.positionSpring = 0;
                jd.positionDamper = 0;
                pistonJoint.xDrive = jd;


                pistonJoint.targetPosition = new Vector3(3,0,0);

                clone.GetComponent<RobotPart>().partGroup = newGroup.GetComponent<PartGroup>();;

           }
           else if (jointType == JointType.Piston) {



               RobotHead newHead = RobotHead.CreateNewRobotHead();

                GameObject newGroup = PartGroup.CreateNewPartGroup(clone.transform.position, Vector3.zero, robotHead);

                ConfigurableJoint pistonJoint = newGroup.AddComponent<ConfigurableJoint>();

                clone.gameObject.transform.SetParent(newGroup.transform);

                pistonJoint.connectedBody = oldPartGroup.gameObject.GetComponent<Rigidbody>();

                Vector3 difference = clone.transform.position - otherPoint.baseGameObject.GetComponent<RobotPart>().transform.position;


                Vector3 normalized = Vector3.Normalize(difference);
                normalized *= -1;



                pistonJoint.autoConfigureConnectedAnchor = false;
                //Set connected anchor equal to the difference in position between the two objects
                pistonJoint.connectedAnchor = otherPoint.baseGameObject.GetComponent<RobotPart>().transform.localPosition;
                pistonJoint.anchor = normalized;
                pistonJoint.axis = normalized;

                pistonJoint.xMotion = ConfigurableJointMotion.Limited;
                pistonJoint.yMotion = ConfigurableJointMotion.Locked;
                pistonJoint.zMotion = ConfigurableJointMotion.Locked;

                pistonJoint.angularXMotion = ConfigurableJointMotion.Locked;
                pistonJoint.angularYMotion = ConfigurableJointMotion.Locked;
                pistonJoint.angularZMotion = ConfigurableJointMotion.Locked;

                SoftJointLimit softJointLimit = new SoftJointLimit();
                softJointLimit.limit = 5f;
                pistonJoint.linearLimit = softJointLimit;

                JointDrive jd = new JointDrive();
           //     jd.maximumForce = 50000;
                jd.positionSpring = 10;
                jd.positionDamper = 0;
                pistonJoint.xDrive = jd;


                pistonJoint.targetPosition = new Vector3(3,0,0);

                clone.GetComponent<RobotPart>().partGroup = newGroup.GetComponent<PartGroup>();;

           }
        }
        
    
}
