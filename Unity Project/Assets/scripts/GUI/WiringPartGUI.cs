using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiringPartGUI : MonoBehaviour
{
    public GameObject parent;
    public RobotPart robotPart;

    public Text titleText;

    public GameObject detailsParent;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRobotPart(RobotPart robotPart){
        this.robotPart = robotPart;
        titleText.text = robotPart.partName;
    }

    public void SetWiringActive(bool value){

        parent.SetActive(value);

        if(value == true){
            foreach(ArgumentGUI gui in argumentGUIs){
                
                if(robotPart.robotHead.HasAComputer()){
                    gui.SetPrograms(robotPart.robotHead.GetAllPrograms()[0]);
                    gui.PopulateVariableDropdowns();
                }
                
            }

        }


    }
    List<ArgumentGUI> argumentGUIs;

    PartDetail[] details;

    ArgumentGUI[] arguments;

    public void InitDetails(RobotPart rp, GameObject detailsParentBase){
        foreach(Transform go in detailsParent.GetComponentsInChildren<Transform>()){
            if(go != detailsParent.transform){
                Destroy(go.gameObject);
            }

        }

        robotPart = rp;

        details = robotPart.GetPartDetails();


        argumentGUIs = new List<ArgumentGUI>();
        

        foreach(PartDetail detail in details){
            GameObject newDetailGUIParent = Instantiate(detailsParentBase);
            newDetailGUIParent.transform.SetParent(detailsParent.transform, false);

            PartDetailGUI detailGUI = newDetailGUIParent.GetComponent<PartDetailGUI>();
            detailGUI.SetDetailGUI(robotPart, detail);

           ArgumentGUI argumentGUI = newDetailGUIParent.GetComponent<ArgumentGUI>();
            argumentGUIs.Add(argumentGUI);


            Programs p = null;
            if(rp.robotHead.HasAComputer()){
                p = rp.robotHead.GetAllPrograms()[0];

            }

            

            argumentGUI.SetArgumentGUI(detail.GetArgument() ,null, p);

           
        }

        


        

    }
}
