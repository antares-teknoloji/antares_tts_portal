using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Aktarimlarcs
/// </summary>
public class Aktarimlarcs
{

    public static UnityObjects.UnityApplication uo;
    public static bool UnityBagli;
    public static void ilkDeger()
    { uo = new UnityObjects.UnityApplication(); }
    public static bool bagliyim()
    {
        if (uo.Connect())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool baglan(string username, string password, int firmnumber)
    {
        uo.Login(username, password, firmnumber);
        if (uo.Connected)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}