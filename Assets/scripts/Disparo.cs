using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D MyRB;
    GameObject playerG;
    float dir;
    void Start()
    {
        MyRB = GetComponent<Rigidbody2D>();

        playerG = GameObject.FindGameObjectWithTag("Player");
        dir = playerG.transform.localScale.x;
    }

    private void Update()
    {

        

        MyRB.velocity = new Vector2(dir * Speed * Time.deltaTime, 0);

        Destroy(this.gameObject, 2f);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(this.gameObject);
    }
}
