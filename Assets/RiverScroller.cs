using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScroller : MonoBehaviour
{
    public float HSpeed = 5f;
    public float VSpeed = 1f;
    public float Acceleration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxis("Horizontal");
        VSpeed += Acceleration * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(-HSpeed * Time.deltaTime * XInput, -VSpeed * Time.deltaTime, 0f);
    }
}
