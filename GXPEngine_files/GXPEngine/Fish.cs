﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{

    public class Fish : AnimationSprite

    {
        public List<Food> foodList;
        public bool isAdded = false;
        public bool isUnlocked = false;
        Vec2 _position;
        Vec2 velocity;
        Vec2 currentPoint = new Vec2(0, 0);
        Vec2 foodPoint = new Vec2(0, 0);
        float _radius;
        public int isFishHungry = 10000;
        Sprite hungerIcon;
        public int FishProgrss = 0;

        public int coinValue = 200;
        int timer;

        public string fishName;
        public int _frames;
            string description, type;

        public Sprite buyToUnlock;

        public Fish(List<Food> _foodList, int frames, string type, string fishName, string description) : base(fishName + ".png", frames, 1, frames)
        {
            foodList = _foodList;
            this.type = type;
            this.fishName = fishName;
            this.description = description;
            _frames = frames;
            SetOrigin(width / 2, height / 2);
            _position = new Vec2(Utils.Random(50, game.width - 200), Utils.Random(50, game.height - 200));
            _radius = width / 2;
            hungerIcon = new Sprite("square.png");
            timer = 100;
            buyToUnlock = new Sprite("square.png");
            this.x = Utils.Random(50, game.width - 50);
            this.y= Utils.Random(_position.y - 100, _position.y + 100);
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
            if (velocity.x < 0)
            {
                Mirror(true, false);
            }
            else Mirror(false, false);
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
                        if (currentFood != null && isFishHungry <= 3000)
                        {
                            RemoveFood(currentFood);
                            currentFood.LateDestroy();
                            isFishHungry += 4000;
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

        void CheckBoundaries()
        {
            if (_position.x + width / 2 > game.width || _position.x - width / 2 < 0)
            {
                velocity.x = -velocity.x;
            }
            if (_position.y - width / 2 < 0 || _position.y + width / 2 > game.height)
            {
                velocity.y = -velocity.y;
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

        void handleAnimation()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                NextFrame();
                timer = 100;
            }
        }

        void Update()
        {
            isFishHungry -= Time.deltaTime;
            handleAnimation();
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
        public string GetFishType()
        {
            return type;
        }

        public string GetFishName()
        {
            return fishName;
        }

        public string GetFishDescription()
        {
            return description;
        }

    }

}
