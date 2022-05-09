using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(transform.position.x <= -14f)
        {
            Destroy(this.gameObject);
        }
        var tempPosition = transform.position;
        tempPosition.x -= Time.fixedDeltaTime;
        transform.position = tempPosition;
    }
}
