using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using SwipeMenu;

public class MainMenu : MonoBehaviour
{
    /*
     * It`s not my code, I just use it for uncompleted menu
    */
    [SerializeField]
    GameObject DownloadBlack, WhatMustBeShowedInBasicMenu, BackToMenu, WeaponChoserMenu, PlaceChoserMenu;
    public int NumberOfScene;
    public void OnClickPlay()
    {
        DownloadBlack.SetActive(true);
        SceneManager.LoadScene(NumberOfScene);
    }
    public void OnClickPlace()
    {
        if (GameObject.FindGameObjectWithTag("WeaponChoser") != null)
        { 
            Destroy(GameObject.FindGameObjectWithTag("WeaponChoser"));
        }
        if (GameObject.FindGameObjectWithTag("PlaceChoser") == null)
        {
            Instantiate(PlaceChoserMenu);
        }
        BackToMenu.SetActive(true);
        //WeaponChoserMenu.SetActive(false);
        WhatMustBeShowedInBasicMenu.SetActive(false);
        //PlaceChoserMenu.SetActive(true);
    }
    public void OnClickWeapon()
    {
        if (GameObject.FindGameObjectWithTag("PlaceChoser") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("PlaceChoser"));
        }
        if (GameObject.FindGameObjectWithTag("WeaponChoser") == null)
        {
            Instantiate(WeaponChoserMenu);
        }

        BackToMenu.SetActive(true);
        //PlaceChoserMenu.SetActive(false);
        WhatMustBeShowedInBasicMenu.SetActive(false);
        //WeaponChoserMenu.SetActive(true);
    }
    public IEnumerator WaitSecond()
    {
        yield return new WaitForSecondsRealtime(0.2f);
    }
    
    public void OnClickHomeButton()
    {
        BackToMenu.SetActive(false);
        WhatMustBeShowedInBasicMenu.SetActive(true);
    }
}
