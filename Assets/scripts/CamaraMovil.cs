using UnityEngine;
using UnityEngine.UI;

public class SimpleCameraView : MonoBehaviour
{
    public RawImage background; // Arrastra aquí un componente RawImage de tu UI
    private WebCamTexture camTexture;

    void Start()
    {
        // Solicitar permisos de cámara en Android de forma explícita
        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Application.RequestUserAuthorization(UserAuthorization.WebCam);
        }

        // Iniciar la cámara trasera del dispositivo
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            // Selecciona la primera cámara (generalmente la trasera)
            camTexture = new WebCamTexture(devices[0].name, Screen.width, Screen.height, 30);
            background.texture = camTexture;
            camTexture.Play();
        }
        else
        {
            Debug.LogError("No se encontró ninguna cámara disponible.");
        }
    }
}