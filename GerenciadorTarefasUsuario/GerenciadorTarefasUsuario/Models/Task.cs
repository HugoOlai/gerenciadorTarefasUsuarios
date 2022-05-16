using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backGerenciadorTarefasUsuario
{
    public class Task
    {
        public Task(int id, string nome, string data, string concluida, string descricao)
        {
            this.id = id;
            this.nome = nome;
            this.data = data;
            this.concluida = concluida;
            this.descricao = descricao;
        }

        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        [StringLength(8)]
        public string data { get; set; }

        [Required]
        public string descricao { get; set; }

        [Required]
        public string concluida { get; set; }

        public virtual Register user { get; set; }

    }
}
