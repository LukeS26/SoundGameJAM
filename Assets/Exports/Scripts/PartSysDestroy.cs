using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSysDestroy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<ParticleSystem>().isPlaying) Destroy(gameObject);
    }
}
