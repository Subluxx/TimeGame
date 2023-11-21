using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class PlayerAttack : MonoBehaviour
{
    private float attackDelay;
    public float startAttackTime;

    public Transform attackPos;
    public LayerMask attackTarget;
    public float attackRange;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackDelay <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                //camAnim.setTrigger("shake");
                

                Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPos.position, attackRange, attackTarget);
                for (int i = 0; i < enemiesHit.Length; i++)
                {
                    enemiesHit[i].GetComponent<BossController>().TakeDamage(damage);
                }
                
            }
            attackDelay = startAttackTime;
        }
        else
        {
            attackDelay -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
