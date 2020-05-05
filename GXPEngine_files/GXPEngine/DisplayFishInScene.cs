using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GXPEngine
{
    class DisplayFishInScene : GameObject
    {
        Fish fish1Scene1;
        Fish fish2Scene1;
        Fish fish3Scene1;
        Fish fish4Scene1;
        Fish fish5Scene1;
        Fish fish1Scene2;
        Fish fish2Scene2;
        Fish fish3Scene2;
        Fish fish4Scene2;
        Fish fish5Scene2;
        public DisplayFishInScene(int sceneNumber,List<Food> foodList,List<Fish> fishListPerScene)
        {
            switch (sceneNumber)
            {
                case 1:
                    loadScene1(foodList, fishListPerScene);
                    break;
                case 2:
                    loadScene2(foodList, fishListPerScene);
                    break;

            }

        }

        void loadScene1(List<Food> foodList, List<Fish> fishListPerScene)
        {
             fish1Scene1=new Fish(foodList);
             fish2Scene1=new Fish(foodList);
             fish3Scene1=new Fish(foodList);
             fish4Scene1=new Fish(foodList);
             fish5Scene1=new Fish(foodList);
            fishListPerScene.Add(fish1Scene1);
            fishListPerScene.Add(fish2Scene1);
            fishListPerScene.Add(fish3Scene1);
            fishListPerScene.Add(fish4Scene1);
            fishListPerScene.Add(fish5Scene1);
        }
        void loadScene2(List<Food> foodList, List<Fish> fishListPerScene)
        {
            fish1Scene2 = new Fish(foodList);
            fish2Scene2 = new Fish(foodList);
            fish3Scene2 = new Fish(foodList);
            fish4Scene2 = new Fish(foodList);
            fish5Scene2 = new Fish(foodList);
            fishListPerScene.Add(fish1Scene2);
            fishListPerScene.Add(fish2Scene2);
            fishListPerScene.Add(fish3Scene2);
            fishListPerScene.Add(fish4Scene2);
            fishListPerScene.Add(fish5Scene2);
        }
    }
}
