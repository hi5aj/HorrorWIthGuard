using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //public GameObject Hatchet;
    public bool CanAttack = true;
    public float AttackCooldown= 1.0f;
    public AudioClip hatchetAttackSound;
    Animator anim;
    AudioSource ac;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        ac = GetComponent<AudioSource>();
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
        else if (Input.GetMouseButtonUp(0))
        {
        }
    }
    
    public void HatchetAttack()
    {
        CanAttack = false;
        anim.SetBool("isAttacking", true);
        //ac.PlayOneShot(hatchetAttackSound);
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        anim.SetBool("isAttacking", false);
        CanAttack = true;
    }
}

