using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectComputer : MonoBehaviour
{

    public ComputerGUI computerGUI;


    [SerializeField]
    GameObject previewObject;



    [SerializeField]
    SelectionType selectionType = SelectionType.Computer;

    [SerializeField]
    ProgramListGUI listGUI;

    [SerializeField]
    ToggleProgrammingScreen progToggle;

    enum SelectionType{
        Computer,
        Command

    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTurnToolOn(GameObject pointer){

    }

    public void OnTurnToolOff(GameObject pointer){

    }

    public void UseHit(GameObject pointer ){
        Pointer p = pointer.GetComponent<Pointer>();
        GameObject hit = p.hit.collider.gameObject;

        if(hit.GetComponent<Computer>() && selectionType == SelectionType.Computer){
            
            TurnPreviewOn(hit.transform);
            

        }
        else if(hit.GetComponent<RobotPart>() && selectionType == SelectionType.Command){
            if(hit.GetComponent<RobotPart>().HasCommandType()){
                TurnPreviewOn(hit.transform);


            }
        }
        else {
            TurnPreviewOff();
        }

    }
    void TurnPreviewOn(Transform t){

        previewObject.GetComponent<Renderer>().enabled = true;
        previewObject.transform.position = t.position;
        previewObject.transform.rotation = t.rotation;

        previewObject.GetComponent<Renderer>().enabled = true;

    }
    void TurnPreviewOff(){
        previewObject.GetComponent<Renderer>().enabled = false;
        previewObject.GetComponent<Renderer>().enabled = false;
    }
    public void UseMiss(GameObject p){
        TurnPreviewOff();

    }

    public void UseTool(GameObject pointer ){

        Pointer p = pointer.GetComponent<Pointer>();
        
        bool didHit = p.didHit;
        Vector2 mousePos2D = p.mousePos2D;

        GameObject hit = p.hit.collider.gameObject;


        if(selectionType == SelectionType.Computer){
            if(hit.GetComponent<Computer>()){
                //Computer.SetSelectedComputer(hit.GetComponent<Computer>());
                computerGUI.UpdateComputerGUI();
                progToggle.SetToggle(true);
            }
        }
        else if(selectionType == SelectionType.Command){
            
            if(hit.GetComponent<RobotPart>()){
  
                if(hit.GetComponent<RobotPart>().HasCommandType()){

 
                    CommandType commandType = hit.GetComponent<RobotPart>().GetCommandType();

                    listGUI.GetSelectedProgrammableObject().AddCommand(commandType.gameObject);

                    computerGUI.UpdateComputerGUI();

                    progToggle.SetToggle(true);

                }
                /*
                Computer.SetSelectedComputer(hit.GetComponent<Computer>());
                computerGUI.UpdateComputerGUI();
                */
            }

        }
        
        

    }
}
