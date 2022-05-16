using System.ComponentModel.DataAnnotations;
namespace backGerenciadorTarefasUsuario
{
    public class Login
    {
        
        public string Type { get; set; }
        
        [Required(ErrorMessage ="Campo usuario � obrigat�rio")]
        public string User { get; set; }

        [Required(ErrorMessage = "Campo senha � obrigat�rio")]
        public string Password { get; set; }


        
    }
}