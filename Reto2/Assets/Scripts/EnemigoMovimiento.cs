using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour{
    public float velicidadMovimiento;
    public Transform[] puntosMovimiento;
    public float distanciaMinima;
    private int siguientePaso=0;
    private SpriteRenderer spriteRenderer;

    private void Start(){
        
        spriteRenderer=GetComponent<SpriteRenderer>();
        Girar();
    }

    private void Update(){
        transform.position=Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePaso].position, velicidadMovimiento*Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosMovimiento[siguientePaso].position)< distanciaMinima){
            siguientePaso+=1;
           // Debug.Log("añadoio +1");
            if(siguientePaso>=puntosMovimiento.Length){
                siguientePaso=0;
             //   Debug.Log("Reseteo a 0");
            }
            Girar();
        }
    }

    private void Girar(){
        if (transform.position.x< puntosMovimiento[siguientePaso].position.x){
            spriteRenderer.flipX=true;
        }else{
            spriteRenderer.flipX=false;
        }

    }
}
