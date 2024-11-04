using TMPro;
using Unity.VisualScripting;
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

    public float vida;
    public float maxvida;
    public Image vidabarra;



    // Las imágenes que se mostrarán para cada objeto detectado
    public Sprite ImgAlimentoSaludable1;
    public Sprite ImgAlimentoNOSaludable1;

    void Start()
    {
        vidabarra.fillAmount = vida / maxvida;
        if (arCamera == null)
        {
            arCamera = Camera.main;
        }
        OcultarPanel();
        
    }

    void Update()
    {
      
        if (vida <= 0)
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
                    IncreaseHealth();


                }
                else if (tag == "NoSaludable")
                {
                    MostrarPanelSinPrefab("Alimento No Saludable", "Este alimento es malo par tu salud", ImgAlimentoNOSaludable1);
                    ReduceHealth();


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

        // bajar la vida con logica 
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReduceHealth(); //reduce vida 
        }
        // Detecta si se presiona la tecla "J" para aumentar la vida
        if (Input.GetKeyDown(KeyCode.J))
        {
            IncreaseHealth(); // aumenta vida 
        }

    }
    void ReduceHealth()
    {
        vida -= 5; // Resta 5 puntos de vida
        vidabarra.fillAmount = vida / maxvida; // Actualiza la barra de vida

        Debug.Log("Vida actual: " + vida);

        // Verifica si la vida llega a cero
        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto.");
            // Aquí podrías agregar lógica adicional, como desactivar al jugador o iniciar una animación de muerte
        }
    }
    void IncreaseHealth()
    {
        // Aumenta la vida, asegurando que no supere el máximo
        vida += 5;
        if (vida > maxvida)
        {
            vida = maxvida;
        }

        // Actualiza la barra de vida
        vidabarra.fillAmount = vida / maxvida;

        Debug.Log("Vida actual: " + vida);
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
