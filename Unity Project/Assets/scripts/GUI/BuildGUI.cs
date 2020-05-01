using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildGUI : MonoBehaviour
{


    [SerializeField]
    Transform toolsParentGUI;

    [SerializeField]
    GameObject tool;

    [SerializeField]
    GameObject toolTitle;

    [SerializeField]
    GameObject selectedTool;

    [SerializeField]
    GameObject toolsParent;

    [SerializeField]
    bool autoGenerateTools = true;

    [SerializeField]
    Tool[] tools;


    [SerializeField]
    Pointer pointer;





    // Start is called before the first frame update
    void Start()
    {

        Display();


    }
    public void TurnOnSelf(){
        Display();
    }

    public void Display() {
        TurnOffSelf();


        foreach(Transform toolTransform in toolsParent.GetComponentsInChildren<Transform>()) {
            GameObject t = toolTransform.gameObject;
            GameObject clone = null;


            if(t.GetComponent<ToolTitle>()){
                
                clone = Instantiate(toolTitle);
                clone.GetComponent<ToolGUI>().title.text = t.GetComponent<ToolTitle>().toolTitle;
                clone.transform.SetParent(toolsParentGUI, false);

            }
            else if(t.GetComponent<Tool>()){
                if(t.GetComponent<Tool>() == pointer.GetTool()){
                    clone = Instantiate(selectedTool);
                }
                else {
                
                    clone = Instantiate(tool);
                    
                }
                clone.GetComponent<ToolGUI>().title.text = t.GetComponent<Tool>().title;
                clone.GetComponent<ToolGUI>().description.text = t.GetComponent<Tool>().description;
                clone.GetComponent<Button>().onClick.AddListener(() => SetTool(t.GetComponent<Tool>()));
                clone.transform.SetParent(toolsParentGUI, false);
            }
            

            
        }
    }

    void SetTool(Tool t){
        t.SetTool();
        Display();
    }

    public void TurnOffSelf(){

        foreach(Transform t in toolsParentGUI.GetComponentsInChildren<Transform>()) {
            if(t.gameObject != toolsParentGUI.gameObject)
            {
                GameObject.Destroy(t.gameObject);
            }
        }
    } 

    public void UpdateGUI() {
        //Display();


    }
}
