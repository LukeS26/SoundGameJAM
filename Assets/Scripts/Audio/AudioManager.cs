using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    //initialize 
    public static AudioManager Instance;
    public AudioSource[] BGM; //Feature Point : Arrays
    public AudioSource[] SFX; //Feature Point : Arrays

    //set instance
    private void Awake()
    {
        //create object instance t pull from 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
