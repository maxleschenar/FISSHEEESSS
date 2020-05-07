using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;
public class Button : GameObject
{
    Canvas canvas;
    Image img;
    public float Width
    {
        get { return img.Width; }
    }
    public float Height
    {
        get { return img.Height; }
    }


    public Button(Vec2 position, string path)
    {
        SetXY(position.x, position.y);
        img = Image.FromFile(path);
        canvas = new Canvas(img.Width, img.Height);
        AddChild(canvas);
    }

    void Update()
    {
        canvas.graphics.Clear(Color.Transparent);
        canvas.graphics.DrawImage(img, 0,0);
    }

}

