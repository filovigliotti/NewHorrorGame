using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    bool isCreated = false;
    public GameObject objectToSpawn;
    public GameObject clownToSpawn;
    //list of spider that will be instantiated later
    private GameObject[] createdObjects;
   
    

    public int min, max;
    public int minC, maxC;
    //Esercito di ragni che ti viene addosso random
    

    // Start is called before the first frame update
    void Start()
    {
        placeClown();
        placeSpider();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // DestroySpider();
       if(Input.touchCount > 0)
        {
            var t = Input.touches[0];
            print(t);
        }

       

    }





    private void Awake()
    {
        createdObjects = new GameObject[100];
    }

    async void placeSpider()
    {
        if (!isCreated)
        {
            for (int i = 0; i < 5; i++)
            {
                createdObjects[i] = GameObject.Instantiate(objectToSpawn, GeneratedPosition(), transform.rotation * Quaternion.Euler(0.0f, 180.0f, 0.0f));
                
                await Task.Delay(40);  
            }
            isCreated = true;
        }
    }

    async void placeClown()
    {
        for(int i= 0; i< 100; i++)
        {
            Instantiate(clownToSpawn, GeneratedPositionClown(), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            await Task.Delay(200);
        }
    }

    Vector3 GeneratedPosition()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(0, max);
        y = -15;
        z = UnityEngine.Random.Range(min, max);

        return new Vector3(x, y, z);
    }

    Vector3 GeneratedPositionClown()
    {
        int x, y, z;
        x = UnityEngine.Random.Range(minC, maxC);
        y = -15;
        z = UnityEngine.Random.Range(minC, maxC);

        return new Vector3(x, y, z);
    }

    void DestroySpider()
    {
        //int i = 0;
        
        int cont = 1;
             foreach(Touch t in Input.touches)
            {
            print(cont);
            
            
           Destroy(createdObjects[cont]);
             cont++;
        }
    }


}
