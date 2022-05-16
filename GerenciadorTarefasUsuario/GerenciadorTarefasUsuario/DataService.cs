using backGerenciadorTarefasUsuario;
using GerenciadorTarefasUsuario.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using static GerenciadorTarefasUsuario.Repositories.RegisterRepository;

namespace GerenciadorTarefasUsuario
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IRegisterRepository registerRepository;
        public DataService(ApplicationContext contexto, IRegisterRepository registerRepository)
        {
            this.contexto = contexto;
            this.registerRepository = registerRepository;
        }

        public void InicializaDB()
        {
            contexto.Database.EnsureCreated();
            List<User> users = getUser();
            registerRepository.SaveProdutos(users);
        }      

        private static List<User> getUser()
        {
            var json = File.ReadAllText("usuarios.json");
            var users = JsonConvert.DeserializeObject<List<User>>(json);
            return users;
        }

        
    }
}
