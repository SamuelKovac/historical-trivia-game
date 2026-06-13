using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class CleopatraDialogue : MonoBehaviour
{
    public GameObject panelDialogu;
    public TextMeshProUGUI textDialogu;
    public bool isPlayerClose;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerClose = false;
            panelDialogu.SetActive(false);
        }
    }

    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && isPlayerClose == true)
        {
            panelDialogu.SetActive(true);
            textDialogu.text = "Zdravím a, cestovate¾. Ja som krá¾ovná Cleopatra. Moje krá¾ovstvo zasiahla piesoèná búrka a rozfúkala vzácne papyrusy z Alexandrijskej kninice po nebezpeènıch útesoch. Ak chceš získa k¾úè Ankh od Tutanchamóna, prines mi 3 stratené zvitky! Vstúp do portálu, keï budeš pripravenı.";
        }
    }

    public void VstupDoPlosinovky()
    {
        SceneManager.LoadScene("EgyptPlosinovka");
    }
}

