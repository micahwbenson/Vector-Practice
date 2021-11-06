using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTransformWorldToLocal : MonoBehaviour
{
    public Vector2 localSpacePt;

    private void OnDrawGizmos()
    {
        Vector2 objPos = transform.position;
        Vector2 right = transform.right;
        Vector2 up = transform.up;

        DrawBasisVectors(objPos, right, up);
        DrawWorldBasisVectors();

        //Gizmos.color = Color.cyan;
        //Gizmos.DrawSphere(LocaltoWorld(localSpacePt), 0.1f);

        //Vector2 LocaltoWorld(Vector2 localSpacePt)
        //{
        //    Vector2 worldConversionVector = localSpacePt.x * right + localSpacePt.y * up;
        //    return objPos + worldConversionVector;
        //}
    }

    private void DrawBasisVectors(Vector2 pos, Vector2 right, Vector2 up)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(pos, right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(pos, up);
    }

    private void DrawWorldBasisVectors()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(Vector2.zero, Vector2.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(Vector2.zero, Vector2.up);
    }
}
