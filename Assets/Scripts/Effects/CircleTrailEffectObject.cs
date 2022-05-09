using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleTrailEffectObject : MonoBehaviour
{
    private float fadeOutSpeed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
        if(transform.localScale.x <= 0.01f)
        {
            Destroy(this.gameObject);
        }
        transform.localScale -= new Vector3(fadeOutSpeed * Time.deltaTime, fadeOutSpeed * Time.deltaTime, fadeOutSpeed * Time.deltaTime);
    }
}
