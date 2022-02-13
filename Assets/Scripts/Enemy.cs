using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Set in inspector")]
    public float speed = 25;

    private BoundsChecker boundsChecker;

    private void Awake()
    {
        boundsChecker = GetComponent<BoundsChecker>();
    }

    public Vector3 position
    {
        get
        {
            return transform.position;
        }

        set
        {
            transform.position = value;
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = position;
        tempPos.y -= speed * Time.deltaTime;
        position = tempPos;
    }
   
    void Update()
    {
        Move();
        if(boundsChecker != null && boundsChecker.down)
        {
            Destroy(gameObject);
        }
    }
}
