using UnityEngine;
using UnityEngine.InputSystem;

public class EarthInteract : MonoBehaviour
{
    [Header("Nastavenia rotácie")]
    // Rıchlos som trochu zníil, lebo novı systém vracia väèšie èísla (presné pixely posunu)
    public float rotationSpeed = 0.2f;

    void Update()
    {
        // Bezpeènostná kontrola, èi je myš vôbec pripojená/dostupná
        if (Mouse.current == null) return;

        // Kontrola, èi hráè drí stlaèené ¾avé tlaèidlo myši
        if (Mouse.current.leftButton.isPressed)
        {
            // Získanie smeru a rıchlosti pohybu myši (tzv. delta)
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            float rotX = mouseDelta.x * rotationSpeed;
            float rotY = mouseDelta.y * rotationSpeed;

            // Novı, opravenı kód (obe osi sa odvíjajú od kamery):
            transform.Rotate(Camera.main.transform.up, -rotX, Space.World);
            transform.Rotate(Camera.main.transform.right, -rotY, Space.World);
        }
    }
}