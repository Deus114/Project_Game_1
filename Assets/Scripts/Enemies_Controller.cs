using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_Controller : MonoBehaviour
{
    Player playerScript;
    public int minDmg;
    public int maxDmg;
    Play_Heath Hp;
    private Renderer enemyRenderer;

    private void Start()
    {
        Hp = GetComponent<Play_Heath>();
        enemyRenderer = GetComponent<Renderer>();
    }

    public void TakeDmg(int damage)
    {
        Hp.TakeDamge(damage);
    }

    // Player take damage when enemies touch the Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && maxDmg > 0)
        {
            playerScript = collision.GetComponent<Player>();
            InvokeRepeating("DamgeToPlayer", 0, 1f);
        }

        if (collision.CompareTag("Player's_bullet"))
        {
            StartCoroutine(ChangeColorRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript = null;
            CancelInvoke("DamageToPlayer");
        }
    }

    void DamgeToPlayer()
    {
            int damage = UnityEngine.Random.Range(minDmg, maxDmg);
            if(playerScript)
                playerScript.TakeDmg(damage);
    }

    private IEnumerator ChangeColorRoutine()
    {
        enemyRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        enemyRenderer.material.color = Color.white;
    }
}
