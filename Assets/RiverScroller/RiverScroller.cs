using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScroller : MonoBehaviour
{
    public float HSpeedMultiplier = 0.75f;
    public float VSpeed = 1f;
    public float Acceleration = 1f;
    public float WrapAt = -150f;
    public float WrapAmt = 500f;

    public GameObject[] RiverScrollers;

    // Start is called before the first frame update
    void Start()
    {
        RandomSelectRiverScroller();
    }

    // Update is called once per frame
    void Update()
    {
        float XInput = Input.GetAxis("Horizontal");
        VSpeed += Acceleration * Time.deltaTime * Input.GetAxis("Vertical");
        transform.Translate(-HSpeedMultiplier * VSpeed * Time.deltaTime * XInput, -VSpeed * Time.deltaTime, 0f);

        if (transform.position.y < WrapAt)
        {
            transform.Translate(0f, WrapAmt, 0f);
            RandomSelectRiverScroller();
        }

        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -8f, 8f), transform.position.y, 0f);
    }

    void DisableScrollers()
    {
        //disable all river scrollers
        foreach (GameObject x in RiverScrollers)
        {
            x.SetActive(false);
        }
    }

    void RandomSelectRiverScroller()
    {
        DisableScrollers();

        //function to randomly enable a river scroller
        int randomIndex = Random.Range(0, RiverScrollers.Length);
        RiverScrollers[randomIndex].SetActive(true);
    }

}
