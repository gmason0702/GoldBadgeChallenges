using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesRepository
{
    public class Repository
    {
        //        create a new badge
        //       update doors on an existing badge.
        //     delete all doors from an existing badge.
        //show a list with all badge numbers and door access, like this:

        protected readonly Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>>();

        //CREATE
        public bool AddBadgeToDictionary(Badge badge)
        {
            Dictionary<int, List<string>> dict = GetAllBadges();
            int badgeID = badge.BadgeID;
            List<string> doors = badge.DoorNames;

            int directoryLength = _badgeRepo.Count();
            dict.Add(badgeID, doors);
            bool wasBadgeAdded = directoryLength + 1 == _badgeRepo.Count();
            return wasBadgeAdded;

        }
        //READ
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepo;
        }

        public List<string> GetBadgeByBadgeID(int badgeID)
        {
            //var newDictionary = new Dictionary<int, List<string>>();
            List<string> doors;
            if (_badgeRepo.TryGetValue(badgeID, out doors))
            {
                return doors;
            }
            return null;
        }
        //UPDATE
        public void UpdateExistingBadge(int badgeID, string newDoor)
        {
            foreach (int id in _badgeRepo.Keys)
            {
                if (badgeID==id)
                {
                    _badgeRepo[id].Add(newDoor);
                }
            }
        }
        //DELETE
        public void RemoveDoorFromBadge(int badgeID, string door)
        {
            foreach (int ID in _badgeRepo.Keys)
            {
                if (badgeID==ID)
                {
                    List<string> doors = _badgeRepo[ID];
                    doors.Remove(door);
                }
            }
        }
        public void RemoveAllDoorsFromBadge(int badgeID)
        {
            foreach (int ID in _badgeRepo.Keys)
            {
                if (badgeID == ID)
                {
                    List<string> doors = _badgeRepo[ID];
                    doors.Clear();
                }
            }
        }
    }
}
