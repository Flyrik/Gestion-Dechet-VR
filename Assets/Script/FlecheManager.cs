using UnityEngine;

public class FlecheManager : MonoBehaviour
{
    public GameObject flechePlastique;
    public GameObject flecheVerre;
    public GameObject flechePapier;


    private void Start()
    {
        DesactiverToutes();
    }
    public void ActiverFleche(string tag)
    {
        DesactiverToutes();

        if (tag == "Plastic" && flechePlastique != null)
            flechePlastique.SetActive(true);
        else if (tag == "Verre" && flecheVerre != null)
            flecheVerre.SetActive(true);
        else if (tag == "Dechet" && flechePapier != null)
            flechePapier.SetActive(true);
    }

    public void DesactiverToutes()
    {
        flechePlastique?.SetActive(false);
        flecheVerre?.SetActive(false);
        flechePapier?.SetActive(false);
    }
}
