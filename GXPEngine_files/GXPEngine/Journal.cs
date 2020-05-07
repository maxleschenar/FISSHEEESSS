using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;
public class Journal : GameObject
{
    Sprite journalButton, close;
    Sprite journal;
    List<Fish> freshFish, seaFish, deepFish;
    Canvas canvas;
    public bool inWindow;
    public Journal() : base()
    {

        freshFish = new List<Fish>();
        
        seaFish = new List<Fish>();
        deepFish = new List<Fish>();
        journalButton = new Sprite("journalbutton.png");
        journalButton.SetXY(game.width - 250, game.height - 200);
        close = new Sprite("jurnalClose.png");
        journal = new Sprite("journalitself.png");
        journal.SetXY(100, 100);
        canvas = new Canvas(journal.width, journal.height);
        close.SetXY(journal.x + journal.width - close.width, journal.y);
        AddChild(journalButton);
        AddChild(journal);
        AddChild(canvas);
        AddChild(close);
        journal.alpha = 0f;
        close.alpha = 0f;
        inWindow = false;
    }

    void Update()
    {
        if (!inWindow)
        {
            canvas.graphics.Clear(Color.Transparent);
            if (MyGame.CheckMouseInRectClick(journalButton))
            {
                journal.alpha = 1f;
                close.alpha = 1f;
                inWindow = true;
            }
        }

        if (inWindow)
        {
            canvas.graphics.Clear(Color.Transparent);
            for(int i = 0; i < freshFish.Count; i++)
            {
                canvas.graphics.DrawString(freshFish[i].GetFishName(), SystemFonts.DefaultFont, Brushes.Black, journal.x + 50, journal.y + 150 + 25 * i);
            }
            if (MyGame.CheckMouseInRectClick(close))
            {
                close.alpha = 0f;
                journal.alpha = 0f;
                inWindow = false;

            }
        }
    }

    public void AddFish(Fish fish)
    {
        AddChild(fish);
        switch (fish.GetFishType())
        {
            case "Fresh water":
                freshFish.Add(fish);
                break;
            case "Sea water":
                seaFish.Add(fish);
                break;
            case "Deep water":
                deepFish.Add(fish);
                break;
        }
    }


}

