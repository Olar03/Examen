using System.ComponentModel.DataAnnotations;


namespace Examen.Data.Entities
{
    public class Ticket
    {

        public int Id { get; set; }
        
        [Display(Name = "Usado")]
        public bool WasUsed { get; set; }

        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]       
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        public string Name { get; set; }

        [Display(Name = "Fecha Uso")]
        public DateTime? Date { get; set; }

        [Display(Name = "Entrada")]
        public Entrance? Entrance { get; set; }

    }
}
