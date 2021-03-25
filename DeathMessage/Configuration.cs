using DeathMessage.Serialization;
using Rocket.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeathMessage
{
    public class Configuration : IRocketPluginConfiguration
    {

        public ExpForKills left_foot;
        public ExpForKills left_leg;
        public ExpForKills right_foot;
        public ExpForKills right_leg;

        public ExpForKills left_hand;
        public ExpForKills left_arm;
        public ExpForKills right_hand;
        public ExpForKills right_arm;

        public ExpForKills left_back;
        public ExpForKills right_back;
        public ExpForKills left_front;
        public ExpForKills right_front;

        public ExpForKills spine;
        public ExpForKills skull;



        public void LoadDefaults()
        {
            left_foot = new ExpForKills(5);
            left_leg = new ExpForKills(5);
            right_foot = new ExpForKills(5);
            right_leg = new ExpForKills(5);

            left_hand = new ExpForKills(5);
            left_arm = new ExpForKills(5);
            right_hand = new ExpForKills(5);
            right_arm = new ExpForKills(5);

            left_back = new ExpForKills(15);
            right_back = new ExpForKills(15);
            left_front = new ExpForKills(20);
            right_front = new ExpForKills(20);

            spine = new ExpForKills(20);
            skull = new ExpForKills(30);
        }
    }
}
