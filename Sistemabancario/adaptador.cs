using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class adaptador : Iretiro
    {
 
        cuenta_super funciones = new cuenta_super();

        public void apertura()
        {
            funciones.apertura();

        }

        public void depositos()
        {
            funciones.depositos();

        }

        public void retiros()
        {
            funciones.validar_retiro();
        }


        public void consulta()
        {

            funciones.consulta();

        }

    }
}
