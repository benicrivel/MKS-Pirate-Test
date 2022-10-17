using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour
{
    [Header ("Ship Health")]
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    [SerializeField]
    private Slider healthBar;

    [SerializeField]
    public Rigidbody2D rb;

    [Header("Ship Attributes")]
    [SerializeField]
    public float shipVelocity;

    [Header("Attack Properties")]
    [SerializeField]
    private float attackCooldown;
    private float nextAttack;
    private bool canAttack;

    [Header ("Cannon Positions and Bullets")]
    [SerializeField]
    private GameObject cannonBall;
    [SerializeField]
    private int cannonBallDamage;
    [SerializeField]
    private float cannonBallSpeed;
    [SerializeField]
    private string target;
    [SerializeField]
    private GameObject frontalCannonPos, rightCannonPos1, rightCannonPos2, rightCannonPos3, LeftCannonPos1,LeftCannonPos2, LeftCannonPos3; 


    void Start()
    {
        currentHealth = maxHealth;        
        healthBar.maxValue = maxHealth;
        canAttack = true;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        CheckHP();
    }

    private void CheckHP()
    {
        healthBar.value = currentHealth;
        switch (currentHealth)
        {
            case >= 66:
                //set anim
                break;

            case >= 33:
                //
                break;

            case 0:
                //dead animation
                break;
        }
    }

    private void CheckCanAttack()
    {
        Debug.Log("delta" + Time.time + " + Next attack: " + nextAttack);
        if (Time.time > nextAttack)
        {
            canAttack = true;
        }
    }

    private void SetNextAttack()
    {
        Debug.Log("setou");
        canAttack = false;
        nextAttack = Time.time + attackCooldown;
    }

    public void FrontalShot()
    {
        CheckCanAttack();
        if (canAttack)
        {
            InstantiateCannonBall(frontalCannonPos);
            SetNextAttack();
        }        
    }

    public void RightShot()
    {
        CheckCanAttack();
        if (canAttack)
        {
            InstantiateCannonBall(rightCannonPos1);
            InstantiateCannonBall(rightCannonPos2);
            InstantiateCannonBall(rightCannonPos3);
            SetNextAttack();
        }
    }

    public void LeftShot()
    {
        CheckCanAttack();
        if (canAttack)
        {
            InstantiateCannonBall(LeftCannonPos1);
            InstantiateCannonBall(LeftCannonPos2);
            InstantiateCannonBall(LeftCannonPos3);
            SetNextAttack();
        }
    }
    private void InstantiateCannonBall(GameObject initialPosition)
    {
        GameObject o = Instantiate(cannonBall, initialPosition.transform.position, initialPosition.transform.rotation);
        o.GetComponent<CannonBall>().setDamageAmount(cannonBallDamage);
        o.GetComponent<CannonBall>().setTarget(target);
        o.GetComponent<Rigidbody2D>().AddForce(initialPosition.transform.up * cannonBallSpeed, ForceMode2D.Impulse);
    }

}
