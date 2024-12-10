using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    FirstPersonController player;
    NavMeshAgent agent;
    [SerializeField] GameObject boom;
    AudioSource _AudioSource;
    [SerializeField] AudioClip expSFX;
    bool booms = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _AudioSource = GameObject.Find("Sound").GetComponent<AudioSource>();
        player = FindAnyObjectByType<FirstPersonController>();
        agent = GetComponent<NavMeshAgent>();
       
       
    }
    private void Update()
    {
        agent.SetDestination(player.transform.position);
        if (Vector3.Distance(transform.position, player.transform.position) < 2.5f && booms == false)
        {
            _AudioSource.PlayOneShot(expSFX);
            booms = true;
            Instantiate(boom, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boom"))
        {
            Destroy(gameObject);
        }
    }

}
