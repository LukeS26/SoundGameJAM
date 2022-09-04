using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDistraction : MonoBehaviour
{
    public static AudioDistraction Instance;

    public GameObject[] SFX;

    public float sfxLow, sfxHigh,sfxDelay;

    public bool playSound;

    // Start is called before the first frame update
    void Start()
    {
        //set instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        sfxDelay=Random.Range(sfxLow, sfxHigh);

        playSound = true;
    }

    //play SFX form the array at the position of the sound 
    public void playSFX(int sound)//Feature Point :Trigger Sound, Arrays 
    {
        if (playSound)
        {
            float randX = Random.Range(-2.0f, 2.0f);
            float randY = Random.Range(-2.0f, 2.0f);
            Instantiate(SFX[sound], new Vector3(FindObjectOfType<PlayerController>().gameObject.transform.position.x + randX, FindObjectOfType<PlayerController>().gameObject.transform.position.y + randY, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        sfxDelay -= Time.deltaTime;

        if (sfxDelay <= 0)
        {
            sfxDelay = Random.Range(sfxLow, sfxHigh);

            int randomSFX=Random.Range(0, SFX.Length);


            playSFX(randomSFX);
        }
    }
}
