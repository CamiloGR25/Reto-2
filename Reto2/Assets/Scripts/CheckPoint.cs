using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private BoxCollider2D miCollider;
    private Animator animator;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        miCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Jugador")
        {
            miCollider.enabled = false;
            audio.Play();
            animator.SetBool("Activar", true);
        }
    }
}
