using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Movimiento y Escala")]
    public float velocidadEscala = 1f;

    [Header("Efectos Visuales C#")]
    public float velocidadPulso = 2f;
    public float intensidadPulso = 0.05f;
    public float velocidadRotacion = 15f;

    private Vector3 escalaBase;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        escalaBase = transform.localScale;
        if (escalaBase == Vector3.zero) escalaBase = Vector3.one;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- 1. EFECTO: Respiración Orgánica (Pulso) ---
        float seno = Mathf.Sin(Time.time * velocidadPulso) * intensidadPulso;
        transform.localScale = escalaBase + new Vector3(seno, seno, 0);

        // --- 2. EFECTO: Rotación Suave ---
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);

        // --- 3. EFECTO: Tono Dinámico predeterminado ---
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * 3f);
        }
    }
}