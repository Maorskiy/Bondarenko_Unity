


using UnityEngine;

public class PlatformGenerate : MonoBehaviour
{
    public GameObject platformPrefab;         
    public Transform platformParent;          
    public Transform deadZone;                
    public float respawnHeight = 500f;       
    public float minDistanceY = 2f;           
    public float maxDistanceY = 5f;          
    public float spawnWidthRadius = 10f;     

    void Start()
    {
        GenerateInitialPlatforms();
    }

    void GenerateInitialPlatforms()
    {
        Vector3 spawnerPosition = new Vector3();
        for (int i = 0; i < 10; i++)
        {
            spawnerPosition.x = Random.Range(-spawnWidthRadius, spawnWidthRadius); 
            spawnerPosition.y += Random.Range(minDistanceY, maxDistanceY);         
            spawnerPosition.z = 0f;

          
            GameObject platform = Instantiate(platformPrefab, spawnerPosition, Quaternion.identity, platformParent);
        }
    }

    void Update()
    {
       
        foreach (Transform platform in platformParent)
        {
            if (platform.position.y < deadZone.position.y)
            {
               
                Vector3 newPosition = platform.position;
                newPosition.y += respawnHeight;                                   
                newPosition.x = Random.Range(-spawnWidthRadius, spawnWidthRadius); 
                platform.position = newPosition;
            }
        }
    }
}
