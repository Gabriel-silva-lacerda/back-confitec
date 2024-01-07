using System.ComponentModel.DataAnnotations;
using ConfitecWeb.Enums;

namespace ConfitecWeb.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime Data_nascimento { get; set; }

        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
