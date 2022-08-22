using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float Speed = 5f;
    public float MaxY = 6f;
    public GameObject ExplosionPrefab;

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

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //do not let the the player hit itself
        if (otherCollider.gameObject.tag == "Player") return;

        GameObject explosion = Instantiate(ExplosionPrefab);
        explosion.transform.position = transform.position;

        Destroy(gameObject);    //destroy the missile
    }
}
