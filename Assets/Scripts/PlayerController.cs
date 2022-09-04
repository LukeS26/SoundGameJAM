using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;
    public static string door;

    public float moveSpeed = 0.5f;
    public InputManager inputManager;

    //public AudioSource footSteps; 

    public float horizontal, vertical;

    private Rigidbody2D rigidbody;

    private Vector2 startPos;

    public int health;

    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnLoad(Scene scene, LoadSceneMode mode) {
        if(door != null) {
            Debug.Log(GameObject.Find(door).transform.position);
            startPos = GameObject.Find(door).transform.position + (GameObject.Find(door).transform.up * 2f);
            transform.position = startPos;
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);

        inputManager = new InputManager();

        if (instance == null) {
            instance = this;
        } else {
            DestroyObject(gameObject);
        }
    }

    void OnEnable() {
        inputManager.Player.Enable();

        SceneManager.sceneLoaded += OnLoad;
    }

    void OnDisable() {
        inputManager.Player.Disable();
    }

    void FixedUpdate() {
        horizontal = inputManager.Player.Movement.ReadValue<Vector2>().x;
        vertical = inputManager.Player.Movement.ReadValue<Vector2>().y;

   /*     if (horizontal!=0 || vertical != 0)
        {
            playFootSound();
        }
        else
        {
            pauseFootSound();
        }*/

        rigidbody.AddForce(new Vector2(horizontal * moveSpeed, vertical * moveSpeed));  
        
    }

/*    private void playFootSound()
    {
        footSteps.enabled = true;
    }
    
    private void pauseFootSound()
    {
        footSteps.enabled = false;
    }*/

    public void Damage() {
        health -= 1;
        if(health < 1) {
            Destroy(gameObject);
            Destroy(GameObject.Find("Health"));
            SceneManager.LoadScene("Death");
        } else {
            transform.position = startPos;
        }
    }
}
