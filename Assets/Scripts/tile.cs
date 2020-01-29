using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Color
{
    Red, Orange, Yellow, Green, Blue, Purple, White
}

public enum Shape
{
    Cross, Flower , Arrow, Diamond, Square, Font, White
}


public class tile : MonoBehaviour
{
    public string Name
    {
        get
        {
            return Color + " " + Shape;
        }

    }

    public Sprite Image
    {
        get
        {
            return _image;
        }
        set
        {
            this.Image=value;
        }
    }
    public Color Color;
    public Shape Shape;
    public Sprite _image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public tile(Color color, Shape shape, Sprite img)
    {
        this.Color = color;
        this.Shape = shape;
        this.Image = img;
    }

    public bool IsCompatibleWith(tile tile)
    {
        // Same color different shape or
        // different color same shape
        return (tile != null &&
                (((this.Color == tile.Color) && (this.Shape != tile.Shape)) ||
                 ((this.Color != tile.Color) && (this.Shape == tile.Shape))));

        //Can play same tile
        //return (tile != null &&
        //  ((this.Color == tile.Color) || (this.Shape == tile.Shape)));
    }

    public bool Equals(tile tile)
    {
        if ((object)tile == null)
        {
            return false;
        }

        return this.Color == tile.Color && this.Shape == tile.Shape;
    }

    public static bool operator ==(tile a, tile b)
    {
        if (ReferenceEquals(a, b))
        {
            return true;
        }

        if ((object)a == null || (object)b == null)
        {
            return false;
        }

        return ((a.Color == b.Color) && (a.Shape == b.Shape));
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }

        var tile = obj as tile;
        if ((object)tile == null)
        {
            return false;
        }

        return this.Color == tile.Color && this.Shape == tile.Shape;
    }

    public static bool operator !=(tile a, tile b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        int hash= 10;
        return hash;
    }
}
