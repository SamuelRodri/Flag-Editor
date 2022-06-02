using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flag : MonoBehaviour
{
    private Color limitColor = Color.black;
    Texture2D texture;

    public delegate void Click(Texture2D readTexture, int x, int y);
    public event Click OnClick;

    GameObject player;
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
            Vector3 clickPoint = transform.InverseTransformDirection(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Debug.Log(clickPoint);
            OnClick(texture, (int)clickPoint.x, (int)clickPoint.y); // Observer Update
        }
    }
}
