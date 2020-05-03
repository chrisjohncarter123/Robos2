using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLineGUI : MonoBehaviour
{
   private bool dragging;
    public LineGUI line;

    void Start() {
        
        
    }

    public void Update() {
        if(dragging)
        {
            line.UpdateLineToMouse();
        }
        
    }

    public void StartMouseLine(NodePutGUI nodePutGUI){
        dragging = true;

        Vector2 lineStart = 
            new Vector2(
                Input.mousePosition.x,
                Input.mousePosition.y);

        line.CreateLine(lineStart);

        
    }

    public void EndMouseLine(){
        dragging = false;
        line.TryDestroyLine();

        
    }
}
/*



    1. User clicks on NodePut
    2. Drag Line


*/