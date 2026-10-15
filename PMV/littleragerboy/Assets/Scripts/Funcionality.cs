//using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class Funcionality : MonoBehaviour, IPointerDownHandler
{

    /*public int health=100;
    public float speed=5.0f;
    private bool finJuego= false;
    string playerName="Player1";
    */
    public int lifes;


    public void OnPointerDown(PointerEventData eventData)
    {
        lifes--;

        if (lifes <=0)
        {
            Debug.Log("Cohete destruido");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Cohete clickeado| Lifes restantes: " + lifes);
        }
    }

}
