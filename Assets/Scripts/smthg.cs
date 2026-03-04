using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class smthg : MonoBehaviour
{
    public List<GameObject> listaInstrucciones;
    public int currentIndex = 0;
    public List<string> mensajesInstrucciones;
    public TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {
        UpdateVisibility();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Método para actualizar visibilidad de paneles
    private void UpdateVisibility()
    {
        for (int i = 0; i < listaInstrucciones.Count; i++)
        {
            listaInstrucciones[i].SetActive(i == currentIndex); //Todos se vuelven invisibles salvo el actual
        }
    }

    //Método para cambiar entre páneles
    public void CycleObjects()
    {
        //Incrementa el índice y vuelve al principio
        currentIndex = (currentIndex+1) % (listaInstrucciones.Count);

        UpdateVisibility();
    }

    private void UpdateText()
    {
        if (mensajesInstrucciones.Count>0)
        {

        }
    }

    public void ChangeScenesbyId(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void ChangeScenesbyName(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    //Método para salir de la aplicación
    public void ExitGame()
    {
        Debug.Log("Va a salir");
        Application.Quit();

    }
}
