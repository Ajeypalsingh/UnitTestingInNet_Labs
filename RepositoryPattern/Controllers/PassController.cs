using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.BusinessLogicLayer;
using RepositoryPattern.Models;

namespace RepositoryPattern.Controllers
{
    public class PassController : Controller
    {
        private readonly PassLogic _passLogic;

        public PassController(PassLogic passLogic)
        {
            _passLogic = passLogic;
        }

        [HttpGet]
        public IActionResult GetPass(int id)
        {
            var pass = _passLogic.GetPass(id);
            if (pass == null)
            {
                return NotFound();
            }
            return View(pass);
        }

        [HttpGet]
        public IActionResult GetAllPasses()
        {
            var passes = _passLogic.GetAllPasses();
            return View(passes);
        }

        [HttpPost]
        public IActionResult CreatePass(string purchaser, bool premium, int capacity)
        {
            var newPass = _passLogic.CreatePass(purchaser, premium, capacity);
            return View(newPass);
        }

        [HttpPut]
        public IActionResult UpdatePass([FromBody] Pass pass)
        {
            _passLogic.UpdatePass(pass);
            return View();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePass(int id)
        {
            _passLogic.DeletePass(id);
            return View();
        }
    }
}
