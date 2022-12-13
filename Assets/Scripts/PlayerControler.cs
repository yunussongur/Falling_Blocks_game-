using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float speed ;
    public event System.Action OnPlayerDeath;

    public float screenHalfWidthInWorldUnits;
    void Start()
    {
        float halfPlayerWidth=transform.localScale.x/2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize+halfPlayerWidth;
    }

    
    void Update()
    {
        float inputx = Input.GetAxisRaw("Horizontal");
        float velocotiy = inputx * speed;
        transform.Translate(Vector2.right * velocotiy * Time.deltaTime);
        if(transform.position.x<- screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if(transform.position.x> screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Falling Block")
        {
           if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
