using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEditor : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = new Texture2D(300, 200);
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, Color.red);
            }
        }
        texture.Apply();
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, 300, 200), new Vector2(0.5f, 0.5f), 100.0f);
    }
}
