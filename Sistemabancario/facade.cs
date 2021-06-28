using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class facade
    {
        #region variables y conectar BD
        private cuenta_ahorro consultar;
        private cuenta_super consultarx;
        private prestamos pagarprestamo;
        private certificado consultarcerti;
        #endregion

        #region ahorro
        public void movil_ahorro()
        {
            Console.WriteLine("Seleccione el Tipo de Cuenta de ahorro para consultar\n" +
                                   "\n1.Cuenta de ahorro Normal" +
                                   "\n2.Cuenta de super ahorro\n");

            int option5 = 0;
            option5 = Convert.ToInt32(Console.ReadLine());

            if (option5 == 1)
            {
                Console.Clear();
                consultar = new cuenta_ahorro();
                consultar.consulta();
            }
            else if (option5 == 2)
            {
                Console.Clear();
                consultarx = new cuenta_super();
                consultarx.consulta();
            }
            else
            {

            }

        }
        #endregion

        #region prestamo
        public void movil_prestamo()
        {
            pagarprestamo = new prestamos();
            pagarprestamo.pagopresta();

        }
        #endregion

        #region certficado
        public void movil_certificados()
        {
            consultarcerti = new certificado();
            consultarcerti.consulta_interes();

        }
        #endregion


    }
}
