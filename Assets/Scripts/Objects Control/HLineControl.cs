using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HLineControl : MonoBehaviour
{
    public static HLineControl HLine;
    public int xValue;
    public int yValue;

    public GameObject lineController;

    void Awake()
    {
        HLine = this;
    }
    void Start()
    {
        lineController = transform.parent.gameObject;
    }
}
