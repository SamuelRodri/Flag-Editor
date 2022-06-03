using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flag : MonoBehaviour
{
    private Color limitColor = Color.black;

    public Texture2D textureTemplate;
    private Texture2D texture;

    public delegate void Click(Texture2D readTexture, Texture2D writeTexture, int x, int y);
    public event Click OnClick;


    // Start is called before the first frame update
    void Start()
    {
        texture = GetComponent<SpriteRenderer>().sprite.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse Coordinates in Screen
            Vector2 mouseCoord = Input.mousePosition;

            // Mouse Coordinates in World
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(mouseCoord);

            // Mouse Coordinates in relation to Sprite
            Vector2 localPos = transform.InverseTransformPoint(worldPos) * 100;

            // Pivot of texture
            var texSpacePivot = new Vector2(GetComponent<SpriteRenderer>().sprite.rect.x, GetComponent<SpriteRenderer>().sprite.rect.y) + GetComponent<SpriteRenderer>().sprite.pivot;

            // Mouse Coordinates in Pixels in relation to Sprite
            Vector2 texSpaceCoord = texSpacePivot + localPos;

            OnClick(textureTemplate, texture, (int)texSpaceCoord.x, (int)texSpaceCoord.y); // Observer Update
        }
    }
}
