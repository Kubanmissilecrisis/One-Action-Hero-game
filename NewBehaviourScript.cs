using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    float movespeed = 5f;

    public Transform movePoint;
    void Start()
    {
        movePoint.parent = null;

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) == 0f)
        {

            if (Input.GetKey("d"))
            {
                movePoint.position += new Vector3((float)2.543,0,0);
            }

            else if (Input.GetKey("a"))
            {
                movePoint.position += new Vector3((float)-2.543, 0, 0);
            }
        }
    }

}
