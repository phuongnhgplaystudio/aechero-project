using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HutpeeCalculations
{
    public static float GetAngleFromVectorFloat(Vector3 v)
    {
        float angle = 0;
        angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        return angle;
    }

    public static bool SingleChanceIn100(int chance)
    {
        if(Random.Range(0, 100) < chance)
        {
            return true;
        }
        return false;
    }

    public static int SelectionChanceIn100(int[] array)
    {
        int randomNum = Random.Range(0, 100);
        for(int i = 0; i < array.Length; i++)
        {
            if(randomNum >= array[i])
            {
                return i;
            }
        }
        return array.Length - 1;
    }
}
