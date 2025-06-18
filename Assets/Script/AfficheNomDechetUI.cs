using TMPro;
using UnityEngine;

public class AfficheNomDechetUI : MonoBehaviour
{
    public TextMeshProUGUI nomText;
    
    public Transform cameraTransform;


     void Update()
    {
        if (cameraTransform != null)
            transform.LookAt(cameraTransform.position);
    }
    public void AfficherNom(string nom)
    {
        
        nomText.text = nom;
        nomText.gameObject.SetActive(true);
    }

    public void CacherNom()
    {
        nomText.gameObject.SetActive(false);
    }
}
