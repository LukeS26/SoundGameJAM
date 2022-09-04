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
    public float t, sight;
    public float interval, radius;
    GameObject player;
    public float playerRadius, initVis, burstSpeed, decSpeed;
    public bool enabled = true;
    bool allowDec;
    public bool playNormal = true;
    
    Material thisMat;
    public bool hidden;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance.gameObject;

        rmat = new Material(prefmat);
        rmat.color = col;

        if (hidden) {
            thisMat = new Material(GetComponent<SpriteRenderer>().material);
            GetComponent<SpriteRenderer>().material = thisMat;
        }
        
    }

    void startLate()
    {
        player = PlayerController.instance.gameObject;

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

            if(enabled && playNormal) {
                PlayPart(transform.position);
            }
            t = 0f;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) > playerRadius) t = interval;
        
        t += Time.deltaTime;

        if (hidden)
        {
            thisMat.color = Color.Lerp(Color.black, Color.white, sight);
            if (sight > 0f && allowDec) sight -= Time.deltaTime * decSpeed;
        }
        
    }

    public void PlayPart(Vector3 pos)
    {
        startLate();
        Debug.Log("1");
        float d = Mathf.Clamp((Vector3.Distance(player.transform.position,transform.position) - 1f )/ playerRadius, 0, 1) * initVis;
        Debug.Log("2: " + d);
        rmat.color = Color.Lerp(col, Color.black, d);
        Debug.Log("3");
        rsys = Instantiate(prefsys, pos+Vector3.back*(radius+1f), Quaternion.identity);
        Debug.Log("4");
        rsys.GetComponent<ParticleSystem>().emissionRate = burstSpeed * Mathf.Pow(1 - d + 0.1f,6);
        Debug.Log("5");
        rsys.GetComponent<ParticleSystemRenderer>().material = rmat;
        Debug.Log("6");
        rsys.GetComponent<ParticleSystemRenderer>().mesh = mesh;
        Debug.Log("7");
        ParticleSystem.ShapeModule r = rsys.GetComponent<ParticleSystem>().shape;
        Debug.Log("8");
        r.radius = radius;
        Debug.Log("9");
        rsys.GetComponent<ParticleSystem>().Play();
        Debug.Log("10");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hidden && collision.gameObject.tag == "Player")
        {
            sight = 1;
            allowDec = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (hidden && collision.gameObject.tag == "Player")
        {
            allowDec = true;
        }
    }
}
