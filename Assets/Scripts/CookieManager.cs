using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookieManager : MonoBehaviour
{
    [SerializeField] private int cookies = 0;
    [SerializeField] private int cookiesPerClick = 1;
    [SerializeField] private Text cookieText;
    [SerializeField] private Text upgradeText;
    [SerializeField] private Text autoText;

    private int costToUpgrade = 5;
    private int autoCookie = 0;
    private int autoUpgradeCost = 25;

    private void Start()
    {
        UpdateCookieText();
        UpdateUpgradeText();
        UpdateAutoText();
        InvokeRepeating(nameof(AutoCookies), 0.0f, 1.0f);//repeats this function every second
    }

    public void AddCookie()//adds the value of cookies per click to the current amount of cookies
    {
        cookies+= cookiesPerClick;


        UpdateCookieText();
    }

    public void Upgrade()//increases the value of cookies per click
    {
        if (cookies >= costToUpgrade)
        {
            cookies -= costToUpgrade;

            cookiesPerClick++;

            costToUpgrade = costToUpgrade * 3 / 2;//multiplies its last price to find a new price

            UpdateUpgradeText();

            UpdateCookieText();
        }
        
    }
    void UpdateCookieText()//updates the text for the cookie counter
    {
        if (cookieText != null)
        {
            switch (cookies)
            {
                case 0:
                    cookieText.text = "No Cookies";
                    break;
                case 1:
                    cookieText.text = "One Cookie";
                    break;
                default:
                    cookieText.text = cookies.ToString() + " Cookies";
                    break;

            }

        }
    }

    void UpdateUpgradeText()// updates the text for the cookies per click upgrade
    {
        if (upgradeText != null)
        {
            upgradeText.text = "Upgrade = " + cookiesPerClick.ToString() + " cookies per click. " + costToUpgrade.ToString() + " cookies needed to upgrade";

        }
    }

    void UpdateAutoText()// updates the text for the auto clicker upgrade
    {
        if (autoText != null)
        {
            autoText.text = "Auto Clicker = " + autoCookie.ToString() + " cookies per second. " + autoUpgradeCost.ToString() + " cookies needed to upgrade";

        }
    }

    public void AutoClicker()//increases the value of autocookies
    {
        if (cookies >= autoUpgradeCost)
        {
            cookies -= autoUpgradeCost;

            autoCookie++;

            autoUpgradeCost = autoUpgradeCost * 3 / 2;

            UpdateAutoText();
            UpdateCookieText();
        }
    }

    public void AutoCookies()// adds the value of autocookies to current cookies
    {
        cookies += autoCookie;
        UpdateCookieText();
    }
}
