using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineGUI : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GameObject lineBase;

    [SerializeField]
    GameObject lineEndBase;

    public float lineWidth = 3;
    public Color lineColor;

    GameObject lineLeft, lineCenter, lineRight;

    Vector2 lineStart, lineEnd;


    bool isDrawing = false;

    public bool GetIsDrawing(){return isDrawing;}

    const float seperationDistance = 20;

    Transform lineParent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLine(Vector2 lineStart, float lineWidth, Color lineColor){

        TryDestroyLine();

        this.lineStart = lineStart;
        SetLineWidth(lineWidth);
        SetLineColor(lineColor);

        lineLeft = CreateLineSegment("Left Line");
        lineCenter = CreateLineSegment( "Center Line");
        lineRight = CreateLineSegment( "Right Line");

        lineParent = transform;

        

        isDrawing = true;

    }

    public void CreateLine(float lineWidth, Color lineColor){
        Vector2 lineStart = new Vector2(
            GetComponent<RectTransform>().rect.x,
            GetComponent<RectTransform>().rect.y
        );
        CreateLine(lineStart, lineWidth, lineColor);

    }

    public void CreateLine(){
        CreateLine(lineWidth, lineColor);
    }

    public void CreateLine(NodePutGUI nodePut){
        CreateLine();

        
        lineStart = new Vector2(
            RectTransformToScreenSpace(
                nodePut.GetComponent<RectTransform>()).x,
            RectTransformToScreenSpace(
                nodePut.GetComponent<RectTransform>()).y);

        

    }

    public void CreateLine(Vector2 position){
        
        CreateLine();

        lineStart = position;
    }

    GameObject CreateLineSegment( string name){
        GameObject line = Instantiate(lineBase);
        line.name = name;
        line.transform.SetParent(transform);
        return line;
    }
    public void SetLineColor(Color lineColor){
        this.lineColor = lineColor;

    }

    public void SetLineWidth(float lineWidth){
        this.lineWidth = lineWidth;

    }
    public void SetLineBase(GameObject lineBase){
        this.lineBase = lineBase;
    }

    public void SetLineParent(Transform parent){
        this.lineParent = parent;
    }

    public void TryUpdateLine(bool test, RectTransform lineEnd){
        if(test){
            UpdateLine(lineEnd);
        }else {
            TryDestroyLine();
        }
    }
    public GameObject start;
    public GameObject end;

    public void UpdateLine(GameObject start, GameObject end, int seperation){


        transform.localScale = new Vector3(1,1,1);

        this.end = end;
        this.start = start;


        GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
        GetComponent<RectTransform>().anchorMin = new Vector2(.5f,.5f);
        GetComponent<RectTransform>().anchorMax = new Vector2(.5f,.5f);


/*
        lineStart =
        new Vector2(
            start.GetComponent<RectTransform>().rect.x,
            start.GetComponent<RectTransform>().rect.y);

        Vector2 lineEnd = 
        new Vector2(
            end.GetComponent<RectTransform>().rect.x,
            end.GetComponent<RectTransform>().rect.y);
            */


            

            Vector2 pos = start.transform.position;
            lineEnd = end.transform.position;





       
        Debug.Log("hi");
        float sDist = seperation * seperationDistance;

        if(start.transform.position.y > end.transform.position.y){
            sDist *= -2;

        }
        else {
            sDist *= 2;

        }

        if(start.transform.position.x > end.transform.position.x){
            sDist *= -1;

        }
        else {
            sDist *= 1;

        }
        


    

        float leftWidth = ((start.transform.position.x - end.transform.position.x) * .5f ) / VisualProgramScalerGUI.GetCurrentScale();
        float leftX = (-leftWidth * .5f);
        if(start.transform.position.x - end.transform.position.x + sDist < 0){
            leftWidth *= -1;
            leftWidth += sDist;
        }
        else {
            leftWidth -= sDist;

        }

        UpdateLineSegment(
            new Rect (
            leftX + sDist * .5f,
            0,
            Mathf.Abs(leftWidth),
            Mathf.Abs(lineWidth)),
            lineLeft
        );


     
      float centerHeight = Mathf.Abs(start.transform.position.y - end.transform.position.y) / VisualProgramScalerGUI.GetCurrentScale();
      float centerX = (-start.transform.position.x + end.transform.position.x) * .5f / VisualProgramScalerGUI.GetCurrentScale();
      float centerY = (-start.transform.position.y + end.transform.position.y) * .5f / VisualProgramScalerGUI.GetCurrentScale();

      centerX += sDist;

         UpdateLineSegment(
            new Rect(
            centerX, 
            centerY,
            lineWidth,
            centerHeight + lineWidth),
            lineCenter
        );

        

        float rightWidth = ((start.transform.position.x - end.transform.position.x) * .5f ) / VisualProgramScalerGUI.GetCurrentScale();
         if(start.transform.position.x - end.transform.position.x < 0){
            rightWidth *= -1;
          
        }
        else {
            

        }
        float rightX = centerX + leftX;
        float rightY = centerY - centerHeight;
        if(start.transform.position.y - end.transform.position.y < 0){
            rightY = ((-start.transform.position.y + end.transform.position.y) + (0 * centerHeight)) / VisualProgramScalerGUI.GetCurrentScale();
        
        }
        else {
            rightY += centerHeight * .5f;


        }

        if(start.transform.position.x - end.transform.position.x + sDist < 0){
            rightWidth -= sDist;
        }
        else {
             rightWidth += sDist;

        }

        rightX -= sDist * .5f;
       // rightWidth += sDist;
        

        UpdateLineSegment(
            new Rect (
            rightX ,
            rightY,
            rightWidth,
            lineWidth),
            lineRight
        );
        
        



    }

    public static Rect RectTransformToScreenSpace(RectTransform transform)
     {
         Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
         return new Rect((Vector2)transform.position - (size * 0.5f), size);
     }


    public void TryUpdateLine(bool test, Vector2 lineEnd){
        if(test){
            UpdateLine(lineEnd);
        }else {
            TryDestroyLine();
        }
    }

    public void UpdateLineToMouse(){

        transform.localScale = new Vector3(1,1,1);

        Vector2 start = new Vector2(
            -UnityEngine.Screen.width / 2 + lineStart.x,
            -UnityEngine.Screen.height / 2 + lineStart.y
        );
        GetComponent<RectTransform>().anchoredPosition = start;


        Vector2 lineEnd = 
            new Vector2(
                Input.mousePosition.x,
                Input.mousePosition.y);
                
        UpdateLine(lineEnd);
    }
    public void UpdateLine(RectTransform lineEnd){
        UpdateLine(
            new Vector2(
                lineEnd.rect.x,
                 lineEnd.rect.y ));
    }
    public void UpdateLine(Vector2 lineEnd){


        this.lineEnd = lineEnd;

        Vector3 pos = lineStart;



        UpdateLineSegment(
            new Rect (
            (lineEnd.x - pos.x) / 4,
            0,
            Mathf.Abs((lineEnd.x - pos.x) / 2),
            lineWidth),
            lineLeft
        );

        float centerY = 0;
        float centerH = 0;

        if(lineEnd.y > pos.y){
            centerY = -(pos.y - lineEnd.y )  / 2;
            centerH = -pos.y + lineEnd.y;

        } else {
            centerY = -(pos.y - lineEnd.y )  / 2;
            centerH = pos.y - lineEnd.y;

        }

        centerH += lineWidth;
      // centerY -= lineWidth * .5f;

         UpdateLineSegment(
            new Rect(
            (lineEnd.x - pos.x) / 2,
            centerY,
            lineWidth,
            centerH + lineWidth * .25f),
            lineCenter
        );

        UpdateLineSegment(
            new Rect (
            (lineEnd.x - pos.x) * 3 / 4,
            -pos.y + lineEnd.y,
            Mathf.Abs((lineEnd.x - pos.x) / 2),
            lineWidth),
            lineRight
        );
    }

    void UpdateLineSegment(Rect rect, GameObject line){

       // Debug.Log(line);
     

        RectTransform rt = line.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2( rect.x, rect.y);
        rt.sizeDelta = new Vector2( rect.width, rect.height);
        line.transform.SetParent(lineParent, false);
        line.transform.localScale = new Vector3(1,1,1);

        line.GetComponent<Image>().color = lineColor;

    }

    public void DestroyLine(){
        DestroyLineSegment(lineLeft);
        DestroyLineSegment(lineRight);
        DestroyLineSegment(lineCenter);

    }

    void DestroyLineSegment(GameObject line){
        Destroy(line);
        isDrawing = false;
    }

    public void TryDestroyLine(){
        if(GetIsDrawing()){
            DestroyLine();
        }
    }
}
