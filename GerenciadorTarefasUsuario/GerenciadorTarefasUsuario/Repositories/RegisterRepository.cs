using backGerenciadorTarefasUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorTarefasUsuario.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        //private readonly IHttpContextAccessor contextAccessor;
        private readonly ApplicationContext contexto;
        private readonly DbSet<Register> dbSet;
        private readonly DbSet<Task> dbTSet;

        public RegisterRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbSet = contexto.Set<Register>();
            dbTSet = contexto.Set<Task>();
            //this.contextAccessor = contextAccessor;
        }

        public IList<Register> getUsers()
        {
            return contexto.Set<Register>().ToList();
        }

        private Register get(int UserId)
        {
            return contexto.Set<Register>().FirstOrDefault(targetUser => targetUser.id == UserId);
        }

        private IList<Task> getTasks()
        {
            return contexto.Set<Task>().ToList();
        }
        public Register getUser(int UserId)
        {
            return get(UserId);
        }

        private Task getTask(int TaskId)
        {
            return contexto.Set<Task>().FirstOrDefault(targetTask => targetTask.id == TaskId);
        }


        public void Save(Register user)
        {
            
            dbSet.Add(new Register(user.nome, user.Email, user.permissoes, user.senha));
            contexto.SaveChanges();
        }
        public void SaveUser(Register User)
        {
            Save(User);
        }

        public void SaveProdutos(List<User> users)
        {
            foreach (var user in users)
            {
                if (!dbSet.Where(p => p.nome == user.Nome).Any())
                    dbSet.Add(new Register(user.Nome, user.Email, user.permissoes, user.senha));
            }

            contexto.SaveChanges();
        }

        public void Save(Task task)
        {
            dbTSet.Add(new Task(0,task.nome, task.data, task.concluida, task.descricao));

            contexto.SaveChanges();
        }
               
        void IRegisterRepository.SaveTask(Task task)
        {
            Save(task);
        }

        IList<Task> IRegisterRepository.getTasks()
        {
            return getTasks();
        }

        Task IRegisterRepository.getTask(int TaskId)
        {
            return getTask(TaskId);
        }

        private void Edit(Task task)
        {
            Task foundTask = contexto.Set<Task>().FirstOrDefault(targetTask => targetTask.id == task.id);
            foundTask.nome = task.nome;
            foundTask.data = task.data;
            foundTask.descricao = task.descricao;
            foundTask.concluida = task.concluida;
            contexto.SaveChanges();
        }

        void IRegisterRepository.EditTask(Task task)
        {
            Edit(task);
        }

        private void Delete(int TaskId)
        {
            Task foundTask = contexto.Set<Task>().FirstOrDefault(targetTask => targetTask.id == TaskId);
            contexto.Remove(foundTask);
            contexto.SaveChanges();
        }

        public void DeleteTask(int TaskId)
        {
            Delete(TaskId);
        }

        public class User
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string permissoes { get; set; }
            public string senha { get; set; }
        }
    }
}
