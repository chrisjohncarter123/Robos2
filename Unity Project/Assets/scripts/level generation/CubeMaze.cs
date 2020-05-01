using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMaze : MonoBehaviour
{


    public GameObject cube;
    public GameObject hall;
    public GameObject mazeWall;

    public int width = 5;
    public int height = 5;

    public int depth = 5;

    public int entrances = 5;

    public float distance = 2;
    public float cubeSize = 5;
    public float lightRangeScale = 1.75f;

    public float xWeight, yWeight, zWeight;

    public bool generateBorders = true;

    public Color leftColor, rightColor,
     topColor, bottomColor,
      frontColor, backColor;

      public Color[] colors;


    Cell[][][] cells;
    Wall[][][] walls;

    GameObject[][][] cubes;


    enum Cell{
        Visited,
        NotVisited
    }

    enum Wall {
        Closed,
        Open

    }





    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[width][][];

        for(int x = 0; x < width; x++){
            cubes[x] = new GameObject[height][];

            for(int y = 0; y < height; y++){
                cubes[x][y] = new GameObject[depth];

                for(int z = 0; z < depth; z++){
                    cubes[x][y][z] = Instantiate(cube);
                    cubes[x][y][z].transform.position = new Vector3(x*distance,y*distance,z*distance);
                    cubes[x][y][z].name = x.ToString() + y.ToString() + z.ToString();

                    Vector3 colorScaleMin = new Vector3( 
                        (float)x / (float)width,
                        (float)y / (float)height,
                        (float)z / (float)depth
                        );

                        Debug.Log(x.ToString() + " " + y.ToString() + " " + z.ToString());

                    Vector3 colorScaleMax = new Vector3(1f,1f,1f) - colorScaleMin;

                    Debug.Log(colorScaleMin.ToString() + " " + colorScaleMax.ToString());

                    Color left = colorScaleMin.x * leftColor;
                    Color right = colorScaleMax.x * rightColor;

                    Color top = colorScaleMin.y * topColor;
                    Color bottom = colorScaleMax.y * bottomColor;

                    Color front = colorScaleMin.z * frontColor;
                    Color back = colorScaleMax.z * backColor;

                    Color finalColor = left+right+top+bottom+front+back;

                    finalColor = left + right + top + bottom + front + back;

                    Debug.Log(finalColor);
                    float finalRange = lightRangeScale * distance;

                    cubes[x][y][z].GetComponentsInChildren<LightRandomizer>()[0].SetColor(finalColor);
                    cubes[x][y][z].GetComponentsInChildren<LightRandomizer>()[0].SetRange(finalRange);

                }
                
            }
        }



        cells = new Cell[width][][];

        for(int x = 0; x < width; x++){
            cells[x] = new Cell[height][];

            for(int y = 0; y < height; y++){
                cells[x][y] = new Cell[depth];

                for(int z = 0; z < depth; z++){
                    cells[x][y][z] = Cell.NotVisited;
                    
                }
                
            }
        }

        int wallsWidth = GetWallsWidth();
        int wallsHeight = GetWallsHeight();
        int wallsDepth = GetWallsDepth();

        walls = new Wall[wallsWidth][][];

        for(int x = 0; x < wallsWidth; x++){
            walls[x] = new Wall[wallsHeight][];

            for(int y = 0; y < wallsHeight; y++){
                walls[x][y] = new Wall[wallsDepth];

                for(int z = 0; z < wallsDepth; z++){
                    walls[x][y][z] = Wall.Closed;
                }
                
            }
        }

        Generate(0, 0, 0);
        if(generateBorders){
            GenerateBorders();
        }


        for(int i = 0; i < entrances; i++){
            int x = Random.Range(0, width);
            int y = Random.Range(0, height);
            int z = Random.Range(0, depth);

            if(cubes[x][y][z]){
                Destroy(cubes[x][y][z]);
            }
            

        }
       
    }

    void GenerateBorders(){
        //left
        GenerateBorder(new Vector3(-.5f, height / 2, depth / 2), new Vector3(.1f, height, depth));

        //right
        GenerateBorder(new Vector3(width - .5f, height / 2, depth / 2), new Vector3(.1f, height, depth));

        //bottom
        GenerateBorder(new Vector3(width / 2, -.5f, depth / 2), new Vector3(height, .1f, depth));

        //top
        GenerateBorder(new Vector3(width / 2 , -.5f + height, depth / 2), new Vector3(height, .1f, depth));
    }

    void GenerateBorder(Vector3 pos, Vector3 scale){
        GameObject clone = Instantiate(mazeWall);
        clone.transform.position = pos;
        clone.transform.localScale = scale;

    }

    int GetWallsWidth() {return width;}
    int GetWallsHeight() {return height * 2;}
    int GetWallsDepth() {return depth;}

    void Generate(int x, int y, int z){

        /*
        source: https://en.wikipedia.org/wiki/Maze_generation_algorithm
        The depth-first search algorithm of maze generation is frequently implemented using backtracking. This can be described with a following recursive routine:
        Given a current cell as a parameter,
        Mark the current cell as visited
        While the current cell has any unvisited neighbour cells
            Choose one of the unvisited neighbours
            Remove the wall between the current cell and the chosen cell
            Invoke the routine recursively for a chosen cell
        */

        cells[x][y][z] = Cell.Visited;

        


        while(true){

            int[] remaining = RemainingUnvisitedNeighbors(x,y,z);

            if(remaining.Length == 0){
                break;
            }

    
            int random = Random.Range(0, remaining.Length);
            int choice = remaining[random];

            int newX = x;
            int newY = y;
            int newZ = z;

            //GameObject clone = Instantiate(mazeWall);

            Vector3 hallAdd = new Vector3(0,0,0);
            

            switch (choice){
                case 0:
                    newX += 1;
                    hallAdd.x += 1;
                   // clone.transform.position = new Vector3(newX + .5f, newY, newZ);
                   // clone.transform.localScale = new Vector3(.1f, 1, 1);
                   cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Right);
                   cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Left);
                   
                   
                break;

                case 1:
                    newX -= 1;
                    hallAdd.x -= 1;
                   // clone.transform.position = new Vector3(newX - .5f, newY, newZ);
                    //clone.transform.localScale = new Vector3(.1f, 1, 1);
                    cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Left);
                    cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Right);
                    
                    
                break;

                case 2:
                    newY += 1;
                    hallAdd.y += 1;
                    //clone.transform.position = new Vector3(newX, newY + .5f, newZ);
                    //clone.transform.localScale = new Vector3(1, .1f, 1);
                    cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Top);
                    cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Bottom);

                break;

                case 3:
                    newY -= 1;
                    hallAdd.y -= 1;
                    //clone.transform.position = new Vector3(newX, newY - .5f, newZ);
                    //clone.transform.localScale = new Vector3(1f, .1f, 1);
                    cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Bottom);
                    cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Top);

                break;

                case 4:
                    newZ += 1;
                    hallAdd.z += 1;
                    //clone.transform.position = new Vector3(newX, newY, newZ + .5f);
                    //clone.transform.localScale = new Vector3(1, 1f, .1f);
                    cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Front);
                    cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Back);

                break;

                case 5:
                    newZ -= 1;
                    hallAdd.z -= 1;
                    //clone.transform.position = new Vector3(newX, newY, newZ - .5f);
                    //clone.transform.localScale = new Vector3(1f,   1, .1f);
                    cubes[x][y][z].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Back);
                    cubes[newX][newY][newZ].GetComponent<MazeCube>().TryDestroySide(MazeCube.Side.Front);

                break;
            }
            
            Debug.Log(newX.ToString() + newY.ToString() + newZ.ToString());
            

            GameObject hallCopy = Instantiate(hall);
            hallCopy.transform.position = 
            cubes[x][y][z].transform.position 
            + ( hallAdd * distance * .5f);
            hallCopy.transform.localScale = new Vector3(
                hallCopy.transform.localScale.x,
                hallCopy.transform.localScale.y,
                 (cubeSize - distance)

            );
            
            hallCopy.transform.LookAt(cubes[x][y][z].transform.position);

           // walls[newX][newY][newZ] = Wall.Open;
            Generate(newX, newY, newZ);
        }

    }

    int[] RemainingUnvisitedNeighbors(int x, int y, int z){
        List<int> result = new List<int>();

        if(x + 1 < width){
            if(cells[x + 1][y][z] == Cell.NotVisited){
                result.Add(0);
            }
        }
        if(x - 1 >= 0){
            if(cells[x - 1][y][z] == Cell.NotVisited){
                result.Add(1);
            }
        }
        if(y + 1 < height){
            if(cells[x][y + 1][z] == Cell.NotVisited){
                result.Add(2);
            }
        }
        if(y - 1 >= 0){
            if(cells[x][y - 1][z] == Cell.NotVisited){
                result.Add(3);
            }
        }
        if(z + 1 < depth){
            if(cells[x][y][z + 1] == Cell.NotVisited){
                result.Add(4);
            }
        }
        if(z - 1 >= 0){
            if(cells[x][y][z - 1] == Cell.NotVisited){
                result.Add(5);
            }
        }

        return result.ToArray();


    }


}


class WallStruct
{
    public enum WallState {
        Closed,
        Open

    }

    public WallState wallState;

    public int ax, ay, az;
    public int bx, by, bz;

    public WallStruct(int ax, int ay, int az, int bx, int by, int bz){
        this.ax = ax;
        this.ay = ay;
        this.az = az;

        this.bx = bx;
        this.by = by;
        this.bz = bz;

        wallState = WallState.Closed;
    }

}
