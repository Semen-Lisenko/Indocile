public class UserLogs
{
    public struct Resources
    {
        public string energyHoney;
        public string buildHoney;
        public string eatHoney;
        public string crypt;
        public string ether;
        public string money;
        public static readonly Resources nothingChange = new Resources("", "", "", "", "", "");
        public Resources(string EnergyHoney,string BuildHoney,string EatHoney,string Crypt,string Ether,string Money)
        {
            energyHoney = EnergyHoney;
            buildHoney = BuildHoney;
            eatHoney = EatHoney;
            crypt = Crypt;
            ether = Ether;
            money = Money;
        }
    }
    public string comment;
    public string player_name;
    public Resources resources;
}
