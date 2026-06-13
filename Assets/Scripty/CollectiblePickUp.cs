using UnityEditor;
using UnityEngine;
using TMPro;

public class CollectiblePickUp : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiText.gameObject.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject);
        }
    }
}
