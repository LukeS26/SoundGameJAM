using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance;
    public static string door;

    public float moveSpeed = 0.5f;
    public InputManager inputManager;

    private Rigidbody2D rigidbody;

    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnLoad(Scene scene, LoadSceneMode mode) {
        Debug.Log(door);
        if(door != null) {
            Debug.Log(GameObject.Find(door).transform.position);
            transform.position = GameObject.Find(door).transform.position + (GameObject.Find(door).transform.up * 1.5f);
        }
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);

        inputManager = new InputManager();
        Instance = this;      
    }

    void OnEnable() {
        inputManager.Player.Enable();

        SceneManager.sceneLoaded += OnLoad;
    }

    void OnDisable() {
        inputManager.Player.Disable();
    }

    void FixedUpdate() {
        float horizontal = inputManager.Player.Movement.ReadValue<Vector2>().x;
        float vertical = inputManager.Player.Movement.ReadValue<Vector2>().y;

        rigidbody.AddForce(new Vector2(horizontal * moveSpeed, vertical * moveSpeed));        
    }
}
