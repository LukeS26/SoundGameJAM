using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 0.5f;
    public InputManager inputManager;

    private Rigidbody2D rigidbody;

    void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Awake() {
        inputManager = new InputManager();
    }

    void OnEnable() {
        inputManager.Player.Enable();
    }

    void OnDisable() {
        inputManager.Player.Disable();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void FixedUpdate() {
        float horizontal = inputManager.Player.Movement.ReadValue<Vector2>().x;
        float vertical = inputManager.Player.Movement.ReadValue<Vector2>().y;

        rigidbody.AddForce(new Vector2(horizontal * moveSpeed, vertical * moveSpeed));        
    }
}
