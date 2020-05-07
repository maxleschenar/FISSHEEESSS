using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Journal : GameObject
{
    Sprite journalButton, close;
    Sprite journal;
    List<Sprite> fishes;
    public bool inWindow;
    public Journal() : base()
    {
        fishes = new List<Sprite>();
        journalButton = new Sprite("journalbutton.png");
        journalButton.SetXY(game.width - 250, game.height - 200);
        close = new Sprite("jurnalClose.png");
        journal = new Sprite("journalitself.png");
        journal.SetXY(100, 100);
        close.SetXY(journal.x + journal.width - close.width, journal.y);
        AddChild(journalButton);
        AddChild(journal);
        AddChild(close);
        journal.alpha = 0f;
        close.alpha = 0f;
        inWindow = false;
        AddFish(new Sprite("Sturgeon.png"), journal.x + 600, journal.y + 150);
    }

    void Update()
    {
        if (!inWindow)
        {
            foreach (Sprite fish in fishes)
            {
                fish.alpha = 0f;
            }
            if (MyGame.CheckMouseInRect(journalButton))
            {
                journal.alpha = 1f;
                close.alpha = 1f;
                inWindow = true;
            }
        }

        if (inWindow)
        {
            foreach (Sprite fish in fishes)
            {
                fish.alpha = 1f;
            }

            if (MyGame.CheckMouseInRect(close))
            {
                close.alpha = 0f;
                journal.alpha = 0f;
                inWindow = false;
            }
        }
    }

    public void AddFish(Sprite fish, float x, float y)
    {
        fish.SetScaleXY(0.1f);
        fish.SetXY(x, y);
        AddChild(fish);
        fishes.Add(fish);
    }

}

