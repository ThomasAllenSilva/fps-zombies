using System.Collections.Generic;
using UnityEngine;


public class ObjectsPoolerManager : MonoBehaviour
{
    [SerializeField] private List<ObjectToPool> _objectsToPool = new List<ObjectToPool>();

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        InitializeObjectsPool();
    }

    public bool SpawnObjectFromPool(string objectID, Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        GameObject gameObject = poolDictionary[objectID].Dequeue();

        poolDictionary[objectID].Enqueue(gameObject);

        if (!gameObject.activeInHierarchy)
        {   
            gameObject.transform.SetPositionAndRotation(positionToSpawn, rotationToSpawn);

            gameObject.SetActive(true);

            return true;
        }

        return false;
    }

    private void InitializeObjectsPool()
    {
        string objectsQueueID;

        foreach (ObjectToPool objectToPool in _objectsToPool)
        {
            Queue<GameObject> objectsQueue = new Queue<GameObject>();

            objectsQueueID = objectToPool.poolTag;

            for (int j = 0; j < objectToPool.poolSize; j++)
            {
                GameObject pooledObject = Instantiate(objectToPool.objectToPool);

                pooledObject.SetActive(false);

                objectsQueue.Enqueue(pooledObject);
            }

            poolDictionary.Add(objectsQueueID, objectsQueue);
        }
    }

    [System.Serializable]
    private class ObjectToPool
    {
        public GameObject objectToPool;

        public string poolTag;

        public int poolSize;
    }
}
