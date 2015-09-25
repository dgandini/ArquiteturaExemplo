using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArquiteturaExemplo.Apresentacao.Web.ViewModels
{
    public class PedidoViewModel
    {
        [Key]
        public int IdPedido { get;  set; }
        [Required]
        public string Cliente { get;  set; }
        [Required]        
        public DateTime DataPedido { get;  set; }
        public string Status { get;  set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}