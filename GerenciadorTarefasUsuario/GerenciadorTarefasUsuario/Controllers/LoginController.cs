using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefasUsuario.Controllers
{    
    public class LoginController : Controller
    {
        private readonly IRegisterRepository registerRepository;

        public LoginController(IRegisterRepository registerRepository)
        {
            this.registerRepository = registerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Login login)
        {
            string User = login.User;
            string Password = login.Password;
            string Permission = "";
            var response = new
            {
                controller = "TaskRegister",
                id = 0,
            };
            if (User.Contains("admin") && Password.Contains("admin"))
            {
                response = new
                {
                    controller = "TaskRegister",
                    id = 0,
                };
                return Json(response);
            }
            else
            {
                //Login loggedUser = new("hugo","11061993", "administrator");
                bool validatedUser = false;
                var teste = registerRepository.getUsers();
                foreach (var userCaught in registerRepository.getUsers())
                {
                    if (userCaught.nome == User && userCaught.senha == Password)
                    {
                        validatedUser = true;
                        Permission = userCaught.permissoes;
                        Permission.ToUpper();
                        response = new
                        {
                            controller = "TaskRegister",
                            id = userCaught.id,
                        };

                        if (Permission.Contains("administrador"))
                        {
                            response = new
                            {
                                controller = "TaskRegister",
                                id = userCaught.id
                            };
                        }
                        else
                        {
                            response = new
                            {
                                controller = "viewTasks",
                                id = userCaught.id
                            };
                        }
                    }
                }

                if (validatedUser)
                {
                    return Json(response); 
                }
                else
                {
                    return NotFound("Usuario não encontrado!");
                }

            }
        }
    }
}
