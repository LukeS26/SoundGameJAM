using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stillEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
