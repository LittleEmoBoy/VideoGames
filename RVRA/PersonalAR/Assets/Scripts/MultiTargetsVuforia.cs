using UnityEngine;

public class MultiTargetsVuforia : MonoBehaviour
{
    [SerializeField] private GameObject startModel; // Referencia al modelo que se mostrará al inicio
    private int modelsCount; // Cantidad de modelos del ImageTarget 
    private int indexCurrentModel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created 
    void Start()
    {
        modelsCount = transform.childCount; // Contamos los modelos 
        indexCurrentModel = startModel.transform.GetSiblingIndex(); // Posición del modelo con el que se inicia
    }

    // Función que cambia de modelo en el Image Target  
    // +1 para el modelo siguiente 
    // -1 para el modelo anterior 
    public void ChangeARModel(int index)
    {
        // Desactivar modelo que se está mostrando 
        transform.GetChild(indexCurrentModel).gameObject.SetActive(false);

        // Índice del nuevo modelo que se mostrará 
        int newIndex = indexCurrentModel + index;

        if (newIndex < 0) // Al llegar a la posición del modelo 0, pasamos al último modelo 
        {
            newIndex = modelsCount - 1;
        }
        else if (newIndex > modelsCount - 1) // Al llegar a la posición del último modelo se pasa al primer modelo
        {
            newIndex = 0;
        }

        // Activar el nuevo modelo 
        GameObject newModel = transform.GetChild(newIndex).gameObject;
        newModel.SetActive(true);

        // Actualizar la posición del modelo que se está mostrando 
        indexCurrentModel = newModel.transform.GetSiblingIndex();
    }
}