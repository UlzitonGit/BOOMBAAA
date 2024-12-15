using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    [SerializeField] GameObject boom;
    AudioSource _AudioSource;
    [SerializeField] AudioClip throwSFX;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip explode;
    BoxCollider box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _AudioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
        _AudioSource.PlayOneShot(throwSFX);
        box = GetComponent<BoxCollider>();
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            _AudioSource.PlayOneShot(hitSFX);
            dir = dir * 0;
            box.enabled = false;
        }
        if (other.CompareTag("Bomba"))
        {
            _AudioSource.PlayOneShot(explode);
            Instantiate(boom, other.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
