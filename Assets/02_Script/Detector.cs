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

    public GameObject PanelGameOver;

    public int Vida = 20;

    // Las imágenes que se mostrarán para cada objeto detectado
    public Sprite ImgAlimentoSaludable1;
    public Sprite ImgAlimentoNOSaludable1;

    void Start()
    {
        if (arCamera == null)
        {
            arCamera = Camera.main;
        }
        OcultarPanel();
        
    }

    void Update()
    {
        if (Vida <= 0)
        {
            MostrarPanelGameOver();
            return; // Detener ejecución para evitar más interacciones
        }

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
                    Vida++;


                }
                else if (tag == "NoSaludable")
                {
                    MostrarPanelSinPrefab("Alimento No Saludable", "Este alimento es malo par tu salud", ImgAlimentoNOSaludable1);
                    Vida--;
                    if (Vida < 0)
                    {
                        
                    }
                }
                else
                {
                    OcultarPanel();
                   
                }
            }
            else
            {
                OcultarPanel();
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
    void MostrarPanelGameOver()
    {
        if (PanelGameOver != null)
        {
            PanelGameOver.SetActive(true);
        }
    }
}
