using System.ComponentModel.DataAnnotations;

namespace Gerenciador.Domain.Shared
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
