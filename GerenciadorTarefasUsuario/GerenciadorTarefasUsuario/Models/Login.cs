using System.ComponentModel.DataAnnotations;
namespace backGerenciadorTarefasUsuario
{
    public class Login
    {
        
        public string Type { get; set; }
        
        [Required(ErrorMessage ="Campo usuario é obrigatório")]
        public string User { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        public string Password { get; set; }


        
    }
}