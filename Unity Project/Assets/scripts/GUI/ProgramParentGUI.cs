using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgramParentGUI : MonoBehaviour
{
   // [SerializeField]
  //  ProgramGUI programGUI;

    [SerializeField]
    ProgramListGUI listGUI;

    [SerializeField]
    Tool commandTypeTool;


    // Start is called before the first frame update
    void Start()
    {
     //   SetProgramList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    public void SetProgramList(){
        //programGUI.gameObject.SetActive(false);
        listGUI.gameObject.SetActive(true);

        listGUI.UpdateGUI();

        
    }
    */

    /*
    public void SetProgram(ProgramableObject po){
        listGUI.gameObject.SetActive(false);
        programGUI.gameObject.SetActive(true);

        ProgramableObject.SetCurrentProgramableObject(po);

        programGUI.TurnOnSelf();

        commandTypeTool.SetTool();

        
    }
    */
}
