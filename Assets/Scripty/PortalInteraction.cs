using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalInteraction : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (ZvitokInteraction.aktualnyPocet == 4)
            {
                SceneManager.LoadScene("EgyptLevel");
            }
            else
            {
                Debug.Log("Ešte si nezískal všetky požadované zvitky!");
            }
        }
    }
}
