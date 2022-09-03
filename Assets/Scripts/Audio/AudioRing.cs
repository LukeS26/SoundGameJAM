using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRing : MonoBehaviour
{

    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 5)]
    public float xradius = 5;
    [Range(0, 5)]
    public float yradius = 5;
    LineRenderer line;

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();

       line.positionCount=segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
    }

    void CreatePoints()
    {
        float x;
        float y;


        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, 0));

            angle += (360f / segments);
        }
    }

/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "obj")
        {
            other.GetComponent<AudioObject>().insideRing();

            float dist = Vector2.Distance(gameObject.transform.position, other.transform.position);

            other.GetComponent<AudioObject>().setDistance(dist);
        }
    }*/

    private void OnTriggerStay2D(Collider2D other)
    {
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