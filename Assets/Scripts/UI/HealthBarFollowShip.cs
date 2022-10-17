using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollowShip : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (target)
        {            
            transform.position = target.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }        
    }
}
