using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShip : Ship
{
    [SerializeField]
    private PlayerController pc;
    [SerializeField]
    private float offset;
    private Vector3 playerPos;
    private Vector3 thisPos;
    private float angle;
    private Vector2 moveDirection;

    #region Start and Update
    void Start()
    {
        GetPlayerGO();
    }

    void Update()
    {
        //rb.angularVelocity = 0f;
        LookAtPlayer();
        OutroTuto();
    }

    private void FixedUpdate()
    {
        OutroTutoFixed();
    }
    #endregion

    public void OutroTuto()
    {
        Vector3 direction = (pc.transform.position - transform.position).normalized;
        angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;
    }

    public void OutroTutoFixed()
    {
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * shipVelocity;
    }

    public void GetPlayerGO()
    {
        pc = GameObject.FindGameObjectWithTag("Player")?.GetComponent<PlayerController>();        
    }

    public void LookAtPlayer()
    {
        playerPos = pc.transform.position;
        thisPos = transform.position;
        playerPos.x = playerPos.x - thisPos.x;
        playerPos.y = playerPos.y - thisPos.y;
        angle = Mathf.Atan2(playerPos.y, playerPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }

    #region Random Position 
    public Vector3 RandomPoint()
    {
        Mesh navMesh = null;
        if (navMesh == null)
        {
            NavMeshTriangulation triangulatedNavMesh = NavMesh.CalculateTriangulation();
            navMesh = new Mesh();
            navMesh.vertices = triangulatedNavMesh.vertices;
        }
        Vector3 point1 = navMesh.vertices[Random.Range(0, navMesh.vertexCount)];
        Vector3 point2 = navMesh.vertices[Random.Range(0, navMesh.vertexCount)];
        return Vector3.Lerp(point1, point2, Random.value);
    }
    #endregion
}
