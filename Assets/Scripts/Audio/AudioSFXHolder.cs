using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXHolder : MonoBehaviour
{
    public AudioSource SFX;
    public float clipLength;
    // Start is called before the first frame update
    void Start()
    {
        clipLength = SFX.clip.length;
        AudioDistraction.Instance.playSound = false; 
    }

    // Update is called once per frame
    void Update()
    {
        clipLength -= Time.deltaTime;
        if (clipLength <= 0)
        {
            AudioDistraction.Instance.playSound = true;
            Destroy(gameObject);
        }
    }
}
