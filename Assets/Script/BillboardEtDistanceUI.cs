using UnityEngine;

public class BillboardEtDistanceUI : MonoBehaviour
{
    public Transform cibleCamera; 
    public  static float distanceMin = 3000f;  // Distance en dessous de laquelle l'icône est cachée
    public float distanceMax = 3000f;
    private Canvas canvas;

    void Start()
    {
        if (cibleCamera == null)
        {
            
            cibleCamera = Camera.main?.transform;
        }

        
        canvas = GetComponent<Canvas>();
        
        

       
    }

     void Awake()
    {
       
        //distanceMin = 10f;
    }

    void Update()
    {
        if (cibleCamera == null)
            return;

       
        transform.LookAt(transform.position + (transform.position - cibleCamera.position));

        // Gérer l'affichage selon la distance
        float distance = Vector3.Distance(transform.position, cibleCamera.position);

        if (canvas != null)
        {
            canvas.enabled = distance >= distanceMin && distance <= distanceMax;
        }
        else
        {
           
            gameObject.SetActive(distance >= distanceMin && distance <= distanceMax);
        }
    }
}
