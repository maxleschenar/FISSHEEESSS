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
        
        img = Image.FromFile(path);
        canvas = new Canvas(img.Width, img.Height);
        SetXY(position.x - img.Width / 2, position.y - img.Height / 2);
        AddChild(canvas);
    }

    void Update()
    {
        canvas.graphics.Clear(Color.Transparent);
        canvas.graphics.DrawImage(img, 0,0);
    }

}

