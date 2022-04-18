using System.ComponentModel.DataAnnotations;

namespace admCondominio.ViewModels
{
    public class CreateCondominioViewModel
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Bairro { get; set; }
    }
}