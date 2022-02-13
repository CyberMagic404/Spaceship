using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsChecker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float radius = 2f;
    public bool keepOnScreen = true;

    public float cameraHeight, cameraWidth;
    public bool isOnScreen = true;

    [HideInInspector]
    public bool left, right, up, down;

    private void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Camera.main.aspect;
    }

    private void LateUpdate()
    {
        isOnScreen = true;
        Vector3 position = transform.position;
        right = left = up = down;
        if(position.x > cameraWidth - radius)
        {
            position.x = cameraWidth - radius;
            isOnScreen = false;
            right = true;
        }

        if (position.x < -cameraWidth + radius)
        {
            position.x = -cameraWidth + radius;
            isOnScreen = false;
            left = true;
        }

        if (position.y > cameraHeight - radius)
        {
            position.y = cameraHeight - radius;
            isOnScreen = false;
            up = true;
        }

        if (position.y < -cameraHeight + radius)
        {
            position.y = -cameraHeight + radius;
            isOnScreen = false;
            down = true;
        }
        isOnScreen = !(right || left || up || down);
        if(keepOnScreen && !isOnScreen)
        {
            transform.position = position;
            isOnScreen = true;
            right = left = up = down = false;
        }
        transform.position = position;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
