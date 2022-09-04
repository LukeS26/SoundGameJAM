using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXHolder : MonoBehaviour
{
    public AudioSource SFX;
    public float clipLength;
    public bool isDistraction;
    // Start is called before the first frame update
    void Start()
    {
        clipLength = SFX.clip.length;
        if (isDistraction)
        {
            AudioDistraction.Instance.playSound = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDistraction)
        {
            clipLength -= Time.deltaTime;
            if (clipLength <= 0)
            {
                AudioDistraction.Instance.playSound = true;
                Destroy(gameObject);
            }
        }
        else
        {
            clipLength -= Time.deltaTime;
            if (clipLength <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
