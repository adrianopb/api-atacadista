using System.ComponentModel.DataAnnotations;

namespace ApiAtacadista.Enum
{
    public enum StatusOrcamento
    {
        [Display(Name="Pendente")]
        Pendente,
        [Display(Name="Aceito")]
        Aceito,
        [Display(Name="Rejeitado")]
        Rejeitado
    }
}