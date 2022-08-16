using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MaxBankAngle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxis("Horizontal");
        //transform.Translate(Speed * Time.deltaTime * Input.GetAxis("Horizontal"), Speed * Time.deltaTime * Input.GetAxis("Vertical"), 0f);
        transform.rotation = Quaternion.Euler(0, MaxBankAngle * XInput, 0);

    }
}
