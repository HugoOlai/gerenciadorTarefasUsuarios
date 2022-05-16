using backGerenciadorTarefasUsuario;
using System.Collections.Generic;

namespace GerenciadorTarefasUsuario.Repositories
{
    public interface IRegisterRepository
    {
        void SaveProdutos(List<RegisterRepository.User> users);
        void SaveUser(Register User);
        IList<Register> getUsers();
        Register getUser(int UserId);
        void SaveTask(Task task);
        IList<Task> getTasks();
        Task getTask(int TaskId);
        void EditTask(Task task);
        void DeleteTask(int TaskId);
    }
}