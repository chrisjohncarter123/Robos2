using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPartDetailsTool : MonoBehaviour
{

    public enum Target{
        PartDetails,
        Computer,
        Hologram
    }
    public Target target;

    public HologramHead hologramHead;

    RobotPart robotPart;
    public PartDetailsMenuGUI detailsMenuGUI;

    public GameObject menuGameObject;

    



    public RobotPart partSelected;


    Tool tool;

    public Screen screen;



    // Start is called before the first frame update
    void Start()
    {
        menuGameObject.SetActive(false);
        tool = GetComponent<Tool>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTurnToolOn(GameObject pointer){

    }

    public void OnTurnToolOff(GameObject pointer){
        CloseScreen();
    }

    public void UseHit(GameObject pointer ){
        Pointer p = pointer.GetComponent<Pointer>();

        GameObject hit = p.hit.collider.gameObject;
     
        if(IsATarget(hit)){
            tool.UpdatePreviewCube(hit.transform);
        }
        else {
            tool.UpdatePreviewCube(null);

        }
        if(partSelected){
            if(hit.gameObject.layer != 11 && hit != partSelected.gameObject) {
            
                CloseScreen();
            }
                 
        }
           

    }

    public void UseMiss(GameObject pointer){
      
        if(partSelected){
            
            CloseScreen();
        }

    }

    void CloseScreen(){
       
      
        partSelected = null;
        tool.UpdatePreviewCube(null);
        tool.UpdateSelectionCube(null);
    }

    bool IsATarget(GameObject go){

        if(go.GetComponent<SelectPartTarget>()){
            if(go.GetComponent<SelectPartTarget>().target == target) {
                return true;
                
            }
        }

        if(target == Target.Computer){
            if(go.GetComponent<Computer>()){
                return true;
            }
             
            return false;

        }
        else if (target == Target.PartDetails) {
             if(go.GetComponent<RobotPart>()){
                return true;
            }
            return false;

        } else if (target == Target.Hologram){
            return true;
        }
        

        return false;
    }
    public void UseTool(GameObject pointer ){

        

        Pointer p = pointer.GetComponent<Pointer>();

        GameObject hit = p.hit.collider.gameObject;

        Debug.Log(hit.name);

        if( IsATarget( hit) ){
            
            GameObject hitGameObject = hit;
            RobotPart hitRobotPart = null;

            if(hit.GetComponent<SelectPartTarget>()){
                hitRobotPart = hit.GetComponent<SelectPartTarget>().robotPart;
            }
            else {
                hitRobotPart = hit.GetComponent<RobotPart>();

            }

            tool.UpdateSelectionCube(hitGameObject.transform);
            tool.UpdatePreviewCube(null);

            menuGameObject.SetActive(true);
            

            if(target == Target.Computer){
                hitGameObject.GetComponent<Computer>().computerGUI.onOffGUI.TurnOn();
                screen = hitGameObject.GetComponent<Computer>().computerGUI.screen;
                screen.TurnScreenOn(hitGameObject.transform);
            }
            else if (target == Target.PartDetails){
                detailsMenuGUI.SelectPart(hitGameObject.GetComponent<RobotPart>());
                screen = detailsMenuGUI.screen;
                screen.TurnScreenOn(hitGameObject.transform);
            }
            else if (target == Target.Hologram){
                hologramHead.CreateHologram(hitRobotPart.robotHead.gameObject);
                hologramHead.transform.position = hitGameObject.transform.position;
            }

            

            /*

            menuGameObject.transform.position = hit.transform.position + menuPositionOffset;

            if(distanceMode == DistanceMode.Dynamic){
                 Vector3 direction = Vector3.Normalize(tool.camera.transform.position - partSelected.transform.position);
                float distance = Vector3.Distance(tool.camera.transform.position, partSelected.transform.position);
                float offset = distance - menuDistanceOffset;
                menuGameObject.transform.position += direction * offset;

            }

           

            menuGameObject.transform.LookAt(tool.camera.transform.position);
            menuGameObject.transform.localEulerAngles += localScreenRotation;
            */


            

            
            
           
 
        }

    }
}
