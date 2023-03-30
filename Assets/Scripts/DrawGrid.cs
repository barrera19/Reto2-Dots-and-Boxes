using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrawGrid : MonoBehaviour
{
    public static DrawGrid drawGrid;
    [Header("Objects")]
    [SerializeField] Transform dots;
    [SerializeField] Transform lineH;
    [SerializeField] Transform lineV;
    [SerializeField] Transform box;
    
  
    [Header("Grid")]
    public Transform[,] horizLines;
    public Transform[,] vertLines;
    public GameObject[,] boxes;
    public Transform[,] dot;

    public Dropdown xSize;
    public Dropdown ySize;
    public static int boardXSize = 3;
    public static int boardYSize = 3;

    [Header("GridSpawners")]
    public GameObject spawnerDots;
    public GameObject spawnerLinesH;
    public GameObject spawnerLinesV;
    public GameObject spawnerBoxes;
    void Awake()
    {
        drawGrid = this;
    }
    void Start()
    {

       
    }

    public void SetXSize(int colls)
    {
        boardXSize = colls + 3;
        print("Num Colls: " + boardXSize);
    }
    public void SetYSize(int rows)
    {
        boardYSize = rows + 3;
        print("Num Rows: " + boardYSize);
    }
    public void CreateBoard()
    {
        
        horizLines = new Transform[boardXSize, boardYSize +1];
        vertLines = new Transform[boardXSize +1, boardYSize];
        boxes = new GameObject[boardXSize, boardYSize];
        dot = new Transform[boardXSize+1, boardYSize+1];

        GameManager.gameManager.totalBoxes = boxes.Length;
        GameManager.gameManager.availablesLines = horizLines.Length + vertLines.Length;
        int boxSizeH = 160;
        int boxSizeV = 160;
        int sceenRel = 990 / boardYSize;

        for (int y = 0; y <= boardYSize ; y++ )
        {
            
            for(int x = 0; x <= boardXSize; x++)
            { 
                    // Boxes
                if(x < boardXSize && y < boardYSize)
                {
                    boxes[x,y] = Instantiate(box.gameObject, new Vector2(x *boxSizeH + sceenRel, y *boxSizeV + sceenRel), Quaternion.identity, spawnerBoxes.transform);  
                    boxes[x,y].gameObject.name = "Box("+x+","+y+")";
                    BoxControl.boxControl.BoxX = x;
                    BoxControl.boxControl.BoxY = y;
                }
                    
                    //Horizontal Lines
                if(x < boardXSize && y <= boardYSize)
                {
                    if(x < boardXSize && y < boardYSize)
                    {
                        horizLines[x,y] = Instantiate(lineH, new Vector2(x * boxSizeH + sceenRel, y * boxSizeV -80 + sceenRel), Quaternion.identity, spawnerLinesH.transform) as Transform;  
                        horizLines[x,y].gameObject.name = "HLine("+x+","+y+")";
                        HLineControl.HLine.xValue = x;
                        HLineControl.HLine.yValue = y;
                    }
                    if(y == boardYSize  &&  x < boardXSize)
                    {
                        horizLines[x,y] = Instantiate(lineH, new Vector2(x * boxSizeH + sceenRel, y * boxSizeV -80 + sceenRel), Quaternion.identity, spawnerLinesH.transform) as Transform;  
                        horizLines[x,y].gameObject.name = "HLine("+x+","+y+")";
                        HLineControl.HLine.xValue = x;
                        HLineControl.HLine.yValue = y;
                    }
                }
                    
                    // Vertical Lines
                if(x <= boardXSize && y < boardYSize)
                {
                    if(y < boardYSize && x < boardXSize)
                    {
                        vertLines[x,y] = Instantiate(lineV, new Vector2(x * boxSizeH - 80 + sceenRel, y * boxSizeV + sceenRel), Quaternion.identity, spawnerLinesV.transform) as Transform;  
                        vertLines[x,y].gameObject.name = "VLine("+x+","+y+")";
                        VLineControl.VLine.xValue = x;
                        VLineControl.VLine.yValue = y;
                    }
                    if(x == boardXSize &&  y < boardYSize)
                    {
                        vertLines[x,y] = Instantiate(lineV, new Vector2(x * boxSizeH - 80 + sceenRel, y * boxSizeV + sceenRel), Quaternion.identity, spawnerLinesV.transform) as Transform;  
                        vertLines[x,y].gameObject.name = "VLine("+x+","+y+")";
                        VLineControl.VLine.xValue = x;
                        VLineControl.VLine.yValue = y;

                    }
                }

                    // Drawing Dots
                 if(x <= boardXSize  && y <= boardYSize)
                {   
                    if( x< boardXSize && y < boardYSize)
                    {
                        dot[x,y] = Instantiate(dots, new Vector2(x * boxSizeH -80 + sceenRel, y * boxSizeV - 80 + sceenRel), Quaternion.identity, spawnerDots.transform) as Transform;
                    }
                    if(x ==boardXSize &&  y < boardYSize)
                    {
                       dot[x,y] = Instantiate(dots, new Vector2(x * boxSizeH -80 + sceenRel, y * boxSizeV - 80 + sceenRel), Quaternion.identity, spawnerDots.transform) as Transform;    
                    }
                    if(y ==boardYSize &&  x <= boardXSize)
                    {
                       dot[x,y] = Instantiate(dots, new Vector2(x * boxSizeH -80 + sceenRel, y * boxSizeV -80 + sceenRel), Quaternion.identity, spawnerDots.transform) as Transform;    
                    }
                    
                }
            }
        }

    }



}
