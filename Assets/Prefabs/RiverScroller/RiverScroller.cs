using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverScroller : MonoBehaviour
{
    GameManager gameManager;
    public float WrapAt = -150f;
    public float WrapAmt = 500f;

    public GameObject[] RiverScrollers;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        RandomSelectRiverScroller();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, -gameManager.PlayerVSpeed * Time.deltaTime, 0f);

        if (transform.position.y < WrapAt)
        {
            transform.Translate(0f, WrapAmt, 0f);
            RandomSelectRiverScroller();
        }

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
