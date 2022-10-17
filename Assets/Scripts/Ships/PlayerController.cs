using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Ship
{
    [Header ("Player Unique")]
    [SerializeField]
    private int howMuchRotation;    

    #region Start and Updates
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckAttackInput();
    }

    private void FixedUpdate()
    {
        CheckMovementInput();
    }
    #endregion

    #region Inputs
    private void CheckMovementInput()
    {        
        if(Input.GetAxis("Vertical") > 0)
        {
            rb.velocity = transform.up * Input.GetAxis("Vertical") * shipVelocity;
        }else if(Input.GetAxis("Vertical") < 0)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0f;
        }
        transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Horizontal")) * Time.deltaTime * howMuchRotation, Space.World);
    }
       
    private void CheckAttackInput()
    {
        if (Input.GetButtonDown("FrontalShot"))
        {
            FrontalShot();       
        }
        if (Input.GetButtonDown("RightShot"))
        {
            RightShot();
        }
        if (Input.GetButtonDown("LeftShot"))
        {
            LeftShot();    
        }
    }

    #endregion
}
