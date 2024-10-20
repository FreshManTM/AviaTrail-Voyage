using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    Vector2 _destination;
    float lineDistance = 1f;
    float planeSpeed = 10f;

    int _collides;
    private void Start()
    {
        _destination = new Vector2(1, transform.position.y);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) | SwipeController.swipeLeft)
        {
            _destination.x = -1 * lineDistance;
        }
        if (Input.GetKeyDown(KeyCode.D) | SwipeController.swipeRight)
        {
            _destination.x = 1 * lineDistance;
        }

        transform.position = Vector2.MoveTowards(transform.position, _destination, planeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Obstacle")
        {
            _collides++;
        }
    }
}
