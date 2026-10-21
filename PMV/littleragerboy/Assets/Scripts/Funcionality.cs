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
    private int lifes;
    public enum Difficulty { easy, medium, hard };

    [SerializeField] private Difficulty difficulty;

    void start()
    {
        Debug.Log("Health: " + lifes);
        difficulty = Difficulty.medium;
    }

    public void Awake()
    {
        switch (difficulty)
        {
            case Difficulty.easy:
                lifes = 20;
                break;
            case Difficulty.medium:
                lifes = 10;
                break;
            case Difficulty.hard:
                lifes = 5;
                break;
            default:
                lifes = 10;
                break;
        }
    }

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
