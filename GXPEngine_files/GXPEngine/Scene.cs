using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class Scene: GameObject
    {
        Fish fish1;
        Fish fish2;
        int timer=1000;
        Sponge sponge;
        public List<Food> foodList;

        public Scene()
        {
            foodList = new List<Food>();
             fish1 = new Fish(foodList);
             fish2 = new Fish(foodList);
            //AddChild(fish1);
            //AddChild(fish2);
            sponge = new Sponge();
        }
        void addFish()
        {
            if (fish1.isUnlocked == true)
            {
                if (fish1.isAdded == false)
                {
                    AddChild(fish1);
                    fish1.isAdded = true;
                }
            }
            if (fish2.isUnlocked == true)
            {
                if (fish2.isAdded == false)
                {
                    AddChild(fish2);
                    fish2.isAdded = true;
                }
            }
            if (Input.GetKeyDown(Key.Q))
            {
                fish1.isUnlocked = true;
            }
            if (Input.GetKeyDown(Key.E))
            {
                Console.WriteLine("fish2");
                fish2.isUnlocked = true;
            }
        }
        void makeFood()
        {
            if (Input.GetMouseButtonDown(button: 0))
            {
                Food food = new Food();
                AddChild(food);
                foodList.Add(food);
                //fish1.AddFood(food);
                //fish2.AddFood(food);

            }
        }
        void Update()
        {
            makeFood();
            makeDirt();
            displaySponge();
            addFish();
        }
        void makeDirt()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Dirt dirt = new Dirt();
                sponge.addDirt(dirt);
                AddChild(dirt);
                timer = 1000;
            }
        }
        bool spongeOnScreen = false;
        void displaySponge()
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
    }
}
