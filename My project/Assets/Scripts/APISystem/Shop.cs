public class Shop
{
    public struct Resources
    {
        public string shopHost;
        public int energyHoney;
        public int buildHoney;
        public int eatHoney;
        public int crypt;
        public int ether;
        public Resources(string ShopHost,int EnergyHoney, int BuildHoney, int EatHoney, int Crypt, int Ether)
        {
            shopHost = ShopHost;  
            energyHoney = EnergyHoney;
            buildHoney = BuildHoney;
            eatHoney = EatHoney;
            crypt = Crypt;
            ether = Ether;
        }
    }
    public string name = "";
    public Resources resources;
}
