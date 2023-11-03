using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Varibles to control bullet and effect
    public GameObject bullet;
    public Transform FirePos;
    public float TimeBwFire = 0.2f;
    public float BulletForce;
    //public GameObject fireEffect;
    public GameObject muzzle;

    private float timeBWFire;
    void Update()
    {
        RotateGun();
        // Shoot when click left Mouse
        timeBWFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && timeBWFire < 0)
        {
            FireShot();
        }
    }

    // Rotate the Gun by Muose
    void RotateGun() 
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePosition - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
            transform.localScale = new Vector3(1, -1, 0);
        else
            transform.localScale = new Vector3(1, 1, 0);
    }

    private void FireShot()
    {
        timeBWFire = TimeBwFire;
        // Bullet out
        GameObject bulletTmp = Instantiate(bullet, FirePos.position, Quaternion.identity);
        // Effect
        Instantiate(muzzle, FirePos.position, transform.rotation, transform);
        //Instantiate(fireEffect, FirePos.position, transform.rotation, transform);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * BulletForce, ForceMode2D.Impulse);
    }
}
