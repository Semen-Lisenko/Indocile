using System;
public class Helper
{
    [Serializable]
    public struct Resources
    {
        public int energyHoney;
        public int buildHoney;
        public int eatHoney;
        public int crypt;
        public int ether;
        public int money;
        public Resources(int EnergyHoney, int BuildHoney, int EatHoney, int Crypt, int Ether, int Money)
        {
            energyHoney = EnergyHoney;
            buildHoney = BuildHoney;
            eatHoney = EatHoney;
            crypt = Crypt;
            ether = Ether;
            money = Money;
        }
    }
    public Resources resources;
}
