using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    // Text Values
    public Text XLMText;
    public Text XLMClickValueText;
    public Text XLMPowerText;
    public Text XLMPerSecText;

    // Upgrade Texts
    public Text XLMClickUpgrade1Text;
    public Text XLMClickUpgrade2Text;
    public Text XLMIdleUpgrade1Text;

    // Number Values
    public double XLM;
    public double XLMPerClick;
    public double XLMPower;
    public double XLMPerSec;
    public double XLMClickUpgrade1Cost;
    public double XLMClickUpgrade2Cost;
    public double XLMIdleUpgrade1Cost;

    // Floats
    public float XLMClickUpgrade1Level;
    public float XLMClickUpgrade2Level;
    public float XLMIdleUpgrade1Level;


    public void Start()
    {
        XLM = 0;
        XLMPerClick = 1;
        XLMPower = 1;
        XLMPerSec = 0;
        XLMClickUpgrade1Cost = 15;
        XLMClickUpgrade2Cost = 100;
        XLMIdleUpgrade1Cost = 10;
    }

    public void Update()
    {
        XLMPerSec = XLMIdleUpgrade1Level;

        XLMText.text = XLM.ToString("F0") + " αXLM";
        XLMPerSecText.text = XLMPerSec.ToString("F3") + " αXLM/s";
        XLMPowerText.text = "x" + XLMPower.ToString("F2") + " PWR from DM Mk.II";
        XLMClickValueText.text = "+ " + XLMPerClick.ToString("F2") + " αXLM";
        XLMClickUpgrade1Text.text = "Digital Modding Mk.I\n+1 αXLM C.Value\nCost: " + XLMClickUpgrade1Cost.ToString("F2") + " αXLM\nLevel: " + XLMClickUpgrade1Level;
        XLMClickUpgrade2Text.text = "Digital Modding Mk.II\nx1.25 PWR to DM Mk.I\nCost: " + XLMClickUpgrade2Cost.ToString("F2") + " αXLM\nLevel: " + XLMClickUpgrade2Level;
        XLMIdleUpgrade1Text.text = "Digital Node Mk.I\n+1 αXLM/s\nCost: " + XLMIdleUpgrade1Cost.ToString("F2") + " αXLM\nLevel: " + XLMIdleUpgrade1Level;

        XLM += XLMPerSec * Time.deltaTime;
    }


    // Buttons 
    public void Click()
    {
        XLM += XLMPerClick;
    }

    public void BuyXLMClickUpgrade1()
    {
        if (XLM >= XLMClickUpgrade1Cost)
        {
            XLMClickUpgrade1Level++;
            XLM -= XLMClickUpgrade1Cost;
            XLMClickUpgrade1Cost *= 1.15;
            XLMPerClick += 1 * (XLMPower);
        }
    }

    public void BuyXLMClickUpgrade2()
    {
        if (XLM >= XLMClickUpgrade1Cost)
        {
            XLMClickUpgrade2Level++;
            XLM -= XLMClickUpgrade2Cost;
            XLMClickUpgrade2Cost *= 2.5;
            XLMPower *= 1.25;
        }
    }

    public void BuyXLMIdleUpgrade1()
    {
        if (XLM >= XLMIdleUpgrade1Cost)
        {
            XLMIdleUpgrade1Level++;
            XLM -= XLMIdleUpgrade1Cost;
            XLMIdleUpgrade1Cost *= 1.15;
            XLMPerSec += 1;
        }
    }
}
