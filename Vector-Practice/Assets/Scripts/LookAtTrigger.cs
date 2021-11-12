using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    [Range(0f, 90f)]
    public float angleThreshold = 0.5f;

    public Transform playerTF;

    private void OnDrawGizmos()
    {

        Vector2 position = transform.position;
        Vector2 playerPos = playerTF.transform.position;
        Vector2 playerDirection = playerTF.right;

        Vector2 playerToTriggerDir = (position - playerPos).normalized;



        //I need to take the DOT between the playerPos and the enemy position, normalizing both

        float dot = Vector2.Dot(playerToTriggerDir, playerDirection);
        dot = Mathf.Clamp(dot, -1, 1); // This is just to make sure the dot value doesn't go outside of the normalized range which can happen due to strange floating point values, etc

        float angRad = Mathf.Acos(dot); //This is giving you the angle in radians from the dot product . . . right?

        float angThresholdRad = angleThreshold * Mathf.Deg2Rad;

        //You don't actually need to do this manually though . . . Vector2.Angle( v1, v2) -- will return the angle between vectors, which is useful for a non-mathhead like me, but I like to know what's going on

        bool canSee = angRad < angThresholdRad;

        Gizmos.color = canSee ? Color.red : Color.green;
        Gizmos.DrawLine(playerPos, playerPos + playerToTriggerDir);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerPos, playerPos + playerDirection);
    }
}
