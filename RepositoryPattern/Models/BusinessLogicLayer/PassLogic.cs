using RepositoryPattern.Data;

namespace RepositoryPattern.Models.BusinessLogicLayer
{
    public class PassLogic
    {
        private readonly IRepository<Pass> _passRepository;

        public PassLogic(IRepository<Pass> passRepository)
        {
            _passRepository = passRepository;
        }

        public Pass GetPass(int id)
        {
            return _passRepository.Get(id);
        }

        public ICollection<Pass> GetAllPasses()
        {
            return _passRepository.GetAll();
        }

        public Pass CreatePass(string purchaser, bool premium, int capacity)
        {
            Pass newPass = new Pass
            {
                Purchaser = purchaser,
                Premium = premium,
                Capacity = capacity
            };

            _passRepository.Create(newPass);

            return newPass;
        }

        public Pass UpdatePass(Pass pass)
        {
            _passRepository.Update(pass);
            return pass;
        }

        public void DeletePass(int passId)
        {
            Pass pass = _passRepository.Get(passId);
            if (pass != null)
            {
                _passRepository.Delete(pass);
            }
        }
    }

}
