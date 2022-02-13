using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero solo;

    [Header("Set in inspector")]
    public float speed = 40;
    public float hp = 3;
    public GameObject projectilePrefab;
    public float projectileSpeed = 70;

    private GameObject lastTrigger;
    private float gameRestartDelay = 2f;

    void Awake()
    {
        if (solo == null)
        {
            solo = this;
        }
        else
        {
            Debug.LogError("Hero.Awake()");
        }
    }

    
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        position.x += xAxis * speed * Time.deltaTime;
        position.y += yAxis * speed * Time.deltaTime;
        transform.position = position;
        
        transform.rotation = Quaternion.Euler(yAxis * 25, xAxis * -25, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0, 0.4f);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }
    }


    void Fire()
    {
        GameObject projectileGameObject = Instantiate(projectilePrefab);
        projectileGameObject.transform.position = transform.position;
        Rigidbody rigidbody = projectileGameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.up * projectileSpeed;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Transform rootHere = collider.gameObject.transform.root;
        GameObject go = rootHere.gameObject;
        print("Triggered with " + go.name);

        if(go == lastTrigger)
        {
            return;
        }
        lastTrigger = go;

        if(go.tag == "Enemy")
        {
            hp -= 1;
            Destroy(go);
        }
        else
        {
            print("Just because");
        }

        if(hp == 0)
        {
            Destroy(gameObject);
            Main.solo.DelayedRestart(gameRestartDelay);
        }
    }
}
