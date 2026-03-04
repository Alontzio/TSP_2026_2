using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public class UISelection : MonoBehaviour
{
    public static bool gazedAt;
    [SerializeField]
    public float fillTime = 5f;
    public Image radialImage;
    public UnityEvent onFillComplete; //Evento genérico de Unity

    //Ptroceso asícrono
    private Coroutine fillCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gazedAt = false;
        radialImage.fillAmount = 0;

    }

    public void OnPointerEnter()
    {
        gazedAt =  true;

        if (fillCoroutine != null)
        {
             StopCoroutine(fillCoroutine); //Detiene el llenado
        }
        fillCoroutine = StartCoroutine(FillRadial());
    }

    public void OnPointerExit()
    {
        gazedAt = false;

        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine); //Detiene el llenado
            fillCoroutine = null;
        }
        radialImage.fillAmount = 0f;
    }

    private IEnumerator FillRadial()
    {
        float elapasedTime = 0f;
        while (elapasedTime < fillTime )
        {
            if (!gazedAt)
            {
                yield break;
            }

            elapasedTime+=Time.deltaTime;
            radialImage.fillAmount = Mathf.Clamp01(elapasedTime / fillTime);

            yield return null;
        }

        //El evento a ejecutar
        onFillComplete?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
