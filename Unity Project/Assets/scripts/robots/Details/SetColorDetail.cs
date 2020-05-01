using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorDetail : MonoBehaviour
{

    public Color color = Color.Red;
    PartDetail detail;

    RobotPart robotPart;
    public enum Color{
        Red,
        Green,
        Blue
    }
    Argument argument;
    float value;
    // Start is called before the first frame update
    void Start()
    {
        argument  = GetComponent<Argument>();
        detail = GetComponent<PartDetail>();
        robotPart = detail.GetRobotPart();

    }

    // Update is called once per frame
    void Update()
    {
        value = argument.GetValue() / 100f;

        if(value != null){
            switch(color){
                case Color.Red:
                    robotPart.SetRobotMaterialRed(value);
                    break;

                case Color.Green:
                    robotPart.SetRobotMaterialGreen(value);
                    break;

                case Color.Blue:
                    robotPart.SetRobotMaterialBlue(value);
                    break;

            }
        }
    }
}
