using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    float r;
    public float Target;
    public float rndR;
    private int point;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float AngleA;
    private float Angle;

    public int health = 100;

    public GameObject explodeEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 )
        {
            Destroy(gameObject);
        }
        spin();
    }

    private void spin()
    {
        //Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, AngleA, ref r, 0.1f);
        Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, AngleA, ref r, 0.1f);
        transform.rotation = Quaternion.Euler(0, 0, Angle);
        point = UnityEngine.Random.Range(1, 3);
    }

    public void ChangeAngle()
    {
        direction = player.position - transform.position;
        AngleA = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        AngleA += 28;

        point = UnityEngine.Random.Range(1, 3);

        switch (point)
        {
            case 1:
                AngleA += 120;
                break;
            case 2:
                AngleA += 240;
                break;
                case 3:
                AngleA += 360;
                break;
        }
        
    }

    public void TakeDamage(int damage)
    {
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage Taken");
    }

    IEnumerator test()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            ChangeAngle();
        }


        yield return null;

    }
}
