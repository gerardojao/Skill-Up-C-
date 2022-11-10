using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{

    public class POSTFixedTermDepositDTO
    {
        [Required(ErrorMessage = "Amount es requerido")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
