using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class prestamos
    {

        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemabancario;Integrated Security=True");
        SqlCommand comando;

        public void solicitud()
        {
            int numeropresta = 0;
            int montopresta = 0;
            int tasa = 0;

            Console.WriteLine("El NUMERO DE PRESTAMO SERA CREADO AUTOMATICAMENTE");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el monto a solicitar");
            montopresta = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la tasa a solicitar");
            tasa = Convert.ToInt32(Console.ReadLine());

            var random = new Random();
            var rango = random.Next(1000, 9999);
            numeropresta = rango;

            cone.Open();
            comando = new SqlCommand($"INSERT INTO PRESTAMO VALUES('{numeropresta}','{montopresta}','{tasa}')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

            Console.WriteLine("Su numero de prestamo es: " + numeropresta);

        }


        public void pagopresta()
        {

            Console.WriteLine("Coloque el numero de prestamo");
            int prestanumero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a pagar: ");
            int monto_pago = Convert.ToInt32(Console.ReadLine());

            int total = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT monto FROM PRESTAMO WHERE numero_prestamo ={prestanumero}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                total = int.Parse(reader["monto"].ToString());
                cone.Close();
                cone.Open();
                total -= monto_pago;
                string query = $"UPDATE PRESTAMO SET monto = {total} WHERE numero_prestamo = {prestanumero}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();

                Console.WriteLine("---------     PAGO PRESTAMO     ---------------");
                Console.WriteLine("Dinero pagado:  " + monto_pago);
                Console.WriteLine("Su deuda queda en: " + total + " pesos");
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el pago");

            }

            cone.Close();

        }


    }
}
