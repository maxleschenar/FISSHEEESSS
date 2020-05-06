using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{

   public class Fish: Sprite

    {
        public List<Food> foodList;
        public bool isAdded = false;
        public bool isUnlocked = false;
        Vec2 _position;
        public Vec2 velocity;
        public Vec2 currentPoint = new Vec2(0, 0);
        public Vec2 foodPoint = new Vec2(0, 0);
        float _radius;
        int isFishHungry = 10000;
        Sprite hungerIcon;

        public Sprite buyToUnlock;
        public Fish(List<Food> _foodList): base("colors.png")
        {
            foodList = _foodList;
            SetOrigin(width / 2, height / 2);
            _position = new Vec2(200, 300);
            _radius = width / 2;
            hungerIcon = new Sprite("square.png");

            buyToUnlock = new Sprite("square.png");
        }
        public void Unlock()
        {
            isUnlocked = true;
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
                if (isFishHungry <= 3000)
                {
                    if (isFoodPresent())
                    {
                        calcNearestFood();
                    }
                }
                Vec2 deltaVector = currentPoint - _position;

                if (deltaVector.Magnitude() <= 0.5f)
                {
                    currentPoint.SetXY(0, 0);
                    if (isFoodPresent())
                    {
                        if (currentFood != null&& isFishHungry <= 3000)
                        {
                            RemoveFood(currentFood);
                            currentFood.LateDestroy();
                            isFishHungry += 4000;
                            Console.WriteLine(isFishHungry);
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
                if (isFoodPresent())
                {
                    if (isFishHungry <= 3000)
                    {
                        calcNearestFood();
                    }
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
            isFishHungry -= Time.deltaTime;
            move();
            displayHungerIcon();

        }

        void displayHungerIcon()
        {
            if (isFishHungry <= 3000)
            {
                AddChild(hungerIcon);
            }
            else RemoveChild(hungerIcon);
        }
    }
}
