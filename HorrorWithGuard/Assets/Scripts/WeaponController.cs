using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Hatchet;
    public bool CanAttack = true;
    public float AttackCooldown= 1.0f;
    public AudioClip hatchetAttackSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(CanAttack)
            {
                HatchetAttack();
            }
        }
    }
    
    public void HatchetAttack()
    {
        CanAttack = false;
        Animator anim = Hatchet.GetCompontent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetCompontent<AudioSource>();
        ac.PlayOneShot(hatchetAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
    }
}

