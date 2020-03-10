﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Repository.Entities
{
    public class Funcionario
    {
        public int IdFuncionario { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }
        public int IdSetor { get; set; }
        public int IdFuncao { get; set; }

        public Setor Setor { get; set; }
        public Funcao Funcao { get; set; }

    }
}
