using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassTrigger : MonoBehaviour
{
    private void Start()
    {
        if (transform.parent.localPosition.x < 0)
        {
            transform.localPosition = Vector3.right * 2;
        }
        else
        {
            transform.localPosition = Vector3.left * 2;
        }
    }
}
