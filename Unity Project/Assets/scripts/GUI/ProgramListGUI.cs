using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramListGUI : MonoBehaviour
{
    [SerializeField]
    Computer computer;

    [SerializeField]
    GameObject programsGUIParent;

    [SerializeField]
    GameObject programsParent;

    ProgramableObject[] allPrograms;

    [SerializeField]
    GameObject program;

    [SerializeField]
    ProgramParentGUI parentGUI;

    [SerializeField]
    public InputField newProgramName;

    [SerializeField]
    GameObject simpleCommandTypesParent;

    [SerializeField]
    bool displayTitleList= true;

    [SerializeField]
    bool displaySelected= true;

    [SerializeField]
    GameObject selectedParent;

    [SerializeField]
    GameObject programPannel;

    [SerializeField]
    ProgramGUI selectedProgramGUI;



    CommandType[] simpleCommandTypes;


    ProgramableObject selected; 
    // Start is called before the first frame update
    void Start()
    {
        TurnOffSelectedProgrammableObject();

    }

    void Update(){
       
    }
    public void TurnOnSelf(){
        Display();
    }

    public void SetSelectedProgrammableObject(ProgramableObject po){
        selected = po;
        
        displaySelected = true;
        Display();
    }

    public bool DisplayingSelectedObject(){
        return displaySelected;
    }

    public ProgramableObject GetSelectedProgrammableObject(){
        return selected;
    }

    public void TurnOffSelectedProgrammableObject(){

        displaySelected = false;
        Display();
    }



    public void Display() {

        if(displaySelected) {
                
            selectedProgramGUI.GetComponent<ProgramGUI>().programableObject = selected;
            selectedProgramGUI.GetComponent<ProgramGUI>().SetSimpleCommands(simpleCommandTypes);
            selectedProgramGUI.GetComponent<ProgramGUI>().Display();
            programPannel.gameObject.SetActive(true);

        }
        else {

            programPannel.gameObject.SetActive(false);

            foreach(Transform t in programsGUIParent.GetComponentsInChildren<Transform>()) {
                if(t.gameObject != programsGUIParent.gameObject)
                {
                    GameObject.Destroy(t.gameObject);
                }
            }

            simpleCommandTypes = simpleCommandTypesParent.GetComponentsInChildren<CommandType>();

            if(displayTitleList){

                allPrograms = computer.GetPrograms().GetComponentsInChildren<ProgramableObject>();

            
                foreach(ProgramableObject p in allPrograms) {
                    GameObject clone = CreateProgramGUIObject(p, simpleCommandTypes);
                    clone.GetComponent<ProgramTitleGUI>().selectButton.onClick.AddListener(() => SetSelectedProgrammableObject(p));
                    clone.GetComponent<ProgramTitleGUI>().programableObject = p;
                }
            }
        }

    }

    GameObject CreateProgramGUIObject(ProgramableObject p, CommandType[]  simpleCommandTypes){
        GameObject clone;
        clone = Instantiate(program);
        clone.transform.SetParent(programsGUIParent.transform, false);
        //clone.GetComponent<ProgrammableObjectGUI>().title.text = p.title;
        //clone.GetComponent<ProgramGUI>().programableObject = p;
        //clone.GetComponent<ProgramGUI>().SetSimpleCommands(simpleCommandTypes);
        return clone;
    }



    public void UpdateGUI() {
        Display();
    }

    public void UpdateList(){
        Display();
    }




    
}
