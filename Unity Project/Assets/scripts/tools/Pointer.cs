using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{



    [SerializeField]
    public bool useRobotParent = true;

    [SerializeField]
     GameObject tool;


    SpringJoint2D grabJoint;

    public Vector2 mousePos2D;
    public bool didHit;


    bool usingATool = false;

    // Start is called before the first frame update
    void Start()
    {
        Tool[] tools = gameObject.GetComponentsInChildren<Tool>();

        foreach(Tool t in tools){
            t.pointer = this;
        }
    }
     public Ray ray;
     public RaycastHit hit;

     public void SetTool(Tool newTool){
            if(tool){
                tool.SendMessage("OnTurnToolOn", this.gameObject);
            }
            if(newTool){
                tool = newTool.gameObject;

                tool.SendMessage("OnTurnToolOff", this.gameObject);
            }
     }
     public Tool GetTool(){
         return tool.GetComponent<Tool>();
     }
    void LateUpdate () {

        

        
        if(tool){
            Camera camera = null;
            if(GetTool().useMainCamera){
                camera = Camera.main;
            }
            else {
                camera = GetTool().camera;
            }
            

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, tool.GetComponent<Tool>().layerMask))
            {
                
                didHit = true;
                if (Input.GetMouseButtonDown(1)) {
                    UpdateTool();

                }

                UpdateHit();
            }
            else
            {
                UpdateMiss();
            }
        }

    }

    void UpdateHit(){
        if(tool){
            tool.SendMessage("UseHit", gameObject);
        }

    }

    void UpdateMiss(){
        if(tool){
            tool.SendMessage("UseMiss", gameObject);
        }

    }

    void UpdateTool(){
        if(tool){
        
            tool.SendMessage("UseTool", gameObject);
        }
    }
}
