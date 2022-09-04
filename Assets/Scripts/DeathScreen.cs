using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public InputManager inputManager;

    void Awake() {
        inputManager = new InputManager();
    }

     void OnEnable() {
        inputManager.Menu.Enable();
    }

    void OnDisable() {
        inputManager.Menu.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputManager.Menu.Start.triggered) {
            SceneManager.LoadScene("Room1");
            inputManager.Menu.Disable();
        }
    }
}
