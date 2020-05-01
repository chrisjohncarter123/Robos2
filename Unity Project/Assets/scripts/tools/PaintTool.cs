using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintTool : MonoBehaviour
{


   public Color color;

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

    }

    public void UseMiss(GameObject p){
   

    }

    public void UseTool(GameObject pointer ){
        Pointer p = pointer.GetComponent<Pointer>();
        
        GameObject hit = p.hit.collider.gameObject;
        if(hit.GetComponent<RobotPartMaterial>()){

            hit.GetComponent<RobotPartMaterial>().SetColor(color);

        }

    }
}
