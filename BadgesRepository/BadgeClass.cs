using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class Badge
    {
        public Badge() { }

        public Badge(int badgeID, List<string> doorNames)
        {
            BadgeID = badgeID;
            DoorNames = doorNames;
        }

        public int BadgeID { get; set; }
        public List<string> DoorNames { get; set; }

    }
}
