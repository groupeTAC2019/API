using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Echange
{
    private long _id_echange;
    private DateTime _date_debut;
    private DateTime _date_fin;
    private bool _valide;
    private long _id_bien;
    private long _id_membre;

    public long Id_echange
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

    public long Id_bien
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

    public long Id_membre
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
