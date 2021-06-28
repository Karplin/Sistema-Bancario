using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class tarjeta_credito
    {
     
        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemabancario;Integrated Security=True");
        SqlCommand comando;

        public void expedicion()
        {
            int numerotarjeta = 0;
            int limite = 0;

            Console.WriteLine("El NUMERO DE TARJETA SERA CREADO AUTOMATICAMENTE");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el limite a solicitar");
            limite = Convert.ToInt32(Console.ReadLine());

            var random = new Random();
            var rango = random.Next(1000, 9999);
            numerotarjeta = rango;

            cone.Open();
            comando = new SqlCommand($"INSERT INTO TARJETA VALUES('{numerotarjeta}','{limite}')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

            Console.WriteLine("Su numero de tarjeta es: " + numerotarjeta);


        }

        public void consumos()
        {
            Console.WriteLine("Coloque el numero de tarjeta");
            int numerotarjetax = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a consumir: ");
            int balance_consumido = Convert.ToInt32(Console.ReadLine());

            int totalx = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT limite FROM TARJETA WHERE numero_tarjeta ={numerotarjetax}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                totalx = int.Parse(reader["limite"].ToString());
                cone.Close();
                cone.Open();
                totalx -= balance_consumido;
                string query = $"UPDATE TARJETA SET limite = {totalx} WHERE numero_tarjeta = {numerotarjetax}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();

                Console.WriteLine("---------     CONSUMO TARJETA DE CREDITO     ---------------");
                Console.WriteLine("Monto Consumido:  " + balance_consumido);
                Console.WriteLine("Monto Disponible: " + totalx + " pesos");
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el consumo");

            }

       

            cone.Close();



        }

        public void pagos()
        {
            Console.WriteLine("Coloque el numero de tarjeta");
            int numerotarjetaz = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a pagar: ");
            int pagarmonto = Convert.ToInt32(Console.ReadLine());

            int totaly = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT limite FROM TARJETA WHERE numero_tarjeta ={numerotarjetaz}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                totaly = int.Parse(reader["limite"].ToString());
                cone.Close();
                cone.Open();
                totaly += pagarmonto;
                string query = $"UPDATE TARJETA SET limite = {totaly} WHERE numero_tarjeta = {numerotarjetaz}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();

                Console.WriteLine("---------     CONSUMO TARJETA DE CREDITO     ---------------");
                Console.WriteLine("Monto pagado:  " + pagarmonto);
                Console.WriteLine("Monto Disponible: " + totaly + " pesos");
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el consumo");

            }

       

            cone.Close();


        }


    }
}
