using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image hpBar;
    float hp = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boom"))
        {
           // Destroy(other.gameObject);
            hp -= 0.35f;
            hpBar.fillAmount = hp;
            if(hp <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
