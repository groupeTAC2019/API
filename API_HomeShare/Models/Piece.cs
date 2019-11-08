using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Piece
{
    private int _id_piece;
    private string _nom;

    public int Id_piece
    {
        get
        {
            return _id_piece;
        }

        set
        {
            _id_piece = value;
        }
    }

    public string Nom
    {
        get
        {
            return _nom;
        }

        set
        {
            _nom = value;
        }
    }
}
