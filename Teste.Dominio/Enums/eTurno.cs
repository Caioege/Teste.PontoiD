using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Teste.Dominio.Enums
{
    public enum eTurno
    {
        [Description("Matutino")]
        Matutino = 0,

        [Description("Vespertino")]
        Vespertino = 1,

        [Description("Noturno")]
        Noturno = 2
    }
}
