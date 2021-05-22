using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPipe : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;


    // Start is called before the first frame update
    void Start()
    {
      
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        
        yield return new WaitForSeconds(1);
        Vector3 x = pipeHolder.transform.position;
        x.y = Random.Range(-1.5f, 1.5f);
        Instantiate(pipeHolder, x, Quaternion.identity);
        if (BirdController.instance.flag == 1)
            Destroy(GetComponent<SpawnerPipe>());
            StartCoroutine(Spawner());
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
