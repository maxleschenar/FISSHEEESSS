using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Journal : GameObject
{
    Sprite journalButton, close;
    Sprite journal;
    List<Sprite> buttons;
    public bool inWindow;
    public Journal() : base()
    {
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
    }

    void Update()
    {
        if (MyGame.CheckMouseInRect(journalButton) && !inWindow)
        {
            journal.alpha = 1f;
            close.alpha = 1f;
            inWindow = true;
        }

        if (MyGame.CheckMouseInRect(close) && inWindow)
        {
            close.alpha = 0f;
            journal.alpha = 0f;
            inWindow = false;
        }
    }

}

