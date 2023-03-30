using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClosed : MonoBehaviour
{
    public static BoxClosed boxClosed;

    public Transform LineObject;

    Transform[,] HLine;
    Transform[,] VLine;
    GameObject[,] Box;
    Boolean[,] inactiveHLine;
    Boolean[,] inactiveVLine;


    void Awake()
    {
        boxClosed = this;
        LineObject = GetComponent<Transform>();
    }
    void Start()
    {
        HLine = DrawGrid.drawGrid.horizLines;
        VLine = DrawGrid.drawGrid.vertLines;
        Box = DrawGrid.drawGrid.boxes;
        
    }

    void Update()
    {
              
    }
    public Tuple<bool, GameObject> CheckClosedBox(GameObject sideBox)
    {
            BoxControl myBox = sideBox.GetComponent<BoxControl>();
            myBox.boxSides--;
                        if(myBox.boxSides==0)
                        {
                            return Tuple.Create(true, sideBox);
                        }
       
         return Tuple.Create(false, sideBox);
    }

    public void InactiveLine()
    {
        CounterLines();
        print("Linea desactivada: " + LineObject.name);
        {
        
        int xValueLine;
        int yValueLine;
        
        GameObject[] sideBox = new GameObject[2];        
        
        if(LineObject.tag == "Horizontal")
        {
            HLineControl myLineController = gameObject.GetComponent<HLineControl>();
            xValueLine = myLineController.xValue;
            yValueLine = myLineController.yValue;
     
            print("La Linea es Horizontal");
            print("Linea X: " +xValueLine +", Y: " + yValueLine);

    //Líneas de las esquinas Horizontales       
            if(yValueLine == 0 || yValueLine == Box.GetLength(1))
            {
                print("Linea Horizontal de esquina: X: " +xValueLine +", Y: " + yValueLine);
                if(yValueLine == 0)
                {
                    sideBox[0] = Box[xValueLine,yValueLine];
                    CheckPoint(sideBox[0], true);;

                    print("Box Arriba es: " + sideBox[0]);
                }
                if(yValueLine == Box.GetLength(1))
                {
                    sideBox[0] = Box[xValueLine,yValueLine-1];
                    CheckPoint(sideBox[0], true);;
                    print("Box Abajo es: " + sideBox[0]);
                }
                
                
            }

    // Líneas del centro Horizontales Arriba y Abajo (2 Laterales)
            if(yValueLine > 0 && yValueLine < Box.GetLength(1))
            {
                print("Linea Horizontal del centro X: " +xValueLine +", Y: " + yValueLine);

                sideBox[0] = Box[xValueLine,yValueLine];
                sideBox[1] = Box[xValueLine,yValueLine-1];
                CheckPoint(sideBox[0], true);
                CheckPoint(sideBox[1], true);
                print("Box Arriba es: " + sideBox[0] +" y Box Abajo es: " + sideBox[1]);
            }



        }
        if(LineObject.tag == "Vertical")
        {
            print("La Linea es Vertical");
            VLineControl myLineController = gameObject.GetComponent<VLineControl>();
            xValueLine = myLineController.xValue;
            yValueLine = myLineController.yValue;
 
            print("Linea X: " +xValueLine +", Y: " + yValueLine);

    //Líneas de las esquinas Verticales (1 caja Lateral)       
            if(xValueLine == 0 || xValueLine == Box.GetLength(0))
            {
                print("Linea Vertical de esquina: X: " +xValueLine +", Y: " + yValueLine);
                if(xValueLine == 0)
                {
                   
                    sideBox[0] = Box[xValueLine,yValueLine];
                    CheckPoint(sideBox[0], true);
                    print("Box Derecha es: " + sideBox[0]);
                }
                if(xValueLine == Box.GetLength(0))
                {   
                    sideBox[0] = Box[xValueLine-1,yValueLine];
                    CheckPoint(sideBox[0], true);
                    print("Box Izquierda es: " + sideBox[0]);
                }
               
            }
    //Líneas del Centro (2 Cajas laterales Izq-Der)
            if(xValueLine > 0 && xValueLine < Box.GetLength(0))
            {
                print("Linea Vertical del centro X: " +xValueLine +", Y: " + yValueLine);


                sideBox[0] = Box[xValueLine,yValueLine];
                sideBox[1] = Box[xValueLine-1,yValueLine];
                CheckPoint(sideBox[0], true);
                CheckPoint(sideBox[1], true);
                print("Box Derecha es: " + sideBox[0] +" y Box Izquierda es: " + sideBox[1]);
                
            }
            

        }

       
    

                // if(LineObject == Box[xValueBox,yValuebox])
                // {
                //     var resultClosedBox = CheckClosedBox(xValueBox, yValuebox);
                //     CheckClosedBox(xValueBox, yValuebox);
                //     if(resultClosedBox.Item1)
                //     {
                //         inactiveHLine[resultClosedBox.Item2, resultClosedBox.Item3] = true;  
                        
                //     }
                // }


        }
    }

    public void CheckPoint(GameObject sideBox, bool playerTurn)
    {
        GameManager.gameManager.WonPoint(sideBox, true);
    }

    public void CounterLines()
    {
        GameManager.gameManager.ButtonController();
    }

}
