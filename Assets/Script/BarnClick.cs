using UnityEngine;

public class BarnClick : MonoBehaviour
{
    public BarnUI barnUI;
    public string barnName = "Chuồng 1";

    private bool isOpen = false;

    private void OnMouseDown()
    {
        if (!isOpen)
        {
            barnUI.OpenPanel(barnName);
            isOpen = true;
        }
        else
        {
            barnUI.ClosePanel();
            isOpen = false;
        }
    }
}
