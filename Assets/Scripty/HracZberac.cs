using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HracZberac : MonoBehaviour
{
    public int currentScrollNumber = 0;
    public TextMeshProUGUI uiText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Zvitok"))
        {
            currentScrollNumber++;
            Destroy(collision.gameObject);
            uiText.text = "Zvitky:" + currentScrollNumber + " / 4 ";
        }
    }
}
