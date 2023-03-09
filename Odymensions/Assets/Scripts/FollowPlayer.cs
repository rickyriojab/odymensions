using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void Update()
    {
        // La camara seguira al jugador en x mientra que se mantendra en 0 en y,z (jugador, 0, 0), si se quiere el personaje mas a la izquierda de la pantalla sumar a la X
        transform.position = new Vector3(playerTransform.position.x + 2, transform.position.y, transform.position.z);
    }
}