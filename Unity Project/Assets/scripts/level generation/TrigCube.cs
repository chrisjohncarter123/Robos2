using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigCube : MonoBehaviour
{


    public GameObject cube;
    public int width, height, depth;
    public float distance = 1;
    public float mag = 10;
    public float speed = .1f;
    public int size = 1;
    Coord[][][] coords;

    enum Coord{
        Empty,
        Cube

    }
    // Start is called before the first frame update
    void Start()
    {
        coords = new Coord[width][][];

        for(int x = 0; x < width; x++){
            coords[x] = new Coord[height][];

            for(int y = 0; y < height; y++){
                coords[x][y] = new Coord[depth];

                for(int z = 0; z < depth; z++){
                    coords[x][y][z] = Coord.Cube;
                    
                }
                
            }
        }

        for(int i = 0; i < width; i++){
            int x = i;
            int y = Mathf.Abs((int)(mag * Mathf.Sin((float)i * speed)));
            int z = Mathf.Abs((int)(mag * Mathf.Cos((float)i * speed)));

            Debug.Log(x.ToString() + " " + y.ToString());

            for(int j = x-size; j < x+size; j++){
                 for(int k = y-size; k < y+size; k++){
                      for(int l = z-size; l < z+size; l++){
                            if(TrySetCoord(j,k,l))
                            {
                                Debug.Log("Here");
                                coords[j][k][l] = Coord.Empty;

                            }
                      }
                 }
            }
               
        }

        for(int x = 0; x < width; x++){
       

            for(int y = 0; y < height; y++){
              
                for(int z = 0; z < depth; z++){
                    if(coords[x][y][z] == Coord.Cube){
                        GameObject clone = Instantiate(cube);
                        clone.transform.position = new Vector3(x*distance,y*distance,z*distance);
                        clone.name = x.ToString() + y.ToString() + z.ToString();
                        clone.transform.SetParent(transform);

                    } 
                    
                    
                }
                
            }
        }


        GetComponent<MeshCombiner>().Combine();

        
    }

    bool TrySetCoord( int x, int y, int z){
        if(x < width && y < height && z < depth){
            if(x >= 0 && y >= 0 && z >= 0){
                return true;
            }
        }
        return false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
