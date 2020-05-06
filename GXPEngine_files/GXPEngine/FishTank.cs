using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class FishTank : GameObject
{
    Sprite tank;
    List<Food> foods;
    public Sprite leftArrow, rightArrow;
    Fish fish;
    bool spongeOnScreen;
    Level level;
    int id;
    int timer;

    public FishTank(string path, int id, Level level) : base()
    {
        SetupTank(path, id, level);
    }

    void Update()
    {
        MakeFood();
        MakeDirt();
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
        spongeOnScreen = false;
        timer = 1000;
        tank = new Sprite(path);
        foods = new List<Food>();
        fish = new Fish(foods);
        leftArrow = new Sprite("leftArrow.jpg");
        rightArrow = new Sprite("rightArrow.jpg");
        leftArrow.SetScaleXY(0.3f);
        rightArrow.SetScaleXY(0.3f);
        leftArrow.SetXY(50, game.height - leftArrow.height);
        rightArrow.SetXY(game.width - (rightArrow.width + 50), game.height - rightArrow.height);
        AddChild(tank);
        AddChild(leftArrow);
        AddChild(rightArrow);
        AddChild(fish);
    }

    void MakeFood()
    {
        if (Input.GetMouseButtonDown(button: 0))
        {
            Food food = new Food();
            AddChild(food);
            foods.Add(food);
            //fish1.AddFood(food);
            //fish2.AddFood(food);

        }
    }

    void MakeDirt()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Dirt dirt = new Dirt();
            level.GetSponge().addDirt(dirt);
            AddChild(dirt);
            timer = 1000;
        }
    }

   

    public int GetID()
    {
        return id;
    }
}

