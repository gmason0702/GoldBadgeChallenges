using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Repo
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claim> _claimRepo = new Queue<Claim>();

        //CREATE

        public bool AddClaimToDirectory(Claim claim)
        {
            int directoryLength = _claimRepo.Count();
            _claimRepo.Enqueue(claim);
            bool wasClaimAdded = directoryLength + 1 == _claimRepo.Count();
            return wasClaimAdded;
        }

        //READ
        public Queue<Claim> GetAllClaims()
        {
            return _claimRepo;
        }
        public Claim PeekQueue()
        {
            return _claimRepo.Peek();
        }

        public  Claim GetNextClaim()
        {      
            return _claimRepo.Dequeue();
        }

    }
    
}
