using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int x { get; }
    public int y { get; }

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Flag : MonoBehaviour
{
    private Color limitColor = Color.black;
    Texture2D texture;

    public delegate void Click();
    public event Click OnClick;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClick(); // Observer Update
        }
    }
}
