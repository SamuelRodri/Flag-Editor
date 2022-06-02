using System;
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

public class FlagEditor : MonoBehaviour
{
    public Flag flag;
    private Color limitColor = Color.black;

    void Start()
    {
        flag.OnClick += FloodFill;
    }

    private void FloodFill(Texture2D readTexture, int x, int y)
    {
        Texture2D writeTexture = new Texture2D(readTexture.width, readTexture.height);
        writeTexture.SetPixels(readTexture.GetPixels());
        writeTexture.Apply();
        Queue Q = new Queue();
        Q.Enqueue(new Node(x, y));
        while (Q.Count != 0)
        {
            Node actualNode = (Node)Q.Dequeue();

            if (CheckValidity(readTexture, actualNode.x, actualNode.y, writeTexture, Color.red))
            {
                writeTexture.SetPixel(actualNode.x, actualNode.y, Color.red);
                Q.Enqueue(new Node(actualNode.x + 1, actualNode.y));
                Q.Enqueue(new Node(actualNode.x, actualNode.y + 1));
                Q.Enqueue(new Node(actualNode.x - 1, actualNode.y));
                Q.Enqueue(new Node(actualNode.x, actualNode.y - 1));
            }
        }
        flag.GetComponent<Renderer>().material.mainTexture = writeTexture;
        writeTexture.filterMode = FilterMode.Point;
        writeTexture.Apply();
        flag.GetComponent<SpriteRenderer>().sprite = Sprite.Create(writeTexture, new Rect(0.0f, 0.0f, writeTexture.width, writeTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    // Check the validity of a point
    private bool CheckValidity(Texture2D readTexture, int x, int y, Texture2D writeTexture, Color targetColor)
    {
        bool isInLimitX = 0 <= x && x <= readTexture.width;

        bool isInLimitY = y <= readTexture.height && y >= 0;

        bool isLimitColor = readTexture.GetPixel(x, y).Equals(limitColor);

        bool isTargetColor = writeTexture.GetPixel(x, y).Equals(targetColor);

        return isInLimitX && isInLimitY && !isLimitColor && !isTargetColor;
    }
}
