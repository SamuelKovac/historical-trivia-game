using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZvitokInteraction : MonoBehaviour 
{
    public static int aktualnyPocet;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            aktualnyPocet++;
            Destroy(gameObject);
        }
    }
}
