using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARInitializer : MonoBehaviour
{
    void Start()
    {
        // Fuerza la activación de la sesión AR al iniciar la app
        var session = FindObjectOfType<ARSession>();
        if (session != null)
        {
            session.enabled = false;
            session.enabled = true;
        }
    }
}