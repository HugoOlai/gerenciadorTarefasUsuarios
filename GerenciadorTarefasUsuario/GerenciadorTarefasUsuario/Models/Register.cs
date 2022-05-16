using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backGerenciadorTarefasUsuario
{
    public class Register
    {
        public Register(string nome, string email, string permissoes, string senha)
        {
            this.nome = nome;
            Email = email;
            this.permissoes = permissoes;
            this.senha = senha;
        }

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string nome { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string permissoes { get; set; }

        [Required]
        [StringLength(30)]
        public string senha { get; set; }

        public List<Task> task { get; private set; } = new List<Task>();



    }
}
