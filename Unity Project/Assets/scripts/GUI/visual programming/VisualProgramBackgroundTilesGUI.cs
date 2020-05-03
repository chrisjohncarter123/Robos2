using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualProgramBackgroundTilesGUI : MonoBehaviour
{

    [SerializeField]
    GameObject baseSquare;
    
    [SerializeField]
    VisualProgramPositionGUI programPosition;
    [SerializeField]
    VisualProgramScalerGUI programScale;

    [SerializeField]
    int width, height;

    Vector2 anchorMin, anchorMax;



    RectTransform[][] allSquares;


    // Start is called before the first frame update

    public static Rect RectTransformToScreenSpace(RectTransform transform)
     {
         Vector2 size = Vector2.Scale(transform.rect.size, transform.lossyScale);
         return new Rect((Vector2)transform.position - (size * 0.5f), size);
     }

    void Start()
    {
        InitSquares();
    }
    void InitSquares() {


        allSquares = new RectTransform[width][];
        for(int x = 0; x < width; x++){
            allSquares[x] = new RectTransform[height];
            for(int y = 0; y < height; y++){
                GameObject newObject = Instantiate(baseSquare);
                 newObject.GetComponent<Transform>().SetParent(transform);

                allSquares[x][y] = newObject.GetComponent<RectTransform>();
            
            }
        }

        anchorMin = new Vector2(-.5f, -.5f);
        anchorMax = new Vector2(.5f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSquares();
    }

    void UpdateSquares(){

        float sWidth = GetComponent<RectTransform>().sizeDelta.x;
        float sHeight = GetComponent<RectTransform>().sizeDelta.y;

        float rx = programPosition.GetProgramPosition().x;
        float ry = programPosition.GetProgramPosition().y;

        float bWidth = sWidth / width;
        float bHeight = sHeight / height; 

        float addx = rx % bWidth;
        float addy = ry % bHeight;
        

        for(int x = 0; x < width; x++){
            
            for(int y = 0; y < height; y++){
                RectTransform rt = allSquares[x][y];

                rt.anchoredPosition
                    = new Vector2(bWidth * x, bHeight * y)
                    + new Vector2(addx, addy);
                rt.sizeDelta
                    = new Vector2(bWidth, bHeight);
                rt.anchorMin
                    = anchorMin;
                rt.anchorMax
                    = anchorMax;
                
            }
        }

    }
}
