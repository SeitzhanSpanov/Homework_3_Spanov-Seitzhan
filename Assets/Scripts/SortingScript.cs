using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingScript : MonoBehaviour
{
    public GameObject prefab; 
    public int numberOfObjects = 10; 
    public float distanceBetweenObjects = 2.0f; 

    private List<GameObject> objectsList = new List<GameObject>();

    void Start()
    {
        CreateObjects();
        StartCoroutine(SelectionSort());
    }

    void CreateObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            
            GameObject obj = Instantiate(prefab, new Vector3(i * distanceBetweenObjects, Random.Range(1f, 5f), 0), Quaternion.identity);
            obj.transform.localScale = new Vector3(Random.Range(1f, 3f), Random.Range(1f, 3f), Random.Range(1f, 3f));
            obj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);

            objectsList.Add(obj);
        }
    }

    IEnumerator SelectionSort()
    {
        int n = objectsList.Count;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
              
                if (objectsList[j].transform.position.y < objectsList[minIndex].transform.position.y)
                {
                    minIndex = j;
                }
            }

            
            GameObject temp = objectsList[minIndex];
            objectsList[minIndex] = objectsList[i];
            objectsList[i] = temp;

            yield return new WaitForSeconds(0.5f); 
        }

        VisualizeSortedArray();
    }

    void VisualizeSortedArray()
    {
        
        for (int i = 0; i < objectsList.Count; i++)
        {
            objectsList[i].transform.position = new Vector3(i * distanceBetweenObjects, objectsList[i].transform.position.y, 0);
        }
    }
}
