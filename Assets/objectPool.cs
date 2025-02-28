using UnityEngine;
using System.Collections.Generic;

public class objectPool
{
    private GameObject prefab;
    private Queue<GameObject> queue;
    private int poolSize;

    public objectPool(GameObject prefab, int poolSize) {
        this.prefab = prefab;
        this.poolSize = poolSize;
        queue = new Queue<GameObject>();

        for(int i =0; i < this.poolSize; i++) {
            GameObject obj = Object.Instantiate(prefab);
            obj.SetActive(false);
            queue.Enqueue(obj);
        }
    }

    public GameObject GetFromPool() {
        GameObject obj = queue.Peek();
        if(obj.activeSelf)
            return null;

        queue.Dequeue();
        queue.Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }

}
