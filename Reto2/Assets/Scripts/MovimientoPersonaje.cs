using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;
    public Transform[] checkPoints;
    private int numCheckPoint=0;
    private bool enElsuelo = false;
   
    private Rigidbody2D cuerpoRigido;
    private Animator animaciones;

    private int puntos=0;
    public Text textoPuntos;
    private int muertes=0;
    public Text textoMuertes;

    private AudioSource audio;
    public AudioClip audioMuerte;
    
    
    void Awake()
    {
        cuerpoRigido = GetComponent<Rigidbody2D>();
        animaciones = GetComponent<Animator>();
        audio=GetComponent<AudioSource>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        cuerpoRigido.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, cuerpoRigido.velocity.y);

        if (Input.GetButtonDown("Jump") && enElsuelo)
        {
            cuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            enElsuelo = false;
            audio.Play();   
        }

        if (movimientoHorizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoHorizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        animaciones.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));
        
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo");

        if (collision.gameObject.CompareTag("Morir")){
            Reinicio();
        }else if (collision.gameObject.CompareTag("Golpe")){
            Reinicio();
        }    
        
    }

    void Reinicio()
    {   
        audio.PlayOneShot(audioMuerte); 
        cuerpoRigido.velocity = Vector2.zero; //velocidad en cero
        cuerpoRigido.angularVelocity = 0;
        cuerpoRigido.bodyType = RigidbodyType2D.Static; //ponerlo quieto para moverlo
    
        transform.position = checkPoints[numCheckPoint].position; //el punto al que se reinicia

        muertes++;
        textoMuertes.text="Muertes: "+muertes;

        cuerpoRigido.bodyType = RigidbodyType2D.Dynamic; // ponerlo dinamico para que se pueda manejar e interactuar
        enElsuelo = true;
    }

    private void OnTriggerEnter2D(Collider2D colision) {
        if(colision.gameObject.tag=="Fruta"){
            puntos++;
            textoPuntos.text="Puntuación: "+puntos;
        }
        if(colision.gameObject.tag=="FrutaGrande"){
            puntos+=10;
            textoPuntos.text="Puntuacón: "+puntos;
        }
         if(colision.gameObject.CompareTag("CheckPoint")){
            Debug.Log("+1");
            numCheckPoint++;
        }
    }
}

