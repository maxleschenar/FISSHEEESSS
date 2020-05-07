using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Journal : GameObject
{
    Sprite journalButton, close;
    Sprite journal;
    List<Fish> freshFish, seaFish, deepFish;
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
        if (!inWindow)
        {

            if (MyGame.CheckMouseInRectClick(journalButton))
            {
                journal.alpha = 1f;
                close.alpha = 1f;
                inWindow = true;
                foreach (Fish f in freshFish)
                {
                    f.buyToUnlock.alpha = 0f;
                }
                foreach (Fish f in seaFish)
                {
                    f.buyToUnlock.alpha = 0f;
                }
                foreach (Fish f in deepFish)
                {
                    f.buyToUnlock.alpha = 0f;
                }
            }
        }

        if (inWindow)
        {

            if (MyGame.CheckMouseInRectClick(close))
            {
                close.alpha = 0f;
                journal.alpha = 0f;
                inWindow = false;
                foreach (Fish f in freshFish)
                {
                    f.buyToUnlock.alpha = 1f;
                }
                foreach (Fish f in seaFish)
                {
                    f.buyToUnlock.alpha = 1f;
                }
                foreach (Fish f in deepFish)
                {
                    f.buyToUnlock.alpha = 1f;
                }
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

