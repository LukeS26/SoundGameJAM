using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public GameObject wall;
    public bool trig;
    public Sprite[] imgs;
    bool inPlace;
    InputManager inputManager;
    public AudioSource doorNoise;

    void Awake() {
        inputManager = new InputManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        trig = false;
    }

    void OnEnable() {
        inputManager.Player.Enable();
    }

    void OnDisable() {
        inputManager.Player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = (trig) ? imgs[1] : imgs[0];

        if (inPlace && inputManager.Player.Interact.triggered) {
            trig = true;
            doorNoise.Play();
        }

        if (wall != null && trig)
        {
            GetComponent<SoundEmitter>().PlayPart(wall.transform.position);
            Destroy(wall);
            GetComponent<SoundEmitter>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") inPlace = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") inPlace = false;
    }
}
