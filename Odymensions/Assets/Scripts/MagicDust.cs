using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicDust : MonoBehaviour
{
    public int value = 1;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddPoints(value);
            Destroy(this.gameObject);
        }
    }
}

