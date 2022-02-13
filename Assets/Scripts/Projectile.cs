using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private BoundsChecker boundsChecker;

    private void Awake()
    {
        boundsChecker = GetComponent<BoundsChecker>();
    }


    void Update()
    {
        if(boundsChecker.up)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Transform rootHere = collider.gameObject.transform.root;
        GameObject go = rootHere.gameObject;
        if (go.tag == "Enemy")
        {
            Destroy(go);
            Destroy(gameObject);
        }
    }
}
