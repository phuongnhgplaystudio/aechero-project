using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightMoveUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 10f)
        {
            Destroy(this.gameObject);
        }
        var tempPosition = transform.position;
        tempPosition.y += 20f * Time.fixedDeltaTime;
        transform.position = tempPosition;
    }
}
