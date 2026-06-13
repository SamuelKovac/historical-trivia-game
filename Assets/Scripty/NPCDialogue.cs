using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections; // DOLEéIT…: Potrebujeme pre fungovanie Ko-rutÌn

public class NPCDialogue : MonoBehaviour
{
    private enum StavDialogu { Skryty, Sekvencia, Otazka, Koniec }
    private StavDialogu aktualnyStav = StavDialogu.Skryty;
    public GameObject Collectible;

    [Header("Filmov· sekvencia textov")]
    [TextArea(2, 5)] public string textUvod;       // "Ahoj cestovateæ..."
    [TextArea(2, 5)] public string textPrechod;    // "PoloûÌm ti p·r ot·zok..."
    [Range(1f, 5f)] public float casZobrazeniaTextu = 3.5f; // Koæko sek˙nd text svieti

    [Header("KvÌzov· ot·zka")]
    [TextArea(2, 5)] public string textOtazky;
    public string odpovedA;
    public string odpovedB;
    [Tooltip("1 = OdpoveÔ A, 2 = OdpoveÔ B")]
    public int indexSpravnejOdpovede = 1;

    [Header("UI Referencie")]
    public GameObject panelDialogu;
    public TextMeshProUGUI uiText;
    public GameObject tlacidloA;
    public GameObject tlacidloB;

    private bool hracJeBlizko = false;
    private Coroutine laufiacaSekvencia; // UloûÌme si beûiacu sekvenciu

    void Start()
    {
        panelDialogu.SetActive(false);
        tlacidloA.SetActive(false);
        tlacidloB.SetActive(false);
    }

    void Update()
    {
        if (!hracJeBlizko) return;

        // Reagujeme na E iba ak je dialÛg skryt˝ (na spustenie) alebo na konci (na zatvorenie)
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (aktualnyStav == StavDialogu.Skryty)
            {
                // SpustÌme automatick˙ sekvenciu
                laufiacaSekvencia = StartCoroutine(AutomatickyDialog());
            }
            else if (aktualnyStav == StavDialogu.Koniec)
            {
                ZatvorDialog();
            }
        }
    }

    // T¡TO FUNKCIA RIADI CEL› AUTOMATICK› DEJ
    IEnumerator AutomatickyDialog()
    {
        aktualnyStav = StavDialogu.Sekvencia;
        panelDialogu.SetActive(true);
        Time.timeScale = 0f; // ZastavÌme Ëas v hre

        // 1. Uk·ûeme ˙vodn˝ text a poËk·me
        uiText.text = textUvod;
        yield return new WaitForSecondsRealtime(casZobrazeniaTextu);

        // 2. Text sa s·m zmenÌ na prechodov˝ text a znova poËk·me
        uiText.text = textPrechod;
        yield return new WaitForSecondsRealtime(casZobrazeniaTextu);

        // 3. Vz·p‰tÌ hneÔ skoËÌ ot·zka a zapn˙ se tlaËidl·
        aktualnyStav = StavDialogu.Otazka;
        uiText.text = textOtazky;

        tlacidloA.SetActive(true);
        tlacidloB.SetActive(true);
        tlacidloA.GetComponentInChildren<TextMeshProUGUI>().text = odpovedA;
        tlacidloB.GetComponentInChildren<TextMeshProUGUI>().text = odpovedB;
    }

    public void SkontrolujOdpoved(int indexKliknutehoTlacidla)
    {
        if (aktualnyStav != StavDialogu.Otazka) return;

        if (indexKliknutehoTlacidla == indexSpravnejOdpovede)
        {
            uiText.text = "Excelentne! Tvoja vedomosù je hodn· reöpektu. ZÌskavaö kæ˙Ë Ankh.\n\n(StlaË E pre pokraËovanie)";
            Collectible.SetActive(true);
        }
        else
        {
            uiText.text = "Bohovia s tebou nes˙hlasia, to nie je spr·vne. Sk˙s to znova pri Ôalöom stretnutÌ.\n\n(StlaË E pre odchod)";
        }

        tlacidloA.SetActive(false);
        tlacidloB.SetActive(false);
        aktualnyStav = StavDialogu.Koniec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
            hracJeBlizko = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hracJeBlizko = false;
            ZatvorDialog();
        }
    }

    void ZatvorDialog()
    {
        // Ak hr·Ë odÌde predËasne, stopneme aj beûiacu ko-rutÌnu
        if (laufiacaSekvencia != null) StopCoroutine(laufiacaSekvencia);

        panelDialogu.SetActive(false);
        tlacidloA.SetActive(false);
        tlacidloB.SetActive(false);
        aktualnyStav = StavDialogu.Skryty;
        Time.timeScale = 1f;
    }
}