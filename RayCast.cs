using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    [SerializeField]
    float distance = -1f;

    public LayerMask horimask;
    public   Transform horipoint;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;
       RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down * transform.localScale.y, distance, horimask);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Hori"))
            {
                transform.position = horipoint.position.y += new Vector3(0, (float)2.543, 0);
            }
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.down * transform.localScale.y * distance);
    }
}