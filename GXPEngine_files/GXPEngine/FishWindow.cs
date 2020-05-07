using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;
public class FishWindow : GameObject
{
    Canvas canvas;
    Journal journal;
    public FishWindow(Journal journal) : base()
    {
        this.journal = journal;
        canvas = new Canvas(400, 300);
        canvas.SetXY(journal.x + 200, journal.y + 200);
        AddChild(canvas);

    }


    void Update()
    {
        canvas.graphics.FillRectangle(Brushes.Black, canvas.x, canvas.y, canvas.width, canvas.height);
    }


}

