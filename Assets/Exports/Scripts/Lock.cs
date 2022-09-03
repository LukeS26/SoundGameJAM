using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject wall, player;
    public bool trig;
    public Sprite[] imgs;
    bool inPlace;
    // Start is called before the first frame update
    void Start()
    {
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = (trig) ? imgs[1] : imgs[0];

        if (inPlace && Input.GetKeyDown(KeyCode.E)) trig = true;

        if (wall != null && trig)
        {
            GetComponent<SoundEmitter>().PlayPart(wall.transform.position);
            Destroy(wall);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player) inPlace = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player) inPlace = false;
    }
}
