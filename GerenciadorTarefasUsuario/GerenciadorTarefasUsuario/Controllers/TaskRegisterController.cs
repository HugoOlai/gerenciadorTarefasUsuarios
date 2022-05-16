using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasUsuario.Controllers
{    
    public class TaskRegisterController : Controller
    {
        private readonly IRegisterRepository registerRepository;

        public TaskRegisterController(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public IActionResult Index(int UserId)
        {
            ViewData["id"] = UserId;
            return View();
        }       
    }
}
