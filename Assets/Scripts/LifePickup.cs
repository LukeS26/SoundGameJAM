using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePickup : MonoBehaviour
{
    private float t;
    public float rate, mag;

    private Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;

        transform.position = startPos + new Vector2(0, Mathf.Sin(t * rate) * mag);
    }

        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerController>().health < 3) {
            collision.gameObject.GetComponent<PlayerController>().addLife();
            Destroy(gameObject);
        }
    }
}
