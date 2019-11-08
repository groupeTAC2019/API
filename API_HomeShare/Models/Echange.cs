using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Echange
{
    private int _id_echange;
    private DateTime _date_debut;
    private DateTime _date_fin;
    private bool _valide;
    private int _id_bien;
    private int _id_membre;

    public int Id_echange
    {
        get
        {
            return _id_echange;
        }

        set
        {
            _id_echange = value;
        }
    }

    public DateTime Date_debut
    {
        get
        {
            return _date_debut;
        }

        set
        {
            _date_debut = value;
        }
    }

    public DateTime Date_fin
    {
        get
        {
            return _date_fin;
        }

        set
        {
            _date_fin = value;
        }
    }

    public bool Valide
    {
        get
        {
            return _valide;
        }

        set
        {
            _valide = value;
        }
    }

    public int Id_bien
    {
        get
        {
            return _id_bien;
        }

        set
        {
            _id_bien = value;
        }
    }

    public int Id_membre
    {
        get
        {
            return _id_membre;
        }

        set
        {
            _id_membre = value;
        }
    }
}
