using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public GameObject PanelMenu;
    public GameObject PanelMenuSobre;
    public GameObject PanelMenuOpcoes;

  

    public void OpenPanelMenu()
    {
        bool isActive = PanelMenu.activeSelf;
        if (PanelMenu != null)
        {
            PanelMenu.SetActive(!isActive);
            
        }
        else
        {
            PanelMenu.SetActive(isActive);

        }


    }
    
    public void OpenPanelSobre()
    {
        bool isActive = PanelMenuSobre.activeSelf;
        if (PanelMenuSobre != null)
        {
            PanelMenuSobre.SetActive(!isActive);
            PanelMenu.SetActive(isActive);

        } else
        {
            PanelMenuSobre.SetActive(isActive);
                PanelMenu.SetActive(!isActive);

        }


    }

    public void OpenPanelOpcoes()
    {
        bool isActive = PanelMenuOpcoes.activeSelf;
        if (PanelMenuOpcoes != null)
        {
            PanelMenuOpcoes.SetActive(!isActive);
            PanelMenu.SetActive(isActive);

        }
        else
        {
            PanelMenuOpcoes.SetActive(isActive);
            PanelMenu.SetActive(!isActive);

        }


    }


}
