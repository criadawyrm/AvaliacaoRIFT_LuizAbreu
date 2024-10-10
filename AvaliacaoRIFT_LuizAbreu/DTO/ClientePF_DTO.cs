using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientePF_DTO
    {
        public int IdClientePF { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNascimento { get; set; }
        public string RG { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string StatusRegistro { get; set; }
    }
}
