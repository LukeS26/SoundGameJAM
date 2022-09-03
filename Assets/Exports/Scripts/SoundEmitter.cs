using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public Mesh mesh;
    public Color col;
    public GameObject prefsys;
    GameObject rsys;
    public Material prefmat;
    Material rmat;
    float t, sight;
    public float interval, radius;
    public GameObject player;
    public float playerRadius, initVis, burstSpeed, decSpeed;

    Material thisMat;
    public bool hidden;
    // Start is called before the first frame update
    void Start()
    {
        rmat = new Material(prefmat);
        rmat.color = col;

        if (hidden)
        {
            thisMat = new Material(GetComponent<SpriteRenderer>().material);
            GetComponent<SpriteRenderer>().material = thisMat;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < playerRadius && t > interval)
        {
            PlayPart(transform.position);
            t = 0f;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) > playerRadius) t = interval;
        
        t += Time.deltaTime;

        if (hidden)
        {
            thisMat.color = Color.Lerp(Color.black, Color.white, sight);
            if (sight > 0f) sight -= Time.deltaTime * decSpeed;
        }
        
    }

    public void PlayPart(Vector3 pos)
    {
        float d = Mathf.Clamp((Vector3.Distance(player.transform.position,transform.position) - 1f )/ playerRadius, 0, 1) * initVis;
        rmat.color = Color.Lerp(col, Color.black, d);
        rsys = Instantiate(prefsys, pos+Vector3.back*(radius+1f), Quaternion.identity);
        rsys.GetComponent<ParticleSystem>().emissionRate = burstSpeed * Mathf.Pow(1 - d + 0.1f,6);
        rsys.GetComponent<ParticleSystemRenderer>().material = rmat;
        rsys.GetComponent<ParticleSystemRenderer>().mesh = mesh;
        ParticleSystem.ShapeModule r = rsys.GetComponent<ParticleSystem>().shape;
        r.radius = radius;
        rsys.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hidden && collision.gameObject == player)
        {
            sight = 1;
        }
    }
}
