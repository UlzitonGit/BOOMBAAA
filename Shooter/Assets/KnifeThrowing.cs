using System.Collections;
using UnityEngine;

public class KnifeThrowing : MonoBehaviour
{
    [SerializeField] GameObject knife;
    [SerializeField] Transform spp;
    [SerializeField] Animator anim;
   
    bool canThrow = true;
    int attackNum = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canThrow && Input.GetKey(KeyCode.Mouse0))
        {
            StartCoroutine(Throwing());
        }
    }
    IEnumerator Throwing()
    {
        canThrow = false;
        attackNum = attackNum * -1;
        anim.SetInteger("Attack", attackNum);
        yield return new WaitForSeconds(0.4f);
        anim.SetInteger("Attack", 0);
        yield return new WaitForSeconds(0.1f);
        canThrow = true;
    }
    public void Throw()
    {
        Instantiate(knife, spp.position, spp.rotation);
    }
}
