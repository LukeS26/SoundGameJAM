using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public AudioSource sfx;
    public float delay;
    public float currentDelay;
    public bool inRing,timeUp;

    private void Start()
    {
        currentDelay = delay;
    }

    private void Update()
    {
        timeUp = false;
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0)
        {
            playSFX();
            currentDelay = delay;
        }
    }

    public void insideRing()
    {
        inRing = true;
    }
    public void outsideRing()
    {
        inRing = false;
    }

    //play SFX form the array at the position of the sound 
    public void playSFX()//Feature Point :Trigger Sound, Arrays 
    {
        if (inRing)
        {
            sfx.PlayOneShot(sfx.clip, 1.0f);//Feature Point :Trigger Sound, Arrays
        }
    }
}
