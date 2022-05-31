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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            texture = GetComponent<SpriteRenderer>().sprite.texture;
            Vector2 mousePos = Input.mousePosition;
            Color originalColor = texture.GetPixel((int)mousePos.x, (int)mousePos.y);

            //FloodFill(new Node((int)mousePos.x, (int)mousePos.y), Color.blue);
            FloodFill(new Node(0, 0), Color.blue);
            GetComponent<Renderer>().material.mainTexture = texture;
            texture.Apply();
            GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.height, texture.width), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    private void FloodFill(Node node, Color color)
    {
        Queue Q = new Queue();
        Q.Enqueue(node);
        while(Q.Count != 0)
        {
            Node actualNode = (Node)Q.Dequeue();

            if(0 <= actualNode.x && actualNode.x <= texture.width && actualNode.y <= texture.height && actualNode.y >= 0 && !texture.GetPixel(actualNode.x, actualNode.y).Equals(Color.black) && !texture.GetPixel(actualNode.x, actualNode.y).Equals(color))
            {
                texture.SetPixel(actualNode.x, actualNode.y, color);
                Q.Enqueue(new Node(actualNode.x + 1, actualNode.y));
                Q.Enqueue(new Node(actualNode.x, actualNode.y + 1));
                Q.Enqueue(new Node(actualNode.x - 1, actualNode.y));
                Q.Enqueue(new Node(actualNode.x, actualNode.y - 1));
            }
        }
    }
}
