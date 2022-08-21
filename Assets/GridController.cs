using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public float HSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxis("Horizontal");
        //transform.Translate(-HSpeedMultiplier * VSpeed * Time.deltaTime * XInput, -VSpeed * Time.deltaTime, 0f);
        transform.Translate(-HSpeed * XInput * Time.deltaTime, 0f, 0f);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, 0f);

    }
}
