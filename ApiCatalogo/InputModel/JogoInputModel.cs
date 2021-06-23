using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogo.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O Nome do jogo deve conter entre 3 e 100 caracteres")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome da produtora deve conter entre 1 e 100 caracteres")]
        public string Producer { get; set; }
        
        [Required]
        [Range(1, 100, ErrorMessage = "O preço do jogo deve estar em um intervalo de 1 real até 1000 reais")]
        public double Price { get; set; }
    }
}
