using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartBeat : MonoBehaviour
{
    public CircleCollider2D heartBeatRange;
    public AudioSource heartSound;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioVisualRing.Instance.rangeStart = 0.5f;
             AudioVisualRing.Instance.rangeSpeed = 0.8f;
            AudioVisualRing.Instance.rangeMax = 1.2f;
            heartSound.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioVisualRing.Instance.rangeStart = 1f;
            AudioVisualRing.Instance.rangeSpeed = 1f;
            AudioVisualRing.Instance.rangeMax = 1f;
            heartSound.gameObject.SetActive(false);
        }
    }
}
