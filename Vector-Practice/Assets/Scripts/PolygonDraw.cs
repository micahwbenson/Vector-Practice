using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonDraw : MonoBehaviour
{
    [Range(3, 6)]
    public int pointsOnPolygon;

    [Range(1, 2)]
    public int densityModifier;

    const float Tau = 6.28318530718f;

    Vector2 AngToDir(float rad)
    {
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }

    //Just memorize how these functions work for now, and you'll develop a facility with them over time . . .
    float DirToAng(Vector2 v)
    {
        return Mathf.Atan2(v.y, v.x);
    }

    private void OnDrawGizmos()
    {
        //Weird way to do this, but I think it will work! -- These values are quickly overwritten by the polygon draw functions
        Vector2 One = Vector2.up;
        Vector2 Start = Vector2.up;

        if (densityModifier > 1)
        {
            int densityCount = 0;
            for (int d = 0; d <= pointsOnPolygon * densityModifier; d++)
            {
                //Interperlator - calculating turns for for each point
                float t = d / (float)pointsOnPolygon;
                if (d > pointsOnPolygon)
                {
                    t = t - 1;
                }
                //Converting turns to radians, dope!
                float radAng = t * Tau;

                Vector2 point = AngToDir(radAng);
                if (d <= pointsOnPolygon)
                {
                    Gizmos.DrawSphere(point, 0.05f);
                }

                //Polygon Draw Function with the Density Modifier

                densityCount++;
                if (d == 0)
                {
                    Start = point;
                }
                else if (densityCount != 0)
                {
                    Gizmos.DrawLine(point, Start);
                    Start = point;
                    densityCount = 1;
                }


                //if (d == pointsOnPolygon)
                //{
                //    for (int f = (pointsOnPolygon); f > pointsOnPolygon; f--)
                //    {
                //        I forgot the drawing functions here, that's why it's not working and the star polygon was just looping through an additional time offeset by one
                //        float tTwo = f / (float)pointsOnPolygon;
                //        Converting turns to radians, dope!
                //        float radAng2 = tTwo * Tau;

                //        Vector2 point2 = AngToDir(radAng);

                //        if (f == pointsOnPolygon)
                //        {
                //            Start = point2;
                //        }
                //        else if (f % densityModifier == 0 && f != 0)
                //        {
                //            Gizmos.DrawLine(point2, Start);
                //            Start = point2;
                //        }
                //    }
                //}



                One = point;
                //if (d == 0)
                //{
                //    Start = point;
                //}
            }
            Gizmos.DrawLine(Start, Vector2.right);
        }
        //else if (densityModifier == 1)
        //{
        //    for (int i = 0; i <= pointsOnPolygon; i++)
        //    {
        //        //Interperlator - calculating turns for for each point
        //        float t = i / (float)pointsOnPolygon;
        //        //Converting turns to radians, dope!
        //        float radAng = t * Tau;

        //        Vector2 point = AngToDir(radAng);

        //        Gizmos.DrawSphere(point, 0.05f);


        //        //Basic polygon draw function
        //        if (densityModifier == 1)
        //        {
        //            if (i != 0 && i != i - 1)
        //            {
        //                Gizmos.DrawLine(point, One);
        //            }
        //            else if (i == i - 1)
        //            {
        //                Gizmos.DrawLine(point, One);
        //            }
        //        }

        //        One = point;
        //        if (i == 0)
        //        {
        //            Start = point;
        //        }
        //    }
        //}

        if (densityModifier == 1)
        {
            Gizmos.DrawLine(One, Start);
        }

    }
}


