using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    public float MinHorzPosition = -12f;
    public float MaxHorzPosition = 12f;

    public float MaxBankAngle = 45f;
    public GameObject MissilePrefab;
    public Transform Overworld;

    float PlayerTargetXPosition;
    float PlayerTargetYPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //store the player's starting position.  We will use easing to keep the player in this spot on the screen.
        PlayerTargetXPosition = transform.position.x;
        PlayerTargetYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.PlayerVSpeed += gameManager.PlayerVAcceleration * Time.deltaTime * Input.GetAxis("Vertical");

        float XInput = Input.GetAxis("Horizontal");
        gameManager.PlayerXPosition += gameManager.PlayerHSpeedMultiplier * gameManager.PlayerVSpeed * XInput * Time.deltaTime;
        gameManager.PlayerXPosition = Mathf.Clamp(gameManager.PlayerXPosition, MinHorzPosition, MaxHorzPosition);

        transform.rotation = Quaternion.Euler(0, MaxBankAngle * XInput, 0);

        //Ease the player back into position in case it is pushed by a collision
        //Easing: X += gain * (target - X);
        transform.position = new Vector2(transform.position.x + 0.1f * (PlayerTargetXPosition - transform.position.x),
            transform.position.y + 0.1f * (PlayerTargetYPosition - transform.position.y));

        //Fire1 maps to "Ctrl"
        if ( Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space) )
        {
            GameObject missile = Instantiate(MissilePrefab, Overworld, true);

            //set the bullet slightly ahead of the player so that it doesn't collide with the player
            missile.transform.position = transform.position + 0.5f * Vector3.up;
        }
    }
}
