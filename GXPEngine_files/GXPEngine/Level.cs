using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;

public class Level : Sprite
{
    List<Button> buttons;
    List<Scene> scenes;
    Journal journal;
    public CurrencySystem currencySystem;
    public bool isInScene;
    public Level() : base("aquariums.png")
    {
        isInScene = false;
        buttons = new List<Button>();
        scenes = new List<Scene>();
        journal = new Journal();
        currencySystem = new CurrencySystem();
        AddButton(new Button(new Vec2(100, game.height / 2), "group1.png"));
        AddButton(new Button(new Vec2(game.width / 2 - 50, game.height / 2), "group1.png"));
        AddButton(new Button(new Vec2(game.width - 200, game.height / 2), "group1.png"));
        AddScene(new Scene("fishtanksample.png", currencySystem, this));
        AddScene(new Scene("empty_tank2.jpg", currencySystem, this));
        AddScene(new Scene("fishtank3.jpg", currencySystem, this));
        AddChild(journal);
    }

    void Update()
    {
        if (!isInScene)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                if (MyGame.CheckMouseInRect(buttons[i]))
                {
                    scenes[i].visible = true;
                    scenes[i].isActive = true;
                    isInScene = true;
                }
            }
        }
    }

    void AddScene(Scene scene)
    {
        AddChild(scene);
        scenes.Add(scene);
    }


    void AddButton(Button button)
    {
        AddChild(button);
        buttons.Add(button);
    }


}


