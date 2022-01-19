using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize *2;
    }


    void Update()
    { 
        Move();
        Scrolling();
    }

    void Move()
    {
        //Sprite Reuse
        Vector3 curposs = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curposs + nextPos;
    }

    void Scrolling()
    {
        if (sprites[endIndex].position.y < viewHeight * (-1))
        {
            // Sprite ReUse
            Vector3 backSpritePos = sprites[startIndex].transform.localPosition;
            Vector3 frontSrpitePos = sprites[endIndex].transform.localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * viewHeight;

            // Cursor Indexs Change
            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;

        }
    }

}
