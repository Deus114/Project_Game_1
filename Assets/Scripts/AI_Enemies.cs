using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.TextCore.Text;

public class AI_Enemies : MonoBehaviour
{
    // Parameters of AI Enemies
    public float moveSpeed;
    public float nextWayPointDistance = 2f;
    public float repeatTimeUpdatePath;
    public SpriteRenderer characterSR;
    public bool roaming, updateContinuePath;
    //public Transform Target;
    bool reached = false;

    // Some declares
    Path path;
    public Seeker seeker;
    Coroutine moveCoroutine;

    // Skill Shoot
    public bool canShoot = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float coolDown;

    Vector2 FindTarget()
    {
        Vector3 Target = FindObjectOfType<Player>().transform.position;
        if (FindObjectOfType<Player>())
        {
            if (roaming == true)
            {
                return (Vector2)Target + (Random.Range(5f, 8f) * new Vector2(Random.Range(-1, 1), Random.Range(-1, 1)).normalized);
            }
            else
            {
                return Target;
            }
        }
        else return Vector2.zero;
    }
    void CalculatePath()
    {
        Vector2 target = FindTarget();
        if (seeker.IsDone() && (reached || updateContinuePath))
            seeker.StartPath(transform.position, target, OnPathCompleted);
    }

    void OnPathCompleted(Path p)
    {
        if (p.error) return;
        path = p;
        // Move to Target
        MoveToTarget();
    }

    void MoveToTarget()
    {
        if (moveCoroutine != null) StopCoroutine(moveCoroutine);
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;
        reached = false;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - (Vector2)transform.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWP]);
            if (distance < nextWayPointDistance)
                currentWP++;

            if (force.x != 0)
            {
                if (force.x < 0)
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                else
                    characterSR.transform.localScale = new Vector3(1, 1, 0);
            }

            yield return null;
        }
        reached = true;
    }

    void Enemies_Skill_Shoot()
    {
        var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindObjectOfType<Player>().transform.position;
        Vector3 directiom = playerPos - transform.position;
        rb.AddForce(directiom.normalized * bulletSpeed, ForceMode2D.Impulse);
    }

    private void Start()
    {
        InvokeRepeating("CalculatePath", 0f, repeatTimeUpdatePath);
        reached = true;
    }
    private void Update()
    {
        if (canShoot)
        {
            coolDown -= Time.deltaTime;
            if (coolDown < 0)
            {
                coolDown = timeBtwFire;
                // Shoot
                Enemies_Skill_Shoot();  
            }
        }
    }
}
