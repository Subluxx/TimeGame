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
    private int rotation = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(test());
    }

    // Update is called once per frame
    void Update()
    {
        spin();
    }

    private void spin()
    {
        
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.z, Target, ref r, 0.1f);

            transform.rotation = Quaternion.Euler(0, 0, Angle);
            rotation = UnityEngine.Random.Range(1, 3);
    }

    public void ChangeAngle()
    {
        Target = rndR = UnityEngine.Random.Range(-360, 360);
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
