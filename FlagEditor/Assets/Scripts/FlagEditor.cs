using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagEditor : MonoBehaviour
{
    public Flag flag;
    private Texture2D originalTexture;
    private Texture2D newTexture;

    void Start()
    {
        flag.OnClick += FloodFill;
        //Debug.Log("Hola");
        /*originalTexture = flag.GetComponent<SpriteRenderer>().sprite.texture;
        newTexture = new Texture2D(300, 200);

        for (int y = 0; y < originalTexture.height; y++)
        {
            for (int x = 0; x < originalTexture.width; x++)
            {
                if (originalTexture.GetPixel(x, y).Equals(Color.white))
                {
                    originalTexture.SetPixel(x, y, Color.red);
                }
            }
        }
        originalTexture.Apply();
        flag.GetComponent<SpriteRenderer>().sprite = Sprite.Create(originalTexture, new Rect(0.0f, 0.0f, 300, 200), new Vector2(0.5f, 0.5f), 100.0f);
    }*/
    }

    private void FloodFill()
    {
        
    }
}
