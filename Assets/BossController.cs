using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] ParticleSystem explodeEffect;

    float r;
    public float Target;
    public float rndR;
    [SerializeField] private int rotationDir;
    public Transform player;
    private Rigidbody2D rb;
    private Vector3 direction;
    private float AngleA;
    private float Angle;

    public int health = 100;

    
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
        
        if (rotationDir == 0)
        {
            AngleA -= 120;
        }
        else
        {
            AngleA += 120;
        }
        Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, 720, ref r, 0.3f);
        transform.rotation = Quaternion.Euler(0, 0, Angle);
    }

    public void ChangeAngle()
    {
        direction = player.position - transform.position;
        AngleA = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        AngleA += 28;

        rotationDir = UnityEngine.Random.Range(0, 2);
    }

    public void TakeDamage(int damage)
    {
        explodeEffect.Play();
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
