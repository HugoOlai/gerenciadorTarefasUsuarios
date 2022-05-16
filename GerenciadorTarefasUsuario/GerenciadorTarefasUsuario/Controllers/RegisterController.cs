using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Models;
using GerenciadorTarefasUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GerenciadorTarefasUsuario.Controllers
{    
    public class RegisterController : Controller
    {
        private readonly IRegisterRepository registerRepository;
       
        public RegisterController(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        
        public IActionResult Index(int UserId)
        {
            if(UserId != 0)
            {
                Register UserFound = registerRepository.getUser(UserId);

                if (UserFound == null)
                    return StatusCode(404);

                if (UserFound.permissoes != "administrador")
                    return StatusCode(403);
            }

            return View();

        }

        [HttpPost]
        public IActionResult saveUser(User User)
        {
            registerRepository.SaveUser(new Register(User.Nome, User.Email, User.permissoes, User.senha));            
            return View();
        }
    }
}
