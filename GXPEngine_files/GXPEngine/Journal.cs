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
    List<Sprite> fishSprites;
    List<Button> buttons;
    Canvas canvas, descriptionCanvas;
    Level level;

    public bool inWindow;
    public Journal(Level level) : base()
    {
        this.level = level;
        freshFish = new List<Fish>();
        seaFish = new List<Fish>();
        deepFish = new List<Fish>();
        buttons = new List<Button>();
        fishSprites = new List<Sprite>();
        journalButton = new Sprite("journalbutton.png");
        journalButton.SetXY(game.width - 250, game.height - 200);
        close = new Sprite("jurnalClose.png");
        journal = new Sprite("journalitself.png");
        journal.SetXY(50, 0);
        close.SetXY(journal.x + journal.width - close.width, journal.y);
        canvas = new Canvas(journal.width, journal.height);
        descriptionCanvas = new Canvas(500, 500);
        
        AddChild(journalButton);
        AddChild(journal);
        AddChild(close);
        AddChild(canvas);
        AddChild(descriptionCanvas);
        journal.alpha = 0f;
        close.alpha = 0f;
        titleFont = new Font("Times New Roman", 24);
        textFont = new Font("Times New Roman", 16);
        inWindow = false;
    }

    void Update()
    {
        canvas.SetXY(journal.x, journal.y);
        descriptionCanvas.SetXY(journal.x + 450, journal.y + 150);
        if (!inWindow)
        {
            if (MyGame.CheckMouseInRectClick(journalButton))
            {
                journal.alpha = 1f;
                close.alpha = 1f;
                inWindow = true;
                for(int i = 0; i < buttons.Count; i++)
                {
                    Button button = buttons[i];
                    button.SetXY(journal.x + 50, journal.y + 100 + 50 * i);
                    if (!HasChild(button))
                    {
                        AddChild(button);
                    }
                    button.isActive = true;
                }
            }
        }

        if (inWindow)
        {
            canvas.graphics.DrawString("FRESH WATER FISH", titleFont, Brushes.Black, journal.x, journal.y + 50);
            for(int i = 0; i < freshFish.Count; i++)
            {
                if (MyGame.CheckMouseInRectClick(buttons[i]))
                {
                    fishSprites[i].alpha = 1f;
                    if (i > 0)
                    {
                        fishSprites[i - 1].alpha = 0f;
                    }
                    descriptionCanvas.graphics.Clear(Color.Transparent);
                    descriptionCanvas.graphics.DrawString(freshFish[i].GetFishDescription(), textFont, Brushes.Black, 0, 0);
                    
                }
            }
            if (MyGame.CheckMouseInRectClick(close))
            {
                canvas.graphics.Clear(Color.Transparent);
                close.alpha = 0f;
                journal.alpha = 0f;
                inWindow = false;
                descriptionCanvas.graphics.Clear(Color.Transparent);
                foreach(Sprite spr in fishSprites)
                {
                    spr.alpha = 0f;
                }
                foreach(Button button in buttons)
                {
                    RemoveChild(button);
                }
            }
        }
    }

    public void AddFish(Fish fish)
    {
        Button button = new Button(new Vec2(0, 0), 300, 30, fish.GetFishName());
        Sprite spr = new Sprite(fish.GetFishName() + "-icon.png");
        spr.SetXY(journal.x + 400, journal.y + 300);
        spr.SetScaleXY(0.2f);
        spr.alpha = 0f;
        buttons.Add(button);
        fishSprites.Add(spr);
        AddChild(spr);
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

