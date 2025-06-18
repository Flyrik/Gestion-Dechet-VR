using UnityEngine;

public class SpawnDechet : MonoBehaviour
{
    
    [SerializeField] private GameObject[] dechets = new GameObject[3];
    void Start()
    {
        
    }



    public void Spawn()
    {
        int randomIndex = Random.Range(0, dechets.Length);
        Vector3 positionDeSpawn = new Vector3(-2.919f, -0.737f, 0.443f);

        GameObject dechet = Instantiate(dechets[randomIndex], positionDeSpawn, Quaternion.identity);
       
        
    }
    void Update()
    {
        
    }
}
