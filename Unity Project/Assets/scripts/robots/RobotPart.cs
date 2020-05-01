using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : MonoBehaviour
{
    public string partName = "New Robot Part!!";

    public PartGroup partGroup;

    public GameObject connectionPoints;

    public RobotHead robotHead;

    public GameObject wiringGUI;

    [SerializeField]
    GameObject wiringGuiNodeBase;

    PartDetail[] details;

    [SerializeField]
    bool initializeDetailsFromChildren = true;


    GameObject partDetailsMenu;

    // Start is called before the first frame update
    void Start()
    {
        TransformHelper.SetLayerOfAllChildren(connectionPoints, TransformHelper.ConnectionPointsLayer);

        if(initializeDetailsFromChildren){
            details = GetComponentsInChildren<PartDetail>();
        
        }

        foreach (PartDetail d in details){
            d.SetRobotPart(this);
        }
        
      
    }

    static bool initScene = false;

    public GameObject GetWiringGUI(){
        return wiringGUI;
    }
    // Update is called once per frame
    void Update()
    {
        
        if(partGroup == null){

            if(robotHead == null){
                robotHead = RobotHead.CreateNewRobotHead();
                
            
            }


             PartGroup.CreateNewPartGroup(transform.position, transform.eulerAngles, robotHead).GetComponent<PartGroup>().AddToPartGroup(this);
           

            robotHead.AddRobotPartgroup(partGroup);
            
        }   
        

        
        
    }

    public RobotPartMaterial[] GetRobotPartMaterials(){
        return GetComponentsInChildren<RobotPartMaterial>();
    }


    public bool HasCommandType(){
        if(GetComponentsInChildren<CommandType>().Length > 0){
            return true;
        }
        return false;
    }

    public CommandType GetCommandType(){
        return GetComponentInChildren<CommandType>();

    }

    public void SetRobotMaterial(Color color){
        foreach(RobotPartMaterial m in GetRobotPartMaterials()){
            m.SetColor(color);
        }

    }

    public void SetRobotMaterialRed(float value){
        foreach(RobotPartMaterial m in GetRobotPartMaterials()){
            m.SetRed(value);
        }

    }

    public void SetRobotMaterialGreen(float value){
        foreach(RobotPartMaterial m in GetRobotPartMaterials()){
            m.SetGreen(value);
        }

    }

    public void SetRobotMaterialBlue(float value){
        foreach(RobotPartMaterial m in GetRobotPartMaterials()){
            m.SetBlue(value);
        }

    }

    public void SetRobotLayer(){
        gameObject.layer = TransformHelper.robotLayer;
    
    }

    public void SetWiringLayer(){
        gameObject.layer = TransformHelper.wiringShowLayer;

    }

    public PartDetail[] GetPartDetails(){
        return details;

    }



}
