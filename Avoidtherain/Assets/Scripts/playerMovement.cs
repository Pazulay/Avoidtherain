using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    float speed = 7f;
    public event System.Action OnPlayerDeath;
    public float ScreenHalfWidth;
    public float HalfPlayerSize;

    
    void Start()
    {
        ScreenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        HalfPlayerSize = transform.localScale.x/2f;
        
    }

    
    void Update()
    {
        PlayerInput();
        HitScreenWall();
    }

    void PlayerInput()
    {
        Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), 0);
		Vector2 moveAmount = input.normalized * speed * Time.deltaTime;
        transform.Translate(moveAmount);
    }

    void HitScreenWall()
    {
        if (transform.position.x > ScreenHalfWidth + HalfPlayerSize)
        {
            transform.position = new Vector2 (-ScreenHalfWidth, transform.position.y);
        }

        if (transform.position.x < -ScreenHalfWidth - HalfPlayerSize)
        {
            transform.position = new Vector2 (ScreenHalfWidth, transform.position.y);
        }

    }

    void OnTriggerEnter(Collider triggerCollider) {

        if (triggerCollider.tag == "Obstacle"){
            if (OnPlayerDeath != null){
                OnPlayerDeath();

            }
            Destroy(gameObject);
        }
    } 
}
