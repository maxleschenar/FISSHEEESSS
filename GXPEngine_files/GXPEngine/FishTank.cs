using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class FishTank : GameObject
{
    Sprite tank;
    public Sprite leftArrow, rightArrow;
    Level level;
    int id;

    public FishTank(string path, int id, Level level) : base()
    {
        SetupTank(path, id, level);
    }

    void Update()
    {
        
    }

    public void SetTankAlpha(int alpha)
    {
        tank.alpha = alpha;
        rightArrow.alpha = alpha;
        leftArrow.alpha = alpha;
    }

    void SetupTank(string path, int id, Level level)
    {
        this.level = level;
        this.id = id;
        tank = new Sprite(path);
        leftArrow = new Sprite("leftArrow.jpg");
        rightArrow = new Sprite("rightArrow.jpg");
        leftArrow.SetScaleXY(0.3f);
        rightArrow.SetScaleXY(0.3f);
        leftArrow.SetXY(50, game.height - leftArrow.height);
        rightArrow.SetXY(game.width - (rightArrow.width + 50), game.height - rightArrow.height);
        AddChild(tank);
        AddChild(leftArrow);
        AddChild(rightArrow);
    }

    public int GetID()
    {
        return id;
    }
}

