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

public class NodePlus
{
    public int x { get; }

    public int x2 { get; }
    public int y { get; }

    public int r { get; }

    public NodePlus(int x, int x2, int y, int r)
    {
        this.x = x;
        this.x2 = x2;
        this.y = y;
        this.r = r;
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

    private void FloodFill(Texture2D readTexture, Texture2D writeTexture, int x, int y)
    {
        Queue<Node> Q = new Queue<Node>();
        Q.Enqueue(new Node(x, y));
        while (Q.Count != 0)
        {
            Node actualNode = Q.Dequeue();

            if (CheckValidity(readTexture, actualNode.x, actualNode.y, writeTexture, Color.red))
            {
                writeTexture.SetPixel(actualNode.x, actualNode.y, Color.red);
                Q.Enqueue(new Node(actualNode.x + 1, actualNode.y));            // Right Pixel
                Q.Enqueue(new Node(actualNode.x, actualNode.y + 1));            // Up Pixel
                Q.Enqueue(new Node(actualNode.x - 1, actualNode.y));            // Left Pixel
                Q.Enqueue(new Node(actualNode.x, actualNode.y - 1));            // Down Pixel
            }
        }
        flag.GetComponent<Renderer>().material.mainTexture = writeTexture;
        writeTexture.filterMode = FilterMode.Point;
        writeTexture.Apply();
        flag.GetComponent<SpriteRenderer>().sprite = Sprite.Create(writeTexture, new Rect(0.0f, 0.0f, writeTexture.width, writeTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    /*private void SpanFilling(Texture2D readTexture, int x, int y)
    {
        Texture2D writeTexture = new Texture2D(readTexture.width, readTexture.height);
        if(!CheckValidity(readTexture, x, y, writeTexture, Color.red))
        {
            return;
        }

        writeTexture.SetPixels(readTexture.GetPixels());
        writeTexture.Apply();


        Queue<NodePlus> Q = new Queue<NodePlus>();
        Q.Enqueue(new NodePlus(x, x, y, 1));
        Q.Enqueue(new NodePlus(x, x, y - 1, -1)); // Down Pixel

        while (Q.Count != 0)
        {
            NodePlus node = Q.Dequeue();

            x = node.x;

            if (CheckValidity(readTexture, x, y, writeTexture, Color.red))
            {
                while(CheckValidity(readTexture, x - 1, y, writeTexture, Color.red))
                {
                    writeTexture.SetPixel(x - 1, y, Color.red);
                    x = x - 1;
                }
            }

            if(x < node.x)
            {
                Q.Enqueue(new NodePlus(x, node.x, y - node.r, -node.r));
            }

            while(node.x <= node.x2)
            {
                while(CheckValidity(readTexture, node.x, y, writeTexture, Color.red))
                {
                    writeTexture.SetPixel(node.x, y, Color.red);
                    node.x += 1;
                }
            }

        }
    }*/

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
