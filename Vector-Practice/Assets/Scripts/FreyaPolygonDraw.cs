using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreyaPolygonDraw : MonoBehaviour
{
    [Range(3,12)]
    public int sideCount = 4;

    [Range(1, 4)]
    public int densityModifer = 1;

    float TAU = 6.28318530718f;

    private void OnDrawGizmos()
    {
        //So smart to make an array/data-structure, I should have done that
        Vector2[] verts = new Vector2[sideCount];

        Vector2 AngToDir(float radAngle)
        {
            return new Vector2(Mathf.Cos(radAngle), Mathf.Sin(radAngle));
        }

        float DirToAng(Vector2 v)
        {
            return Mathf.Atan2(v.y, v.x);
        }

        //Define each of the verts
        for (int i = 0; i < sideCount; i++)
        {
            verts[i] = AngToDir(i * TAU / sideCount);
        }

        //Draw a vert at each vert
        Gizmos.color = Color.red;
        for (int d = 0; d < sideCount; d++)
        {
            Gizmos.DrawSphere(verts[d], 0.05f);
        }

        //Draw a line between each vert
        Gizmos.color = Color.white;
        for (int l = 0; l < sideCount; l++)
        {
            //Look into modulo operator for array wrapping -- I haven't actually ever done this . . . seems useful though
            Gizmos.DrawLine(verts[l], verts[(l + densityModifer) % sideCount]);
        }


    }
}
