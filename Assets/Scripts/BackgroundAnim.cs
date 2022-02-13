using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnim : MonoBehaviour
{

    [Header("Set in inspector")]
    public GameObject point;
    public GameObject[] panels;
    public float scrollSpeed = -40f;
    public float motionSpeed = 0.3f;

    private float panelHeight;
    private float depth;
    
    void Start()
    {
        panelHeight = panels[0].transform.localScale.y;
        depth = panels[0].transform.position.z;

        panels[0].transform.position = new Vector3(0, 0, depth);
        panels[1].transform.position = new Vector3(0, panelHeight, depth);
    }

    
    void Update()
    {
        float tempY, tempX = 0;
        tempY = Time.time * scrollSpeed % panelHeight + (panelHeight * 0.5f);

        if(point != null)
        {
            tempX = -point.transform.position.x + motionSpeed;
        }

        panels[0].transform.position = new Vector3(tempX, tempY, depth);

        if(tempY >= 0)
        {
            panels[1].transform.position = new Vector3(tempX, tempY - panelHeight, depth);
        }
        else
        {
            panels[1].transform.position = new Vector3(tempX, tempY + panelHeight, depth);
        }
    }
}
