using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public AudioSource sfx;
    public float delay,dist;
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
            playSFX(dist);
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

    public void setDistance(float theDistance)
    {
        dist = theDistance;
    }

    //play SFX form the array at the position of the sound 
    public void playSFX(float volume)//Feature Point :Trigger Sound, Arrays 
    {
        float mult = ((2 / volume));

        Debug.Log(mult);
        if (inRing)
        {
            sfx.PlayOneShot(sfx.clip, mult);//Feature Point :Trigger Sound, Arrays
        }
    }
}
