using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScroller : MonoBehaviour
{
    public float StartPosition = -10f;
    public float EndPosition = 10f;
    public float ScrollSpeed = 1f;


    // Update is called once per frame
    void Update()
    {
        if ( ((EndPosition > StartPosition) && (transform.position.x > EndPosition)) || ((EndPosition < StartPosition) && (transform.position.x < EndPosition)))
        {
            transform.position = new Vector3(StartPosition, transform.position.y, transform.position.z);
        }
        else
        {
            transform.Translate(new Vector3(ScrollSpeed * Time.deltaTime, 0, 0), Space.World);
        }
    }
}
