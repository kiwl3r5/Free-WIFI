using Script.Manager;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    //public GameManager gm;
    public GameObject pickupWifi;

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
            Instantiate(pickupWifi, transform.position, transform.rotation);
            AudioManager.Instance.Play("Wifi");
            Destroy(gameObject);
            GameManager.Instance.sumCollected++;
            GameManager.Instance.collectible--;
            GameManager.Instance.collectedBarUI.fillAmount = GameManager.Instance.sumCollected / GameManager.Instance.total;
        }
    }
}
