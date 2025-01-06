using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeCarColor : MonoBehaviour
{
    public Renderer carRenderer;
    public Material yellowMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material blackMaterial;

    public Button blueButton;
    public Button greenButton;
    public Button blackButton;

    public TextMeshProUGUI blueButtonText;
    public TextMeshProUGUI greenButtonText;
    public TextMeshProUGUI blackButtonText;
    public TextMeshProUGUI moneyText;

    private bool bluePurchased = false;
    private bool greenPurchased = false;
    private bool blackPurchased = false;

    private int playerMoney;
    public Timer timerScript;

    private void Start()
    {
       
        playerMoney = PlayerPrefs.GetInt("Money", 0);

        bluePurchased = PlayerPrefs.GetInt("BluePurchased", 0) == 1;
        greenPurchased = PlayerPrefs.GetInt("GreenPurchased", 0) == 1;
        blackPurchased = PlayerPrefs.GetInt("BlackPurchased", 0) == 1;


        blueButtonText.text = bluePurchased ? "Equipped" : "1000 $";
        greenButtonText.text = greenPurchased ? "Equipped" : "1000 $";
        blackButtonText.text = blackPurchased ? "Equipped" : "1000 $";

        string equippedColor = PlayerPrefs.GetString("EquippedColor", string.Empty);
        if (!string.IsNullOrEmpty(equippedColor))
        {
            ApplySavedColor(equippedColor);
        }


        UpdateMoneyText();


    }
    private void ChangeCarMaterial(Material newMaterial, TextMeshProUGUI equippedButton, string colorName)
    {
        if (carRenderer != null)
        {
            carRenderer.material = newMaterial;
     
            SaveCarColor(colorName);

            UpdateButtonTextsForEquipped(equippedButton);
        }
       
    }

    public void AttemptPurchase(int index)
    {
       
        bool isAlreadyPurchased = false;

        switch (index)
        {
            case 0:
                isAlreadyPurchased = bluePurchased;
                break;
            case 1:
                isAlreadyPurchased = greenPurchased;
                break;
            case 2:
                isAlreadyPurchased = blackPurchased;
                break;
        }

        if (isAlreadyPurchased)
        {
           
            EquipColor(index);
        }
        else
        {
            
            int price = 1000;
            if (playerMoney >= price)
            {
                
                playerMoney -= price;
                SaveMoney();

                
                EquipColor(index);
                MarkColorAsPurchased(index);
            }
            else
            {
                Debug.Log("Not enough money!");
            }
        }

        UpdateMoneyText();
    }

    private void EquipColor(int index)
    {
        
        switch (index)
        {
            case 0:
                ChangeCarMaterial(blueMaterial, blueButtonText, "Blue");
                break;
            case 1:
                ChangeCarMaterial(greenMaterial, greenButtonText, "Green");
                break;
            case 2:
                ChangeCarMaterial(blackMaterial, blackButtonText, "Black");
                break;
        }
    }


    private void MarkColorAsPurchased(int index)
    {
        
        switch (index)
        {
            case 0:
                bluePurchased = true;
                SavePurchase("BluePurchased", bluePurchased);
                break;
            case 1:
                greenPurchased = true;
                SavePurchase("GreenPurchased", greenPurchased);
                break;
            case 2:
                blackPurchased = true;
                SavePurchase("BlackPurchased", blackPurchased);
                break;
        }
    }

    private void SaveCarColor(string colorName)
    {
        PlayerPrefs.SetString("CarColor", colorName);
        PlayerPrefs.SetString("EquippedColor", colorName);
        PlayerPrefs.Save();
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("Money", playerMoney);
        PlayerPrefs.Save();
        
    }

    private void SavePurchase(string key, bool purchased)
    {
        PlayerPrefs.SetInt(key, purchased ? 1 : 0);
        PlayerPrefs.Save();
        
    }

    private void UpdateButtonTextsForEquipped(TextMeshProUGUI equippedButton)
    {
      
        blueButtonText.text = bluePurchased ? "Equip" : "1000 $";
        greenButtonText.text = greenPurchased ? "Equip" : "1000 $";
        blackButtonText.text = blackPurchased ? "Equip" : "1000 $";

       
        equippedButton.text = "Equipped";
    }

    private void UpdateMoneyText()
    {
        moneyText.text = $"{playerMoney} $";
    }


    private void ApplySavedColor(string colorName)
    {
        switch (colorName)
        {
            case "Blue":
                if (bluePurchased) ChangeCarMaterial(blueMaterial, blueButtonText, "Blue");
                break;
            case "Green":
                if (greenPurchased) ChangeCarMaterial(greenMaterial, greenButtonText, "Green");
                break;
            case "Black":
                if (blackPurchased) ChangeCarMaterial(blackMaterial, blackButtonText, "Black");
                break;
            default:
                Debug.Log($"Unknown color: {colorName}");
                break;
        }
    }
}





