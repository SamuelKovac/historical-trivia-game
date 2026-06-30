using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HracZberac totalScore = collision.GetComponent<HracZberac>();
        if (totalScore != null )
        {
            if (totalScore.currentScrollNumber == 4)
            {
                SceneManager.LoadScene("EgyptLevel");
            }
        }
    }
}
