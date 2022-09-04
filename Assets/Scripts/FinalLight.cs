using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLight : MonoBehaviour
{
    public float wt;
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

        if (inPlace && inputManager.Player.Interact.triggered && !trig) {
            trig = true;
            doorNoise.Play();
            gameObject.GetComponent<AudioObject>().DisableSounds();
        }

        if(trig && !doorNoise.isPlaying) {
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Health"));
            SceneManager.LoadScene("WinScreen");
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
