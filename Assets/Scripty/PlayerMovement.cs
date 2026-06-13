using UnityEngine;
using UnityEngine.InputSystem; // Na��tanie nov�ho ovl�dania

public class PlayerMovement : MonoBehaviour
{
    // Tieto premenn� uvid� v Unity a bude� si ich m�c� ladi�
    public float rychlost = 5f;
    public float silaSkoku = 7f;

    private Rigidbody2D rb;
    private float smerPohybu = 0f;

    void Start()
    {
        // Pri spusten� hry si skript s�m n�jde komponent Rigidbody2D na kocke
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            // 1. POHYB DO STR�N (��pky alebo A/D)
            smerPohybu = 0f; // Predvolene stoj�me

            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                smerPohybu = 1f; // Ide doprava
            else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                smerPohybu = -1f; // Ide do�ava
            if (smerPohybu > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (smerPohybu < 0)
            {
                transform.localScale = new Vector3(-1,1,1);
            }

            // 2. SK�KANIE (Medzern�k)
            // Podmienka kontroluje, �i hr�� stla�il medzern�k a �i kocka nepad�/nest�pa (stoj� na zemi)
            if (Keyboard.current.spaceKey.wasPressedThisFrame && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
            {
                // Vystrel�me kocku hore
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, silaSkoku);
            }
        }
    }

    void FixedUpdate()
    {
        // 3. APLIKOVANIE POHYBU (Fyzika by sa mala v�dy rie�i� vo FixedUpdate)
        rb.linearVelocity = new Vector2(smerPohybu * rychlost, rb.linearVelocity.y);
    }
}