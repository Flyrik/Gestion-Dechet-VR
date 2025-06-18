using UnityEngine;
using TMPro;

public class ChronoBoucle : MonoBehaviour
{
    public TextMeshProUGUI chronoText; 
     public TextMeshProUGUI chronoText2;
    

    public static float tempsEcoule = 0f;
    private bool enCours = true;   


    void Start()
    {
        enCours = true;
        tempsEcoule = 0f; 
    }
    void Update()
    {
        if (!enCours) return;

        tempsEcoule += Time.deltaTime;

       chronoText2.text = "Temps : " + tempsEcoule.ToString("F2") + " s";

       chronoText.text = "Temps : " + tempsEcoule.ToString("F2") + " s";
    }

  
    public void StopChrono()
    {
        enCours = false;
    }

   
    public void ReprendreChrono()
    {
        enCours = true;
    }
}
