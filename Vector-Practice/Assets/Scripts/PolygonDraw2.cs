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

    //Converts from an angle to a direction
    Vector2 AngToDir(float radAngle)
    {
        return new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
    }

    private void OnDrawGizmos()
    {


        Vector2 savedPlace = Vector2.right;
        Vector2 start = Vector2.right;

        for (int d = 0; d < pointsOnPolygon * densityModifier; d++)
        {
            //You need an interperlator to set each vector position -- gives each vector position in turns
            float t = d / (float)pointsOnPolygon;

            //Converting turns into radians
            float radAng = t * Tau;

            Vector2 point = AngToDir(radAng);

            Gizmos.DrawSphere(point, 0.05f);

            //Now drawing the lines fo reach polygon -- regular polygon drawing
            if (densityModifier == 1)
            {
                if (d == 0)
                {
                    start = point;
                    savedPlace = point;
                }
                else if (d < pointsOnPolygon)
                {
                    Gizmos.DrawLine(point, savedPlace);
                    savedPlace = point;
                }
            }
            else
            {
                if (d == 0)
                {
                    start = point;
                    savedPlace = point;
                }
                else if (d % 2 == 0)
                {
                    Gizmos.DrawLine(point, savedPlace);
                    savedPlace = point;
                }
            }
        }
        Gizmos.DrawLine(start, savedPlace);
            
    }
}
