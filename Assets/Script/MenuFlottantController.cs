using UnityEngine;
using UnityEngine.InputSystem;

public class MenuToggleVR : MonoBehaviour
{
    public GameObject menu; 
    public InputActionProperty toggleAction;

    private bool menuVisible = false;

    void Start()
    {
        if (menu != null) menu.SetActive(false);
        toggleAction.action.Enable(); 
    }

    void Update()
    {
        if (toggleAction.action.WasPressedThisFrame())
        {
            menuVisible = !menuVisible;
            if (menu != null)
                menu.SetActive(menuVisible);
        }
    }


     public void ToggleAideVisuelle()
{
    gameObject.SetActive(!gameObject.activeSelf);
}
}
