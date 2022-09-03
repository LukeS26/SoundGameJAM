using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Vector2Int dir;
    int img;
    public Sprite[] images;
    SpriteRenderer rend;
    Rigidbody2D rb;
    float t;
    public float speed, moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector2Int.down;
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xmove = gameObject.GetComponent<PlayerController>().horizontal;
        float ymove = gameObject.GetComponent<PlayerController>().vertical;


        if (xmove != 0 && Mathf.Abs(xmove) >= Mathf.Abs(ymove))
        { 
            dir = new Vector2Int((int) Mathf.Sign(xmove),0);
        } else if (ymove != 0 && Mathf.Abs(xmove) < Mathf.Abs(ymove)) 
        {
            dir = new Vector2Int(0,(int) Mathf.Sign(ymove));
        }
        
        t += Time.deltaTime * speed;

        int n = 0;
        if (dir == Vector2Int.down) n = 0;
        else if (dir == Vector2Int.up) n = 1;
        else if (dir == Vector2Int.right) n = 2;
        else if (dir == Vector2Int.left) n = 3;
        img = ((xmove != 0 || ymove != 0) ? TPattern(t) : 0) + n * 3;

        rend.sprite = images[img];

        //rb.velocity = new Vector3(xmove, ymove, 0).normalized * moveSpeed;
    }

    int TPattern(float t)
    {
        int n = (int)t % 4;
        if (n >= 2) n = 2 * (n - 2);
        return n;
    }
}
