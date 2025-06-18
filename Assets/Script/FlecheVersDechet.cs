using UnityEngine;

public class FlecheVersDechet : MonoBehaviour
{
    public string[] tagsDechets = { "Plastic", "Dechet", "Verre" };
    public float distanceMaxDetection = 50f;
    void Update()
    {
        GameObject plusProche = null;
        float distanceMin = Mathf.Infinity;

        foreach (string tag in tagsDechets)
        {
            GameObject[] objets = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject obj in objets)
            {
                float dist = Vector3.Distance(transform.position, obj.transform.position);
                if (dist < distanceMin && dist <= distanceMaxDetection)
                { 
                    distanceMin = dist;
                    plusProche = obj;
                }
            }
        }

        
        if (plusProche == null)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            gameObject.SetActive(true);
        }

       
        Vector3 direction = plusProche.transform.position - transform.position;
        direction.y = 0; 

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation * Quaternion.Euler(90, 0, 180);
        }

    }


    public void DisableAideVisuelle()
    {
        gameObject.SetActive(false);
    }
    
   
    
}
