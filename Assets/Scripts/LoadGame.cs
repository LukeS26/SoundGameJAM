using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public InputManager inputManager;
    public AudioSource[] sounds;

    void Awake() {
        inputManager = new InputManager();

        for(int i = 0; i < sounds.Length; i++) {
            sounds[i].Play();
        }
    }

    void OnEnable() {
        inputManager.Menu.Enable();
    }

    // Update is called once per frame
    void Update() {
        if(inputManager.Menu.Start.triggered) {
            for(int i = 0; i < sounds.Length; i++) {
                sounds[i].Stop();
            }            
            
            SceneManager.LoadScene("Room1");
            inputManager.Menu.Disable();
        }
    }
}
