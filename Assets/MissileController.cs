using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float Speed = 5f;
    public float MaxY = 6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, Speed * Time.deltaTime, 0f);
        if (transform.position.y > MaxY) { Destroy(gameObject); }
    }
}
