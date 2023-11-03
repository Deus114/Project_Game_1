using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public int minDmg, maxDmg;
    public bool playerBullets;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerBullets)
        {
            int damage = Random.Range(minDmg, maxDmg);  
            collision.GetComponent<Player>().TakeDmg(damage);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Enemies") && playerBullets)
        {
            int damage = Random.Range(minDmg, maxDmg);
            collision.GetComponent<Enemies_Controller>().TakeDmg(damage);
            Destroy(gameObject);
        }
    }
}
