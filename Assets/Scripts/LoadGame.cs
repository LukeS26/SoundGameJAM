using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public InputManager inputManager;

    void Awake() {
        inputManager = new InputManager();
    }

    void OnEnable() {
        inputManager.Menu.Enable();
    }

    // Update is called once per frame
    void Update() {
        if(inputManager.Menu.Start.triggered) {
            SceneManager.LoadScene("brent_test");
            inputManager.Menu.Disable();
        }
    }
}
