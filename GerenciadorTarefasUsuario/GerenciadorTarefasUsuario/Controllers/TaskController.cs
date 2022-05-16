using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Models;
using GerenciadorTarefasUsuario.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GerenciadorTarefasUsuario.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRegisterRepository registerRepository;

        public TaskController(IRegisterRepository registerRepository)
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

                if (UserFound.permissoes != "administrador")
                    return StatusCode(403);
            }

            return View(registerRepository.getTasks());

        }


        [HttpPost]
        public IActionResult saveTask(TaskInfo task)
        {
            registerRepository.SaveTask(new Task(0,task.nome, task.data, task.concluida, task.descricao));
            var listTask = registerRepository.getTasks();
            var taskSalva = new
            {
                id = listTask.Count,
                nome = task.nome,
                data = task.data,
                concluida = task.concluida,
                descricao = task.descricao

            };
            return Json(taskSalva);
        }

        [HttpPut]
        public IActionResult editTask(TaskInfo task)
        {
            registerRepository.EditTask(new Task(task.id, task.nome, task.data, task.concluida, task.descricao));
            var listTask = registerRepository.getTasks();
            var result = new { listTask };
            return Json(result.listTask);
        }

        [HttpDelete]
        public IActionResult deleteTask(string TaskId)
        {

            registerRepository.DeleteTask(Int32.Parse(TaskId));
            var listTask = registerRepository.getTasks();
            var result = new { listTask };
            return Json(result.listTask);
        }

        

    }
}
