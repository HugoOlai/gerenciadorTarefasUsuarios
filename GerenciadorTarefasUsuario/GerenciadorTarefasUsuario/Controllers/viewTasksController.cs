using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Models;
using GerenciadorTarefasUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciadorTarefasUsuario.Controllers
{
    public class viewTasksController : Controller
    {
        private readonly IRegisterRepository registerRepository;

        public viewTasksController(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public IActionResult Index(int UserId)
        {
            if (UserId != 0)
            {
                Register UserFound = registerRepository.getUser(UserId);

                if (UserFound == null)
                    return StatusCode(404);
            }

            return View(registerRepository.getTasks());

        }
    }
}
