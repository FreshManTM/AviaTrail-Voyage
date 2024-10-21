using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] GameController _GController;


    Vector2 _destination;
    float _lineDistance = 1f;
    float _planeSpeed = 10f;
    int _collides;

    private void Start()
    {
        _destination = new Vector2(1, transform.position.y);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) | SwipeController.swipeLeft)
        {
            _destination.x = -1 * _lineDistance;
        }
        if (Input.GetKeyDown(KeyCode.D) | SwipeController.swipeRight)
        {
            _destination.x = 1 * _lineDistance;
        }

        transform.position = Vector2.MoveTowards(transform.position, _destination, _planeSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Obstacle":
                print("obstacle");
                _GController.ResetCombo();
                _collides++;
                break;
            case "PassTrigger":
                _GController.AddPoints();
                break;
            case "FinishLine":
                print("win");
                _GController.Win(_collides);
                break;
            case "Chevron":
                _GController.AddChevrons(10);
                Destroy(collision.gameObject);
                break;
        }
    }
}
