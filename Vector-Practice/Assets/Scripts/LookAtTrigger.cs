using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
    [Range(0f, 1f)]
    public float strictness = 0.5f;

    public Transform playerTF;

    private void OnDrawGizmos()
    {

        Vector2 position = transform.position;
        Vector2 playerPos = playerTF.transform.position;
        Vector2 playerDirection = playerTF.right;

        Vector2 playerToTriggerDir = (position - playerPos).normalized;



        //I need to take the DOT between the playerPos and the enemy position, normalizing both

        float lookness = Vector2.Dot(playerToTriggerDir, playerDirection);

        bool canSee = lookness < strictness;

        Gizmos.color = canSee ? Color.red : Color.green;
        Gizmos.DrawLine(playerPos, playerPos + playerToTriggerDir);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerPos, playerPos + playerDirection);
    }
}
