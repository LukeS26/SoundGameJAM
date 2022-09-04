using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioObject : MonoBehaviour
{
    public AudioSource sfx;
    public float delay,dist;
    public float currentDelay;
    public bool inRing,timeUp;
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        currentDelay = delay;
    }

    private void Update()
    {
        timeUp = false;
        currentDelay -= Time.deltaTime;
        if (currentDelay < 0 && !sfx.isPlaying)
        {
            playSFX();
            currentDelay = delay;
        }

        if(!inRing) {
            sfx.Stop();
        } else {
            sfx.volume = 5 / (Vector2.Distance(transform.position, player.transform.position) * Vector2.Distance(transform.position, player.transform.position));
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
    public void playSFX()//Feature Point :Trigger Sound, Arrays 
    {
        if (inRing)
        {
            sfx.PlayOneShot(sfx.clip, 1);//Feature Point :Trigger Sound, Arrays
        }
    }
}
