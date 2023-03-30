using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    public static BoxControl boxControl;
    public int BoxX;
    public int BoxY;
    public GameObject thisBox;
    public int boxSides;
    void Awake()
    {
        boxControl = this;
    }
    void Start()
    {
        thisBox = transform.parent.gameObject;
        boxSides = 4;
    }

}
