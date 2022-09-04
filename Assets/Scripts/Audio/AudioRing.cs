using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRing : MonoBehaviour
{

/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obj")
        {
            other.GetComponent<AudioObject>().insideRing();

            float dist = Vector2.Distance(gameObject.transform.position, other.transform.position);

            other.GetComponent<AudioObject>().setDistance(dist);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.tag == "obj")
        {
            other.GetComponent<AudioObject>().insideRing();

            float dist = Vector2.Distance(gameObject.transform.position, other.gameObject.transform.position);

            other.GetComponent<AudioObject>().setDistance(dist); 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "obj")
        {
            other.GetComponent<AudioObject>().outsideRing();
        }
    }
}
