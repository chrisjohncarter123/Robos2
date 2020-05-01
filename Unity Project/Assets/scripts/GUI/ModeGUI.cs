using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeGUI : MonoBehaviour
{
    [SerializeField]
    GameObject play;

    [SerializeField]
    GameObject program;


    [SerializeField]
    GameObject build;


    [SerializeField]
    BuildGUI buildGUI;

    [SerializeField]
    ProgramGUI programGUI;


    [SerializeField]
    Pointer pointer;

    [SerializeField]
    ProgramListGUI programListGUI;


    [SerializeField]
    ToggleProgrammingScreen pScreen;

    // Start is called before the first frame update
    void Start()
    {
        SetProgramMode();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayMode()
    {
        play.SetActive(true);
        program.SetActive(false);
        build.SetActive(false);
        pointer.SetTool(null);
        //Computer.GetSelectdComputer().GetPrograms().RunAllPrograms();


    }

    public void SetProgramMode(){
    //    play.SetActive(false);
    //    program.SetActive(true);
    //    build.SetActive(true);
     //   pointer.SetTool(null);
      //  pScreen.SetToggle(false);
       // buildGUI.TurnOnSelf();
     //   programListGUI.TurnOnSelf();
     // programGUI.TurnOffSelf();

    }


    public void SetBuildMode(){
        play.SetActive(false);
        program.SetActive(false);
        build.SetActive(true);
        buildGUI.TurnOnSelf();
    }
}
