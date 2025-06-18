using UnityEngine;

public class RemoveArrow : MonoBehaviour
{
    
    public GameObject flecheSol;

    private bool flechesActives = false;

    public static bool isVisual = false;


    void Start()
    {
        isVisual= false;
        flechesActives = false;
    }
    public void ToggleFleches()
    {
        isVisual = !isVisual;
        flechesActives = !flechesActives;
        
        DechetInteractable.IsEnabled = !DechetInteractable.IsEnabled;
        // EnableSprite.instance.EnableCanvas();



        float newDistanceMin = flechesActives ? 3f : 3000f;

        foreach (BillboardEtDistanceUI ui in Object.FindObjectsByType<BillboardEtDistanceUI>(FindObjectsSortMode.None))
        {
            BillboardEtDistanceUI.distanceMin = newDistanceMin;
        }


        if (flecheSol != null) flecheSol.SetActive(flechesActives);
    }
    

    
}
