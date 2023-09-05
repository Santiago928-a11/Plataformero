using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    private Controller movimientoJugador;
    [SerializeField] private float tiempoPerdidaControl;
    private Animator animator;

    private void Start()
    {
        movimientoJugador = GetComponent<Controller>();
        animator = GetComponent<Animator>();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
    }

    public void TomarDaño(float daño,Vector2 posicion)
    {
        vida -= daño;
        animator.SetTrigger("golpe");
        StartCoroutine(PerderControl());
        StartCoroutine(DesactivarColision());
        movimientoJugador.Rebote(posicion);
    }

    private IEnumerator DesactivarColision()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        yield return new WaitForSeconds(tiempoPerdidaControl);
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
    private IEnumerator PerderControl()
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(tiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }






}
