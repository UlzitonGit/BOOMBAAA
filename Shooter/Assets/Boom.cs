using System.Collections;
using UnityEngine;

public class Boom : MonoBehaviour
{
    CapsuleCollider capsuleCollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.3f);
        capsuleCollider.enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
