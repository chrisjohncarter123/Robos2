using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartDetailGUI : MonoBehaviour
{
    
    [SerializeField]
    Text titleText;
    
    [SerializeField]
    Text descriptionText;

   [SerializeField]
    Dropdown variableDropdown;

    RobotPart robotPart;

    Variable selectedVariable;


    public PartDetail partDetail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDropdownSelect(){

        selectedVariable = null;

        partDetail.SetVariable(selectedVariable);

    }

    public void SetDetailGUI(RobotPart rp, PartDetail detail){
        robotPart = rp;

        this.partDetail = detail;
        this.titleText.text = partDetail.title;
        this.descriptionText.text = partDetail.description;


    }

}
