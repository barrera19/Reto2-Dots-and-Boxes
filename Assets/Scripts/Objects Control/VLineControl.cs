using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VLineControl : MonoBehaviour
{
    public static VLineControl VLine;
    public int xValue;
    public int yValue;
    public   GameObject lineController;


    void Awake()
    {
        VLine = this;
    }
    void Start()
    {
        lineController = transform.parent.gameObject;
    }
}
