using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform[] spp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        Instantiate(enemy, spp[Random.Range(0, spp.Length)]);
        yield return new WaitForSeconds(Random.Range(1, 2));
        StartCoroutine(Spawning());
    }
}
