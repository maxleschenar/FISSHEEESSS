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
    Sprite window, close;
    bool isOpen;
    public FishWindow(Journal journal) : base()
    {
        this.journal = journal;
        isOpen = true;
        close = new Sprite("jurnalClose.png");
        window = new Sprite("fishWindow.png");
        canvas = new Canvas(window.width, window.height);

        close.SetXY(window.x + window.width, 300);
        window.SetXY(game.width / 2, game.height / 2);
        window.SetOrigin(window.width / 2, window.height / 2);
        canvas.SetXY(window.x - window.width / 2, window.y - window.height / 2);
        AddChild(window);
        AddChild(close);
        AddChild(canvas);

    }


    void Update()
    {
        canvas.graphics.Clear(Color.Transparent);
        if (MyGame.CheckMouseInRect(close) && isOpen)
        {
            SetActive(false);
            journal.inWindow = false;
        }
    }

    public void SetActive(bool isOpen)
    {
        this.isOpen = isOpen;
        if (isOpen)
        {
            window.alpha = 1f;
            close.alpha = 1f;
        }
        if (!isOpen)
        {
            window.alpha = 0f;
            close.alpha = 0f;
        }
    }

}

