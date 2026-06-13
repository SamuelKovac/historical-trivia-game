using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PinClick : MonoBehaviour
{
    void Start()
    {
        Debug.Log("PinClick START - skript beží!");
    }

    void Update()
    {
        if (Mouse.current == null) return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            // Pouzi kameru ktora je child Zemegule
            Camera gameCam = GameObject.Find("Camera").GetComponent<Camera>();
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Ray ray = gameCam.ScreenPointToRay(mousePos);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Debug.Log("Trafil: " + hit.collider.gameObject.name);
                if (hit.collider.CompareTag("Pin"))
                {
                    SceneManager.LoadScene("EgyptLevel");
                }
            }
            else
            {
                Debug.Log("Netrafil niè");
            }
        }
    }
}