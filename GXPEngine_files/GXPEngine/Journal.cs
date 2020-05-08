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
    Font titleFont, textFont;
    List<Fish> freshFish, seaFish, deepFish;
    List<Button> buttons;
    Canvas canvas;
    Level level;

    public bool inWindow;
    bool hasDescription;
    public Journal(Level level) : base()
    {
        this.level = level;
        freshFish = new List<Fish>();
        seaFish = new List<Fish>();
        deepFish = new List<Fish>();
        buttons = new List<Button>();
        journalButton = new Sprite("journalbutton.png");
        journalButton.SetXY(game.width - 250, game.height - 200);
        close = new Sprite("jurnalClose.png");
        journal = new Sprite("journalitself.png");
        journal.SetXY(100, 100);
        close.SetXY(journal.x + journal.width - close.width, journal.y);
        canvas = new Canvas(journal.width, journal.height);
        AddChild(journalButton);
        AddChild(journal);
        AddChild(close);
        AddChild(canvas);
        journal.alpha = 0f;
        close.alpha = 0f;
        titleFont = new Font("Times New Roman", 24);
        textFont = new Font("Times New Roman", 16);
        inWindow = false;
        hasDescription = false;
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
            canvas.graphics.DrawString("FRESH WATER FISH", titleFont, Brushes.Black, journal.x + 50, journal.y + 150);
            for(int i = 0; i < freshFish.Count; i++)
            {
                ShowNames(freshFish[i].GetFishName(), journal.x + 50, journal.y + 200 + i * 50);
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
        Button button = new Button(new Vec2(0, 0), 300, 30, fish.GetFishName());
        buttons.Add(button);
        button.isActive = false;
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

    void ShowNames(string name, float x, float y)
    {
        canvas.graphics.DrawString(name, SystemFonts.DefaultFont, Brushes.Black, x, y);
    }

}

