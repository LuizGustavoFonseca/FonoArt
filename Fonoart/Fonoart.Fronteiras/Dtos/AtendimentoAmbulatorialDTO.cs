﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fronteiras.Dtos
{
    public class AtendimentoAmbulatorialDTO : AtendimentoDTO
    {
        public string Quarto { get; set; }
        public DateTime DataInternacao { get; set; }
    }
}
