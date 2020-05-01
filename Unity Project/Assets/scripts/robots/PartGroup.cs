using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartGroup : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }
    static int partGroupCounter = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMass(){
        Debug.LogError("TODO: SetMass of PartGroup");
    }

    public static GameObject CreateNewPartGroup(Vector3 position, Vector3 rotation, RobotHead robotHead){
        GameObject newGroup = new GameObject();
        newGroup.transform.position = position;
        newGroup.transform.eulerAngles = rotation;
        Rigidbody rb = newGroup.AddComponent<Rigidbody>();
        rb.drag = 0;
        rb.angularDrag = 0;
        PartGroup partGroup = newGroup.AddComponent<PartGroup>();
        newGroup.name = "Part Group " + partGroupCounter++;

        robotHead.AddRobotPartgroup(newGroup.GetComponent<PartGroup>());
        
        return newGroup;

    }

    public void AddToPartGroup(RobotPart robotPart){
        robotPart.gameObject.transform.SetParent(transform);
        robotPart.partGroup = this;
        


    }


}
