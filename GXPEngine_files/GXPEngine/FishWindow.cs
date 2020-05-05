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
    Fish fish;
    Sprite window, close;
    bool isOpen;
    public FishWindow(Fish fish, Journal journal) : base()
    {
        this.fish = fish;
        this.journal = journal;
        isOpen = true;
        close = new Sprite("jurnalClose.png");
        window = new Sprite("fishWindow.png");
        window.SetOrigin(window.width / 2, window.height / 2);
        window.SetXY(game.width/2, game.height/2);
        close.SetXY(window.x + 100, window.y - 100);
        canvas = new Canvas(window.width, window.height);
        AddChild(canvas);
        AddChild(window);
        AddChild(close);
    }


    void Update()
    {
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

