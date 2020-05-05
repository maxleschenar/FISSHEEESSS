using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Journal : GameObject
{
    Sprite journal, close;
    List<Fish> fishSprites;
    List<Sprite> buttons;
    public bool isOpen;
    public bool inWindow;
    public Journal() : base()
    {
        SetupJournal();
    }

    void Update()
    {
        if (MyGame.CheckMouseInRect(close) && isOpen && !inWindow)
        {
            SetActive(false);
        }
        foreach(Fish fish in fishSprites)
        {
            if(MyGame.CheckMouseInRect(fish) && isOpen)
            {
                CreateFishWindow(new FishWindow(fish, this));
                inWindow = true;
            }
        }
    }

    void AddButton(Sprite sprite, float x, float y)
    {
        sprite.SetXY(x, y);
        AddChild(sprite);
        buttons.Add(sprite);
    }

    void AddFish(Fish fish)
    {
        AddChild(fish);
        fishSprites.Add(fish);
    }

    void CreateFishWindow(FishWindow window)
    {
        AddChild(window);
    }

    void SetupJournal()
    {
        SetupLists();
        journal = new Sprite("journalitself.png");
        close = new Sprite("jurnalClose.png");
        close.SetXY(journal.x + journal.width - 100, journal.y + 150);
        journal.SetOrigin(journal.width / 2, journal.height / 2);
        journal.SetXY(game.width / 2, game.height / 2);   
        journal.alpha = 0f;
        close.alpha = 0f;
        isOpen = false;
        inWindow = false;
        buttons.Add(close);
        AddChild(journal);
        AddChild(close);
        for(int i = 0; i < 3; i++)
        {
            AddButton(new Sprite("group1.png"), 150, 250 + 200 * i);
        }
        for(int i = 0; i < 5; i++)
        {
            AddFish(new Fish("Fish-Transparent-PNG.png", "dis fi6", "dis is de fi6", new Vec2(journal.x + 100 * i, journal.y)));
        }
    }

    void SetupLists()
    {
        fishSprites = new List<Fish>();
        buttons = new List<Sprite>();
    }

    public void SetActive(bool isOpen)
    {
        this.isOpen = isOpen;
        if (isOpen)
        {
            journal.alpha = 1f;
            foreach(Sprite button in buttons)
            {
                button.alpha = 1f;
            }
            foreach(Fish fish in fishSprites)
            {
                fish.alpha = 1f;
            }
        }
        if (!isOpen)
        {
            journal.alpha = 0f;
            foreach(Sprite button in buttons)
            {
                button.alpha = 0f;
            }
            foreach(Fish fish in fishSprites)
            {
                fish.alpha = 0f;
            }
        }
    }
}

