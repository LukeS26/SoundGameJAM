using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLives : MonoBehaviour
{
    public static DrawLives instance;

    GameObject[] lives;
    public Sprite[] images;
    public int maxHp;
    int hp;
    float slideHp;
    public float dmgLerp, imageInterval;
    public Material mat;
    public GameObject shatter;
    GameObject[] shatters;
    GameObject[] fixes;
    public GameObject fix;

    void Awake() {
        DontDestroyOnLoad(gameObject);

        // if (instance == null) {
        //     instance = this;
        // } else {
        //     DestroyObject(gameObject);
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        lives = new GameObject[maxHp];
        shatters = new GameObject[maxHp];
        fixes = new GameObject[maxHp];

        for (int i = 0; i < maxHp; i++)
        {
            lives[i] = new GameObject("Life " + (i+1));
            lives[i].transform.SetParent(transform);
            lives[i].transform.position = transform.position + Vector3.right * i * imageInterval;
            SpriteRenderer r = lives[i].AddComponent<SpriteRenderer>();
            r.sprite = images[0];
            r.sortingOrder = 1;
            r.material = mat;

            shatters[i] = Instantiate(shatter, lives[i].transform.position, Quaternion.identity, lives[i].transform);
            fixes[i] = Instantiate(fix, lives[i].transform.position, Quaternion.identity, lives[i].transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        hp = GameObject.Find("Player").GetComponent<PlayerController>().health;
        slideHp = Mathf.Lerp(slideHp, hp, dmgLerp);
        for (int i = 0; i < maxHp; i++)
        {
            SpriteRenderer r = lives[i].GetComponent<SpriteRenderer>();
            if (hp > i) r.sprite = images[0];
            else if (slideHp > i+0.1f) {
                r.sprite = images[1];
                if(!shatters[i].GetComponent<ParticleSystem>().isPlaying) {
                    shatters[i].GetComponent<ParticleSystem>().Play();
                }
            }
            else r.sprite = images[2];
        }
    }

    public void GainLife() {
        fixes[hp].GetComponent<ParticleSystem>().Play();
    }
}
