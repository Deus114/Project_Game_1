using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Play_Heath : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] GameObject GameOver;
    public int currentHealth;

    public Fill_Bar health_bar;

    public UnityEvent OnDeath;

    public bool Enemies;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }
    public void TakeDamge(int damge)
    {
        currentHealth -= damge;
        if(currentHealth <= 0 )
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        if(!Enemies)
            health_bar.UpdateBar(currentHealth, maxHealth);
    }

    public void Death()
    {
        if (Enemies)
            FindObjectOfType<Add_Scores>().AddScore();
        else
        {
            GameOver.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0;
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        currentHealth = maxHealth;
        if (health_bar)
            health_bar.UpdateBar(currentHealth, maxHealth);
    }
}
