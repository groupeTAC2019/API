using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Photo
{
    private int _id_Photo;
    private string _lien;
    private string _legende;
    private int _id_bien;

    public long Id_Photo
    {
        get
        {
            return _id_Photo;
        }

        set
        {
            _id_Photo = value;
        }
    }

    public string Lien
    {
        get
        {
            return _lien;
        }

        set
        {
            _lien = value;
        }
    }

    public string Legende
    {
        get
        {
            return _legende;
        }

        set
        {
            _legende = value;
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
}
