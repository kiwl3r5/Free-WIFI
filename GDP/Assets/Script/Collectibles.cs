using Script.Manager;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //public GameManager gm;

    private void Start()
    {
        //gm = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        GameManager.Instance.collectible++;
        GameManager.Instance.total++;
        GameManager.Instance.collectedBarUI.fillAmount = GameManager.Instance.sumCollected / GameManager.Instance.total;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //FindObjectOfType<AudioManager>().Play("Collected");
            Destroy(gameObject);
            GameManager.Instance.sumCollected++;
            GameManager.Instance.collectible--;
            GameManager.Instance.collectedBarUI.fillAmount = GameManager.Instance.sumCollected / GameManager.Instance.total;
        }
    }
}
