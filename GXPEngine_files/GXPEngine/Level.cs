using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using GXPEngine;
public class Level : GameObject
{
    List<FishTank> tanks;
    Sponge sponge;
    Button journalButton;
    Journal journal;
    int currentTank;
    bool spongeOnScreen;
    public Level() : base()
    {
        tanks = new List<FishTank>();
        currentTank = 0;
        journalButton = new Button(new Vec2(game.width / 2, 100), "journalbutton.png");
        journal = new Journal();
        sponge = new Sponge();
        spongeOnScreen = false;
        AddTank(new FishTank("1200-183414126-empty-aquarium-tank.jpg", tanks.Count, this));
        AddTank(new FishTank("empty_tank2.jpg", tanks.Count, this));
        AddTank(new FishTank("fishtank3.jpg", tanks.Count, this));
        AddChild(journalButton);
        AddChild(journal);
        foreach (FishTank tank in tanks)
        {
            if (tank.GetID() != currentTank)
            {
                tank.SetTankAlpha(0);
            }
        }
    }

    void Update()
    {
        FishTank tank = tanks[currentTank];
        MoveToAnotherTank();
        Console.WriteLine(tanks.Count);
        DisplaySponge();

        switch (currentTank)
        {
            case 0:
                tank.leftArrow.alpha = 0f;
                break;
            case 2:
                tank.rightArrow.alpha = 0f;
                break;
            default:
                tank.leftArrow.alpha = 1f;
                tank.rightArrow.alpha = 1f;
                break;
        }
    }

    void MoveToAnotherTank()
    {
        if (MyGame.CheckMouseInRect(tanks[currentTank].rightArrow) && currentTank < tanks.Count - 1 && !journal.isOpen) //checks the right arrow and if its not on the last tank
        {
            tanks[currentTank].SetTankAlpha(0);
            currentTank++;
            tanks[currentTank].SetTankAlpha(1);

        }
        if (MyGame.CheckMouseInRect(tanks[currentTank].leftArrow) && currentTank > 0 && !journal.isOpen) //checks the left arrow and if its not on the first tank
        {
            tanks[currentTank].SetTankAlpha(0);
            currentTank--;
            tanks[currentTank].SetTankAlpha(1);
        }
        if (MyGame.CheckMouseInRect(journalButton) && !journal.isOpen) //checks for opening the journal
        {
            journal.SetActive(true);
        }
    }

    void DisplaySponge()
    {
        if (Input.GetMouseButton(button: 1))
        {
            if (spongeOnScreen == false)
            {
                AddChild(sponge);
                spongeOnScreen = true;
            }
        }
        else
        {
            if (spongeOnScreen == true)
            {
                RemoveChild(sponge);
                spongeOnScreen = false;
            }
        }

    }

    public Sponge GetSponge()
    {
        return sponge;
    }

    void AddTank(FishTank tank)
    {
        AddChild(tank);
        tanks.Add(tank);
    }
}

