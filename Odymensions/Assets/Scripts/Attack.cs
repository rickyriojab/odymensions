using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private Transform punchOrigin;
    [SerializeField] private float punchRadius;
    [SerializeField] private float punchDamage;
    [SerializeField] private float punchTime;
    private float punchCooldown = 0f;
    private bool isPunching = false;
    public Animator animator;


    public void ClickPunch()
    {
        isPunching = true;
    }

    private void Update()
    {
        if(punchCooldown > 0) punchCooldown -= Time.deltaTime;

        if (isPunching && punchCooldown <= 0)
        {
            isPunching = false;
            Punch();

            punchCooldown = punchTime;
        }
    }

    private void Punch()
    {
        animator.SetTrigger("Punch");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(punchOrigin.position, punchRadius);
        foreach(Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.transform.GetComponent<EnemyHealth>().TakeDamage(punchDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(punchOrigin.position, punchRadius);
    }
}
