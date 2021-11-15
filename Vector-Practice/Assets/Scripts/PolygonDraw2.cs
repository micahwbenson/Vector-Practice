using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonDraw2 : MonoBehaviour
{
    const float Tau = 6.28318530718f;

    [Range(3, 6)]
    public int pointsOnPolygon = 3;

    [Range(1, 2)]
    public int densityModifier = 1;

    private void OnDrawGizmos()
    {
        for (int d = 0; d < pointsOnPolygon * densityModifier; d++)
        {
            //Straight drawing 
            if (densityModifier % 2 != 0)
            {

            }

            //if density modifer is greater than 1
            if (densityModifier % 2 == 0)
            {

            }
        }
    }
}
