using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DechetInteractable : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{

    public string nomDechet = "Déchet inconnu";
    private FlecheManager flecheManager;
    
    public static bool IsEnabled = false;

    void Start()
    {
        IsEnabled = false; 
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);


        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;

        FindAnyObjectByType<AfficheNomDechetUI>()?.AfficherNom(nomDechet);


        if (flecheManager == null)
            flecheManager = FindAnyObjectByType<FlecheManager>();



        if (IsEnabled == true)
        {


            flecheManager?.ActiverFleche(tag);
        }
        
         if(RemoveArrow.isVisual)
        {
            flecheManager?.ActiverFleche(tag);
        }
        else
        {
            flecheManager?.DesactiverToutes();
        }
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = false;


        FindAnyObjectByType<AfficheNomDechetUI>()?.CacherNom();

        flecheManager?.DesactiverToutes();
    }
}
