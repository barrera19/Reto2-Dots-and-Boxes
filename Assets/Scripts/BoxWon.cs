using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxWon : MonoBehaviour
{
    public static BoxWon boxWon;
    public Transform playerBox;
    public Transform cpuBox;


    void Awake()
    {
        boxWon = this;
    }

    public void WonByPlayer(Transform boxIdle)
    {
        Transform boxWon =  Instantiate(playerBox, boxIdle.position, Quaternion.identity, DrawGrid.drawGrid.spawnerBoxes.transform);
        boxWon.gameObject.name = "PlayerWonBox";
        boxIdle.gameObject.SetActive(false);

        
    }
        public void WonByCPU(Transform boxIdle)
    {
        Transform boxWon =  Instantiate(cpuBox, boxIdle.position, Quaternion.identity, DrawGrid.drawGrid.spawnerBoxes.transform);
        boxWon.gameObject.name = "CPUWonBox";
        boxIdle.gameObject.SetActive(false);
    }

}
