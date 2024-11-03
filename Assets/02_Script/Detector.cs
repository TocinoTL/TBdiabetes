using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Detector : MonoBehaviour
{
    public Camera arCamera;
    public GameObject panel;
    public TextMeshProUGUI Titulo; 
    public TextMeshProUGUI Informacion;
    public Image Imagen;

    // Las imágenes que se mostrarán para cada objeto detectado
    public Sprite ImgAlimentoSaludable1;
    public Sprite ImgAlimentoNOSaludable1;

    // Los prefabs que ya están en la escena
    public GameObject AnimAlimentoSaludable1;
    public GameObject AnimAlimentoNOSaludable1;

    void Start()
    {
        if (arCamera == null)
        {
            arCamera = Camera.main;
        }
        OcultarPanel();
        OcultarTodosPrefabs();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                string tag = hit.transform.tag;
                

                if (tag == "Saludable")
                {
                    MostrarPanelSinPrefab("Alimento Saludable", "Este alimento es bueno para la diabetes", ImgAlimentoSaludable1);
                    MostrarPrefab(AnimAlimentoSaludable1);
                }
                else if (tag == "NoSaludable")
                {
                    MostrarPanelSinPrefab("Alimento No Saludable", "Este alimento es malo par tu salud", ImgAlimentoNOSaludable1);
                    MostrarPrefab(AnimAlimentoNOSaludable1);
                }
                else
                {
                    OcultarPanel();
                    OcultarTodosPrefabs();
                }
            }
            else
            {
                OcultarPanel();
                OcultarTodosPrefabs();
            }
        }
        
    }
  
    void MostrarPanelSinPrefab(string titulo, string informacion, Sprite imagen)
    {
        if (panel != null)
        {
            panel.SetActive(true);
            Titulo.text = titulo;
            Informacion.text = informacion;
            Imagen.sprite = imagen;
        }
    }

    void OcultarPanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
    void MostrarPrefab(GameObject prefab)
    {
        if (prefab != null)
        {
            prefab.SetActive(true); // Muestra el prefab
        }
    }

    void OcultarTodosPrefabs()
    {
        // Oculta todos los prefabs. Asegúrate de agregar aquí todos los prefabs que desees ocultar.
        if (AnimAlimentoSaludable1 != null) AnimAlimentoSaludable1.SetActive(false);
        if (AnimAlimentoNOSaludable1 != null) AnimAlimentoNOSaludable1.SetActive(false);
    }
}
