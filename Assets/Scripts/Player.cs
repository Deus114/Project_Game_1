using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*Parameter of Player*/

    public float moveSpeed;
    private Rigidbody2D rb;
    public Vector3 moveInput;
    public Play_Heath playerHealth;

    public Animator animator;

    public float rollBoost = 2f;
    public float RollTime = 0.25f;
    private float rollTime;
    bool Rolled = false;

    public SpriteRenderer characterSR;

    /*Parameter of Player*/
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        animator.SetFloat("Speed", moveInput.sqrMagnitude);

        // Skill Roll Dodge
        if(Input.GetKeyDown(KeyCode.Space) && rollTime <= 0)
        {
            animator.SetBool("Roll", true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            Rolled = true;
        }
        if (rollTime <= 0 && Rolled)
        {
            animator.SetBool("Roll", false);
            moveSpeed -= rollBoost;
            Rolled = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }

        // Player move controll
        if (moveInput.x != 0)
        {
            if (moveInput.x > 0)
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            else
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
        }
    }

    // Damage player take by emnemies
    public void TakeDmg(int damage)
    {
        playerHealth.TakeDamge(damage);
    }
}
