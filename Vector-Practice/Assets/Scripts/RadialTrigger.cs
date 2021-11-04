using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
    #endif

public class RadialTrigger : MonoBehaviour
{
    //Range[(0f,10f)]
    public float radius = 1f;

    public Transform playerTf;

    private void OnDrawGizmos()
    {
        Vector2 enemyCenter = transform.position;
        Vector2 playerPos = playerTf.position;

        float dist = Vector2.Distance(enemyCenter, playerPos);

        bool isInRange = dist < radius;

        Handles.color = isInRange ? Color.red : Color.green;
        Handles.DrawWireDisc(enemyCenter, new Vector3(0, 0, 1), radius);
    }
}
