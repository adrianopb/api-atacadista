﻿using System.ComponentModel.DataAnnotations;

namespace ApiAtacadista.Enum
{
    public enum StatusPedido
    { 
        [Display(Name="Solicitado")]
        Solicitado,
        [Display(Name="Em fabricação")]
        EmFabricacao,
        [Display(Name="Finalizado")]
        Finalizado, 
        [Display(Name="Despachado")]
        Despachado
    }
}