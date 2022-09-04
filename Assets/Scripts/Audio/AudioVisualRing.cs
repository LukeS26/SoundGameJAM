using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualRing : MonoBehaviour
{

    public Transform pTransform;
    public float range, rangeMax, rangeStart, rangeSpeed;
    public float startLineWidth, lineWidth,lineWidthSpeed;
    public static AudioVisualRing Instance;
    public bool scared;

    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 5)]
    public float xradius = 5;
    [Range(0, 5)]
    public float yradius = 5;
    LineRenderer line;

    void Start()
    {
        //set instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        pTransform = gameObject.transform;
        line = gameObject.GetComponent<LineRenderer>();

        line.positionCount = segments + 1;
        line.useWorldSpace = false;
        CreatePoints();
        startLineWidth = line.widthMultiplier;
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

    // Update is called once per frame
    void Update()
    {
        range += rangeSpeed*Time.deltaTime;

       // lineWidth -=lineWidthSpeed*Time.deltaTime;
        lineWidth -= range/rangeSpeed*Time.deltaTime;
        if (range > rangeMax)
        {
            range = rangeStart;
            lineWidth = startLineWidth;
        }
        if (lineWidth < 0)
        {
            lineWidth = 0;
        }

        pTransform.localScale = new Vector3(range, range);
        line.widthMultiplier = lineWidth;


    }
}
