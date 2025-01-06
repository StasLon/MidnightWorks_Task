using UnityEngine;

public class LoadCarColor : MonoBehaviour
{
    public Renderer carRenderer; 
    public Material yellowMaterial; 
    public Material blueMaterial; 
    public Material greenMaterial;
    public Material blackMaterial; 
   

    private void Start()
    {
        
        LoadColor();
    }

    private void LoadColor()
    {
        string colorName = PlayerPrefs.GetString("CarColor", "Default");
        switch (colorName)
        {
            case "Blue":
                carRenderer.material = blueMaterial;
                Debug.Log("Loaded black");
                break;
            case "Green":
                carRenderer.material = greenMaterial;
                Debug.Log("Loaded green");
                break;
            case "Black":
                carRenderer.material = blackMaterial;
                Debug.Log("Loaded black");
                break;
        }
    }
}

