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
    Color lineColor;

    GameObject lineLeft, lineCenter, lineRight;

    Vector2 lineStart, lineEnd;


    bool isDrawing = false;

    public bool GetIsDrawing(){return isDrawing;}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLine(Vector2 lineStart, float lineWidth, Color lineColor){
        this.lineStart = lineStart;
        SetLineWidth(lineWidth);
        SetLineColor(lineColor);

        lineLeft = CreateLineSegment("Left Line");
        lineCenter = CreateLineSegment( "Center Line");
        lineRight = CreateLineSegment( "Right Line");

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

    public void TryUpdateLine(bool test, RectTransform lineEnd){
        if(test){
            UpdateLine(lineEnd);
        }else {
            TryDestroyLine();
        }
    }

    public void TryUpdateLine(bool test, Vector2 lineEnd){
        if(test){
            UpdateLine(lineEnd);
        }else {
            TryDestroyLine();
        }
    }
    public void UpdateLine(RectTransform lineEnd){
        UpdateLine(new Vector2(lineEnd.rect.x, lineEnd.rect.y ));
    }
    public void UpdateLine(Vector2 lineEnd){
        this.lineEnd = lineEnd;

        Vector3 pos = transform.position;

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

         UpdateLineSegment(
            new Rect(
            (lineEnd.x - pos.x) / 2,
            centerY,
            lineWidth,
            centerH),
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
