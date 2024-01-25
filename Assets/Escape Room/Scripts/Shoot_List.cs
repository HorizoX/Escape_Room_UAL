using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_List : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToDestroyInOrder;
    private int currentIndex = 0;

    void Start()
    {
        // Ensure all objects in the list are initially inactive
        DeactivateAllObjects();
    }
    void Update()
    {
        // Check if the current required object is destroyed
        if (currentIndex < objectsToDestroyInOrder.Count && objectsToDestroyInOrder[currentIndex] == null)
        {
            // Move to the next object in the list
            currentIndex++;

            // Check if all objects are destroyed
            if (currentIndex == objectsToDestroyInOrder.Count)
            {
                Debug.Log("Level completed!");
                // Add your level completion logic here
            }
        }
    }
    void DeactivateAllObjects()
    {
        foreach (GameObject obj in objectsToDestroyInOrder)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }
    }
}
