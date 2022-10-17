using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField]
    private string target;

    [SerializeField]
    private int damageAmount;

    [SerializeField]
    private float secondsToDestroy;

    private void Start()
    {
        StartCoroutine(DestroyAfterSeconds(secondsToDestroy));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == target)
        {
            collision.gameObject.SendMessage("TakeDamage", damageAmount);
            DestroyCannonBall();
        }
        else if (collision.gameObject.tag == "Props")
        {
            DestroyCannonBall();
        }
    }

    public void setDamageAmount(int dmgAmount)
    {
        damageAmount = dmgAmount;
    }

    public void setTarget(string tar)
    {
        target = tar;
    }

    IEnumerator DestroyAfterSeconds(float secs)
    {
        yield return new WaitForSeconds(secs);
        DestroyCannonBall();
    }

    private void DestroyCannonBall()
    {
        Destroy(gameObject);
    }
}
