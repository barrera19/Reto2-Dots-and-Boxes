using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [Header("PanelManager")]
    [SerializeField] GameObject panelStart;
    [SerializeField] GameObject panelGrid;
    [SerializeField] GameObject panelPoints;
    [SerializeField] GameObject panelGameOver;

    [SerializeField] int playerPoints;
    [SerializeField] TextMeshProUGUI playerTextPoints;
    [SerializeField] int cpuPoints;
    [SerializeField] TextMeshProUGUI cpuTextPoints;

    public int totalBoxes;
    public int availablesLines;

    HLineControl[] HLines;
    List<HLineControl> totalHLines = new List<HLineControl>();



    void Awake()
    {
        gameManager = this;
    }
    void Start()
    {
        panelStart.SetActive(true);
        panelGrid.SetActive(false);
        panelPoints.SetActive(false);
        panelGameOver.SetActive(false);

        
    }
    void Update()
    {
        Points();
    }
    public void buttonStart()
    {
        panelStart.SetActive(false);
        panelGrid.SetActive(true);
        DrawGrid.drawGrid.CreateBoard();  print("Total Boxes Available: " + totalBoxes);
        panelPoints.SetActive(true);
        playerPoints = 0;
        cpuPoints = 0;
    } 

    public void restart()
    {
        DrawGrid.boardXSize = 3;
        DrawGrid.boardYSize = 3;
        SceneManager.LoadScene("GameScene");
    }

    public void ButtonController()
    {
        availablesLines--;
        print("Lineas Disponibles: " + availablesLines);
        if(availablesLines==0)
        { GameManager.gameManager.GameOver(); }
        
    }

    void Points()
    {
        cpuTextPoints.text = cpuPoints.ToString();
        playerTextPoints.text = playerPoints.ToString();
    }


    public void WonPoint(GameObject sideBox, bool playerTurn)
    {   
        
        var boxClosed = BoxClosed.boxClosed.CheckClosedBox(sideBox);
        var boxIdle = boxClosed.Item2;

        if(boxClosed.Item1 && playerTurn)
        {          
            BoxWon.boxWon.WonByPlayer(boxIdle.transform);
            playerPoints++;
        }
        if(boxClosed.Item1 && !playerTurn)
        {
            BoxWon.boxWon.WonByCPU(boxIdle.transform);
            cpuPoints++;
        }

    }

    public void GameOver()
    {
        panelGameOver.SetActive(true);

    }

}
