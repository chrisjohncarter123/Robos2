using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutLineGUI : MonoBehaviour
{

    LineGUI lineGUI;
    NodePutGUI nodePut;
    NodePutGUI endPut;
    int seperation = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(!lineGUI){
            CreateLineObject();
        }
    }

    public void SetLineColor(Color color){
        if(!lineGUI){
            CreateLineObject();
        }
        lineGUI.SetLineColor(color);

    }

    public void SetLineWidth(float width){
        if(!lineGUI){
            CreateLineObject();
        }
        lineGUI.SetLineWidth(width);

    }

     public void SetLineBase(GameObject lineBase){
        if(!lineGUI){
            CreateLineObject();
        }
        lineGUI.SetLineBase(lineBase);

    }

    public void SetLineParent(Transform lineParent){
        if(!lineGUI){
            CreateLineObject();
        }
        lineGUI.SetLineParent(lineParent);
    }

    public void SetLineSeperation(int seperation){
        this.seperation = seperation;
    }

    void CreateLineObject(){
        GameObject line = new GameObject();
        line.name = "Line";
        line.AddComponent<RectTransform>();
        line.transform.SetParent(transform);
        lineGUI = line.AddComponent<LineGUI>();
        
        lineGUI.SetLineWidth(5);

    }
    



    // Update is called once per frame
    void Update()
    {
        if(nodePut && endPut){

            if(!lineGUI.GetIsDrawing()){
                lineGUI.CreateLine();
            }
           //update line
           lineGUI.UpdateLine(
               nodePut,
               endPut,
               seperation);
        }
        else{
            lineGUI.TryDestroyLine();
        }
    }

    public void SetPut(NodePutGUI nodePut){
        this.nodePut = nodePut;

    }

    public void StartLine(NodePutGUI end){
        this.endPut = end;

    }

    public void EndLine(){
        lineGUI.TryDestroyLine();

    }

    public bool GetIsDrawing(){
        return lineGUI.GetIsDrawing();
    }
}
