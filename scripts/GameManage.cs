using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    // Text Values
    public Text XLMText;
    public Text XLMClickValueText;
    public Text XLMPowerText;
    public Text XLMPerSecText;

    // Prestige Text Values
    public Text XRPText;
    public Text XRPReadyText;
    public Text XRPBoostText;
    public Text XRPToGetText;

    // Misc Text Values
    public Text XPText;
    public Text LevelText;
    public Text XPPowerText;

    // Upgrade Texts
    public Text XLMClickUpgrade1Text;
    public Text XLMClickUpgrade2Text;
    public Text XLMIdleUpgrade1Text;
    public Text XLMIdleUpgrade2Text;

    // Number Values
    public double XLM;
    public double XLMPerClick;
    public double XLMPower;
    public double XLMPerSec;

    // Prestige Values
    public double XRP;
    public double XRPBoost;
    public double XRPToGet;

    // Upgrade Number Values
    public double XLMClickUpgrade1Cost;
    public double XLMClickUpgrade2Cost;
    public double XLMIdleUpgrade1Cost;
    public double XLMIdleUpgrade2Cost;
    public double XLMIdleUpgrade1Power;
    public double XLMIdleUpgrade2Power;

    // Misc Number Values
    public double XP;
    public double TotalXP;
    public double XPPerClick;
    public double XPRequirement;
    public double Level;
    public double XPPower;

  

    // Floats
    public float XLMClickUpgrade1Level;
    public float XLMClickUpgrade2Level;
    public float XLMIdleUpgrade1Level;
    public float XLMIdleUpgrade2Level;

    // Images
    public Image PrestigeProgressBar;
    public Image XPProgressBar;

    // Canvas Groups / Tabs
    public CanvasGroup MainMenuTabGroup;
    public CanvasGroup UpgradeTabGroup;
    public CanvasGroup PrestigeTabGroup;
    public CanvasGroup XPUpgradeTabGroup;
    public int TabSwitcher;


    public void Load()
    {
        XLM = double.Parse(PlayerPrefs.GetString("XLM", "0"));
        XLMPerClick = double.Parse(PlayerPrefs.GetString("XLMPerClick", "1"));
        XLMIdleUpgrade1Level = float.Parse(PlayerPrefs.GetString("XLMIdleUpgrade1Level", "0"));
        XLMIdleUpgrade2Level = float.Parse(PlayerPrefs.GetString("XLMIdleUpgrade2Level", "0"));
        XLMIdleUpgrade1Level = float.Parse(PlayerPrefs.GetString("XLMIdleUpgrade1Power", "1"));
        XLMIdleUpgrade2Level = float.Parse(PlayerPrefs.GetString("XLMIdleUpgrade2Power", "10"));
        XLMClickUpgrade1Level = float.Parse(PlayerPrefs.GetString("XLMClickUpgrade1Level", "1"));
        XLMClickUpgrade2Level = float.Parse(PlayerPrefs.GetString("XLMClickUpgrade2Level", "0"));
        XLMIdleUpgrade1Cost = double.Parse(PlayerPrefs.GetString("XLMIdleUpgrade1Cost", "10"));
        XLMIdleUpgrade2Cost = double.Parse(PlayerPrefs.GetString("XLMIdleUpgrade2Cost", "75"));
        XLMClickUpgrade1Cost = double.Parse(PlayerPrefs.GetString("XLMClickUpgrade1Cost", "15"));
        XLMClickUpgrade2Cost = double.Parse(PlayerPrefs.GetString("XLMClickUpgrade2Cost", "100"));

        XRP = double.Parse(PlayerPrefs.GetString("XRP", "0"));
        XRPToGet = double.Parse(PlayerPrefs.GetString("XRPToGet", "0"));
        XRPBoost = double.Parse(PlayerPrefs.GetString("XRPBoost", "0"));

        XP = double.Parse(PlayerPrefs.GetString("XP", "0"));
        TotalXP = double.Parse(PlayerPrefs.GetString("TotalXP", "0"));
        XPPerClick = double.Parse(PlayerPrefs.GetString("XPPerClick", "1"));
        XPPower = double.Parse(PlayerPrefs.GetString("XPPower", "1"));
        XPRequirement = double.Parse(PlayerPrefs.GetString("XPRequirement", "10"));
        Level = double.Parse(PlayerPrefs.GetString("Level", "0"));
    }

    public void Save()
    {
        PlayerPrefs.SetString("XLM", XLM.ToString());
        PlayerPrefs.SetString("XLMPerClick", XLMPerClick.ToString());
        PlayerPrefs.SetString("XLMClickUpgrade1Level", XLMClickUpgrade1Level.ToString());
        PlayerPrefs.SetString("XLMClickUpgrade2Level", XLMClickUpgrade2Level.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade1Level", XLMIdleUpgrade1Level.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade1Power", XLMIdleUpgrade1Power.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade1Cost", XLMIdleUpgrade1Cost.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade2Level", XLMIdleUpgrade2Level.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade2Power", XLMIdleUpgrade2Power.ToString());
        PlayerPrefs.SetString("XLMIdleUpgrade2Cost", XLMIdleUpgrade2Cost.ToString());
        PlayerPrefs.SetString("XLMClickUpgrade1Cost", XLMClickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("XLMClickUpgrade2Cost", XLMClickUpgrade2Cost.ToString());

        PlayerPrefs.SetString("XLM", XLM.ToString());
        PlayerPrefs.SetString("XRPToGet", XRPToGet.ToString());
        PlayerPrefs.SetString("XRPBoost", XRPBoost.ToString());

        PlayerPrefs.SetString("XP", XP.ToString());
        PlayerPrefs.SetString("TotalXP", TotalXP.ToString());
        PlayerPrefs.SetString("XPPerClick", XPPerClick.ToString());
        PlayerPrefs.SetString("XPPower", XPPower.ToString());
        PlayerPrefs.SetString("XPRequirement", XPRequirement.ToString());
        PlayerPrefs.SetString("Level", Level.ToString());
    }

    public void Start()
    {
        Application.targetFrameRate = 60;
        Load();


        string XLMString;
        if (XLM >= 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(XLM))));
            var mantissa = (XLM / System.Math.Pow(10, exponent));
            XLMString = "αXLM: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else XLMString = XLM.ToString("F2") + " αXLM";

        // Tab Stuff
        CanvasGroupChanger(true, MainMenuTabGroup);
        CanvasGroupChanger(false, UpgradeTabGroup);
        CanvasGroupChanger(false, XPUpgradeTabGroup);
        CanvasGroupChanger(false, PrestigeTabGroup);
        TabSwitcher = 0;


     
    }

    public void CanvasGroupChanger(bool x, CanvasGroup y)
    {
        if (x)
        {
            y.alpha = 1;
            y.interactable = true;
            y.blocksRaycasts = true;
            return;
        }
        y.alpha = 0;
        y.interactable = false;
        y.blocksRaycasts = false;
    }


    

    public void Update()
    {

        // scientific notation


        if (XP >= XPRequirement)
        {
            XP = 0;
            Level++;
            XPRequirement *= 1.25;
            XPPower *= 1.01;
        }


        if (XLMClickUpgrade1Level + XLMClickUpgrade2Level >= 1)
            {
            XLMPerSec = (XLMIdleUpgrade1Power + XLMIdleUpgrade2Power) * XPPower;
        }
        if (XLM >= 10000)
        {
            XRPToGet = (150 * System.Math.Sqrt(XLM / 1e8));
            XRPReadyText.text = "XRP Prestige Ready" + " ( + " + XRPToGet.ToString("F2") + " βXRP )";
        }
        if (XLM <= 10000)
        {
            XRPReadyText.text = "XRP Prestige Not Ready";
        }

        XRPBoost = (XRP * 0.03) + 1;

        XRPToGetText.text = "Prestige for " + System.Math.Floor(XRPToGet).ToString("F0") + " βXRP";
        XRPText.text = XRP.ToString("F2") + " βXRP";
        XRPBoostText.text = XRPBoost.ToString("F2") + "x Boost";

        XLMText.text = XLM.ToString("F0") + " αXLM";
        XPText.text = XP.ToString("F0") + " XP" + " / " + XPRequirement.ToString("F0") + " XP" + " ( " + TotalXP.ToString("F0") + " XP ) ";
        LevelText.text = Level.ToString("F0");
        XPPowerText.text = "x" + XPPower.ToString("F2") + " PWR from Level";
        XLMPerSecText.text = XLMPerSec.ToString("F3") + " αXLM/s";
        XLMPowerText.text = "x" + XLMPower.ToString("F2") + " PWR from DM Mk.II";
        XLMClickValueText.text = "+ " + ((XLMPerClick * XPPower) * XRPBoost).ToString("F2") + " αXLM";
        XLMClickUpgrade1Text.text = "Digital Modding Mk.I\n+1 αXLM C.Value\nCost: " + XLMClickUpgrade1Cost.ToString("F2") + " αXLM\nLevel: " + XLMClickUpgrade1Level;
        XLMClickUpgrade2Text.text = "Digital Modding Mk.II\n+10 αXLM C.Value\nCost: " + XLMClickUpgrade2Cost.ToString("F2") + " αXLM\nLevel: " + XLMClickUpgrade2Level;
        XLMIdleUpgrade1Text.text = "Digital Node Mk.I\n+" + XLMIdleUpgrade1Power.ToString("F2") + " αXLM/s\nCost: " + XLMIdleUpgrade1Cost.ToString("F2") + " αXLM\nLevel: " + XLMIdleUpgrade1Level;
        XLMIdleUpgrade2Text.text = "Digital Node Mk.II\n+" + XLMIdleUpgrade2Power.ToString("F2") + " αXLM/s\nCost: " + XLMIdleUpgrade2Cost.ToString("F2") + " αXLM\nLevel: " + XLMIdleUpgrade2Level;

        PrestigeProgressBar.fillAmount = (float)(XLM / 10000);
        XPProgressBar.fillAmount = (float)(XP / XPRequirement);


        XLM += XLMPerSec * Time.deltaTime;
        Save();
    }

    // Prestige
    public void Prestige()
    {
        if (XLM >= 10000)
        {
            XLM = 0;
            XLMPerClick = 1;
            XLMPerSec = 0;
            XP = 0;
            TotalXP = 0;
            XPPerClick = 1;
            XPPower = 1;
            Level = 0;
            XPRequirement = 10;
            XLMClickUpgrade1Cost = 15;
            XLMClickUpgrade1Level = 1;
            XLMClickUpgrade2Cost = 100;
            XLMClickUpgrade2Level = 0;
            XLMIdleUpgrade1Cost = 10;
            XLMIdleUpgrade1Level = 0;
            XLMIdleUpgrade1Power = 0;
            XLMIdleUpgrade2Cost = 75;
            XLMIdleUpgrade2Level = 0;
            XLMIdleUpgrade2Power = 0;

            CanvasGroupChanger(true, MainMenuTabGroup);
            CanvasGroupChanger(false, UpgradeTabGroup);
            CanvasGroupChanger(false, PrestigeTabGroup);
            TabSwitcher = 0;



            XRP += XRPToGet;
            if ( XLM < 10000)
            {
                XRPToGet = 0;
            }
        }
    }


    // Buttons 
    public void Click()
    {
        XLM += (XLMPerClick * (XPPower)) * XRPBoost;
        XP += XPPerClick * XRPBoost;
        TotalXP += XPPerClick * XRPBoost;
    }

    public void BuyXLMClickUpgrade1()
    {
        if (XLM >= XLMClickUpgrade1Cost)
        {
            XLMClickUpgrade1Level++;
            XLM -= XLMClickUpgrade1Cost;
            XLMClickUpgrade1Cost *= 1.15;
            XLMPerClick += 1;
        }
    }

    public void BuyXLMClickUpgrade2()
    {
        if (XLM >= XLMClickUpgrade2Cost)
        {
            XLMClickUpgrade2Level++;
            XLM -= XLMClickUpgrade2Cost;
            XLMClickUpgrade2Cost *= 1.3;
            XLMPerClick += 10;
        }
    }

    public void BuyXLMIdleUpgrade1()
    {
        if (XLM >= XLMIdleUpgrade1Cost)
        {
            XLMIdleUpgrade1Level++;
            XLM -= XLMIdleUpgrade1Cost;
            XLMIdleUpgrade1Cost *= 1.15;
            XLMIdleUpgrade1Power += 1;
        }
    }

    public void BuyXLMIdleUpgrade2()
    {
        if (XLM >= XLMIdleUpgrade2Cost)
        {
            XLMIdleUpgrade2Level++;
            XLM -= XLMIdleUpgrade2Cost;
            XLMIdleUpgrade2Cost *= 1.25;
            XLMIdleUpgrade2Power += 10;
        }
    }


    public void HardReset()
    {
        XLM = 0;
        XLMPower = 1;
        XLMPerClick = 1;
        XLMClickUpgrade1Level = 1;
        XLMClickUpgrade2Level = 0;
        XLMIdleUpgrade1Level = 0;
        XLMIdleUpgrade2Level = 0;
        XLMClickUpgrade1Cost = 15;
        XLMClickUpgrade2Cost = 100;
        XLMIdleUpgrade1Cost = 10;
        XLMIdleUpgrade2Cost = 75;
        XLMIdleUpgrade1Power = 0;
        XLMIdleUpgrade2Power = 0;
        XRP = 0;
        XRPToGet = 0;
        XRPBoost = 0;
        XP = 0;
        TotalXP = 0;
        XPPower = 1;
        Level = 0;
        XPPerClick = 1;
        XPRequirement = 10;
        
    }

    public void ChangeTabs(string id)
    {
        switch (id)
        {
            case "Upgrades":
                CanvasGroupChanger(false, MainMenuTabGroup);
                CanvasGroupChanger(true, UpgradeTabGroup);
                CanvasGroupChanger(false, XPUpgradeTabGroup);
                CanvasGroupChanger(false, PrestigeTabGroup);
                break;

            case "XPUpgrades":
                CanvasGroupChanger(false, MainMenuTabGroup);
                CanvasGroupChanger(false, UpgradeTabGroup);
                CanvasGroupChanger(true, XPUpgradeTabGroup);
                CanvasGroupChanger(false, PrestigeTabGroup);
                break;

            case "Prestige":
                CanvasGroupChanger(false, MainMenuTabGroup);
                CanvasGroupChanger(false, UpgradeTabGroup);
                CanvasGroupChanger(false, XPUpgradeTabGroup);
                CanvasGroupChanger(true, PrestigeTabGroup);
                break;

            case "Main":
                CanvasGroupChanger(true, MainMenuTabGroup);
                CanvasGroupChanger(false, UpgradeTabGroup);
                CanvasGroupChanger(false, XPUpgradeTabGroup);
                CanvasGroupChanger(false, PrestigeTabGroup);
                break;

        }
    }
}
