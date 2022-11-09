using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover3dBtn2 : MonoBehaviour
{
    // Script para activar o desactivar la animacion de subir y bajar boton
    GameObject BtnControllerUp;
    GameObject BtnControllerDown;

    private void Start()
    {
        // Asignamos el gameobject directamente en codigo ya que en la funcion el UIElementXR -> OnPointerEnter/Exit,
        // no nos deja hacer la arrastracion
        BtnControllerUp = GameObject.Find("UI3DControllerUp2");
        BtnControllerUp.SetActive(false);
        //los seteamos a false desde codigo para que esten activos un un tick y alcancen a guardar la posicion original del boton
        BtnControllerDown = GameObject.Find("UI3DControllerDown2");
        BtnControllerDown.SetActive(false);
    }

    public void UpAnimation()
    {
        // Nos aseguramos de desactivar uno y luego activar el otro sino no sirve,
        // es como pisar el acelerador y el freno al mismo tiempo xd
        BtnControllerDown.SetActive(false);
        BtnControllerUp.SetActive(true);
    }

    public void DownAnimation()
    {
        BtnControllerUp.SetActive(false);
        BtnControllerDown.SetActive(true);

    }

}
