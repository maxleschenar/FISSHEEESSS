using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine;
public class Fish : Sprite
{
    List<Food> foodList;

    Vec2 _position;
    public Vec2 velocity;
    public Vec2 currentPoint = new Vec2(0, 0);
    public Vec2 foodPoint = new Vec2(0, 0);
    float _radius;
    string name;
    string description;

    public Fish(string path, string name, string description, Vec2 position) : base(path)
    {
        SetXY(position.x, position.y);
        SetScaleXY(0.08f);
        this.name = name;
        this.description = description;
        SetOrigin(width / 2, height / 2);
        _position = new Vec2(200, 300);
        _radius = width / 2;
        foodList = new List<Food>();
        Console.WriteLine(name);
        Console.WriteLine(description);

    }
    public void AddFood(Food food)
    {
        foodList.Add(food);
    }
    public void RemoveFood(Food food)
    {
        foodList.Remove(food);
    }
    private bool isFoodPresent()
    {
        if (foodList.Count == 0) return false;
        else return true;
    }
    void UpdateScreenPosition()
    {
        x = _position.x;
        y = _position.y;
    }
    void calcDistToPoint()
    {
        if (currentPoint.x != 0 && currentPoint.y != 0)
        {
            velocity.SetXY(0, 0);
            if (isFoodPresent())
            {
                calcNearestFood();
            }
            Vec2 deltaVector = currentPoint - _position;

            if (deltaVector.Magnitude() <= 0.5f)
            {
                currentPoint.SetXY(0, 0);
                if (isFoodPresent())
                {
                    if (currentFood != null)
                    {
                        RemoveFood(currentFood);
                        currentFood.LateDestroy();
                    }

                }
            }
            else
            {
                deltaVector.Normalize();
                //deltaVector *= 0.2f;
                velocity += deltaVector;
            }

        }
        else
        {
            if (isFoodPresent())
            {
                calcNearestFood();
namespace GXPEngine
{
    class DrawFish: Sprite
    {
        List<Food> foodList;

        Vec2 _position;
        public Vec2 velocity;
        public Vec2 currentPoint = new Vec2(0, 0);
        public Vec2 foodPoint = new Vec2(0, 0);
        float _radius;
        public DrawFish(): base("colors.png")
        {
            SetOrigin(width / 2, height / 2);
            _position = new Vec2(200, 300);
            _radius = width / 2;
            foodList = new List<Food>();

        }

        public void AddFood(Food food)
        {
            foodList.Add(food);
        }
        public void RemoveFood(Food food)
        {
            foodList.Remove(food);
        }
        private bool isFoodPresent()
        {
            if (foodList.Count == 0) return false;
            else return true;
        }
        void UpdateScreenPosition()
        {
            x = _position.x;
            y = _position.y;
        }
        void calcDistToPoint()
        {
            if (currentPoint.x != 0 && currentPoint.y != 0)
            {
                velocity.SetXY(0, 0);
                if (isFoodPresent())
                {
                    calcNearestFood();
                }
                Vec2 deltaVector = currentPoint - _position;

                if (deltaVector.Magnitude() <= 0.5f)
                {
                    currentPoint.SetXY(0, 0);
                    if (isFoodPresent())
                    {
                        if (currentFood != null)
                        {
                            RemoveFood(currentFood);
                            currentFood.LateDestroy();
                        }

                    }
                }
                else
                {
                    deltaVector.Normalize();
                    //deltaVector *= 0.2f;
                    velocity += deltaVector;
                }

            }
            else
            {
                currentPoint.SetXY(Utils.Random(50, game.width - 50), Utils.Random(_position.y - 100, _position.y + 100));
            }
        }
    }

    private void calcNearestFood()
    {
        float minDist = game.width;
        foreach (Food food in foodList)
        {
            if ((food._position - _position).Magnitude() < minDist)
            {
                minDist = (food._position - _position).Magnitude();
                currentPoint = food._position;
                currentFood = food as Food;
            }
        }
    }

    Food currentFood;
    void move()
    {
        calcDistToPoint();
        _position += velocity;
        UpdateScreenPosition();
    }
    void Update()
    {
        // Console.WriteLine(currentPoint);

        move();
    }
}


                if (isFoodPresent())
                {
                    calcNearestFood();

                }
                else
                {
                    currentPoint.SetXY(Utils.Random(50, game.width - 50), Utils.Random(_position.y - 100, _position.y + 100));
                }
            }
        }

        private void calcNearestFood()
        {
            float minDist = game.width;
            foreach (Food food in foodList)
            {
                if ((food._position - _position).Magnitude() < minDist)
                {
                    minDist = (food._position - _position).Magnitude();
                    currentPoint = food._position;
                    currentFood = food as Food;
                }
            }
        }

        Food currentFood;
        void move()
        {
            calcDistToPoint();
            _position += velocity;
            UpdateScreenPosition();
        }
        void Update()
        {
           // Console.WriteLine(currentPoint);

            move();
        }
    }
}