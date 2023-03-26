using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float currentHealthAmount;
    [SerializeField] private float maxHealthAmount;

    private void Start()
    {
        currentHealthAmount = maxHealthAmount;
    }
    public void TakeDamage(float amount)
    {
        currentHealthAmount -= amount;
        Debug.Log(currentHealthAmount);

        if (currentHealthAmount <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealthAmount += amount;
        
    }

    public void Die()
    {
        //animator.SetTrigger("Die");
        Destroy(this.gameObject);
    }
}
