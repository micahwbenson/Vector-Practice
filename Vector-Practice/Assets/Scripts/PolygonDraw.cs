using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolygonDraw : MonoBehaviour
{
    [Range(3, 6)]
    public int pointsOnPolygon;

    const float Tau = 6.28318530718f;

    Vector2 AngToDir(float rad)
    {
        return new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < pointsOnPolygon; i++)
        {
            //Interperlator - calculating turns for for each point
            float t = i / (float)pointsOnPolygon;
            //Converting turns to radians, dope!
            float radAng = t * Tau;

            Vector2 point = AngToDir(radAng);

            Gizmos.DrawSphere(point, 0.05f);
        }
    }

    //const float TAU = 6.28318530718f;
    //[Range(0, 100)]
    //public int dotCount = 16;

    //private void OnDrawGizmos()
    //{
    //    //Need to review and practice this again, because I'm pretty sure I don't really remember any of it

    //    //Getting x and y coordinates
    //    Vector2 AngToDir(float angRad) => new Vector2(Mathf.Cos(angRad), Mathf.Sin(angRad));

    //    //Taking a vector and getting an angle out of that
    //    //float DirToAng( Vector2 v)
    //    //{
    //    //    return Mathf.Atan2(v.y, v.x); //Atan2 puts y and x backwards, super annoying
    //    //}

    //    for (int i = 0; i < dotCount; i++)
    //    {
    //        //A value going from zero to 1 - don't -1 to avoid drawing a dot at 0 and 360
    //        //This is the angle in turns - a count of one
    //        float t = i / (float)dotCount; // A value from 0 to 1 - interperlator - "normalised value range" - in this case it also means turns!!!
    //        //Converted from turns into radians
    //        float angRad = t * TAU;

    //        Vector2 point = AngToDir(angRad);


    //        Gizmos.DrawSphere(point, 0.05f);
    //        //How to draw a line between each of these spheres though? 
    //    }
    //}
}
