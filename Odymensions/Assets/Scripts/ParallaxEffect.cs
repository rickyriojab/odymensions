using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 previousCameraPosition;
    [SerializeField] private float parallaxMultiplier;
    private float spriteWidth;
    private float startPosition;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        previousCameraPosition = cameraTransform.position;
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        startPosition = transform.position.x;
    }

    void LateUpdate()
    {
        // Mientras mas cercano a 1 se mueve junto con la camara, mientras mas chico el numero mas lento sera el movimiento
        float x = (cameraTransform.position.x - previousCameraPosition.x) * parallaxMultiplier;
        // Cuanto avanza la camara respecto a la capa
        float moveAmount = cameraTransform.position.x * (1-parallaxMultiplier);
        transform.Translate(new Vector3(x, 0, 0));
        previousCameraPosition = cameraTransform.position;

        // Si la camara esta mas adelante que el sprite, se reposiciona la capa
        if(moveAmount > startPosition + spriteWidth)
        {
            transform.Translate(new Vector3(spriteWidth, 0, 0));
            startPosition += spriteWidth;
        }// Si la camara esta mas atras que el sprite, se reposiciona la capa
        else if(moveAmount < startPosition - spriteWidth)
        {
            transform.Translate(new Vector3(-spriteWidth, 0, 0));
            startPosition -= spriteWidth;
        }
    }
}
