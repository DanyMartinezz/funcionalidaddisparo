using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaman : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float velocidadsalto;
    [SerializeField] BoxCollider2D misPies;
    public Transform FirePoint;
    public GameObject Bala;


    Animator Myanimator;
    Rigidbody2D MyBody;
    BoxCollider2D MyCollider;
    float FireRate = 0;
    float FireTime = 0;
    bool disparando = false;

    void Start()
    {
        Myanimator = GetComponent<Animator>();
        MyBody = GetComponent<Rigidbody2D>();
        MyCollider = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Runing();
        Jumping();
        Falling();
        Disparar();
        Disparador();

   

    }

    void Disparar()
    {
        if (!disparando)
        {
            if (Input.GetKey(KeyCode.X))
            {
                disparando = true;
                Myanimator.SetLayerWeight(1, 1);
                StartCoroutine(PausaDisparo());
            }
        }

    }

    IEnumerator PausaDisparo()
    {
        yield return new WaitForSeconds(1f);
        disparando = false;
        Myanimator.SetLayerWeight(1, 0);
    }

    void Disparador()
    {

        if (Input.GetKeyDown(KeyCode.X) && Time.time >= FireTime)
        {
            Instantiate(Bala, FirePoint.position, Quaternion.identity);
            FireTime = Time.time + FireRate;
        }
    }
    void Falling()
    {
        if (MyBody.velocity.y < 0)
        {
            Myanimator.SetBool("Caer", true);
        }
    }


    void Jumping()
    {
        if (EnSuelo())
        {
            Myanimator.SetBool("Caer", false);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Salto");
                MyBody.AddForce(new Vector2(1, 300));
                Myanimator.SetTrigger("Saltar");
            }
        }


    }
    bool EnSuelo()
    {
        bool estaTocando = misPies.IsTouchingLayers(LayerMask.GetMask("Ground"));

        return estaTocando;
    }
    void Runing()
    {
        float mov = Input.GetAxis("Horizontal");

        transform.Translate(new Vector2(mov * Time.deltaTime * speed, 0));

        if (mov != 0)

        {
            Myanimator.SetBool("estar corriendo", true);
            if (mov < 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }


        }

        else
        {
            Myanimator.SetBool("estar corriendo", false);

        }
    }
}
