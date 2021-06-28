using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sistemabancario
{
    class cuenta_super
    {
        int balancex = 0;
        int validar = 0;
        int retirosuper = 0;
        int numerosuperx = 0;

        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemabancario;Integrated Security=True");
        SqlCommand comando;

        public void validar_retiro()
        {

            Console.WriteLine("Ingrese el numero de cuenta: ");
            numerosuperx = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a retirar: ");
            retirosuper = Convert.ToInt32(Console.ReadLine());

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM SUPER WHERE numero_cuenta ={numerosuperx}", cone);
            SqlDataReader reader = comando.ExecuteReader();


            if ( reader.Read())
            {
                validar = int.Parse(reader["balance"].ToString());
                validar = Convert.ToInt32(validar * 0.40);

                balancex = int.Parse(reader["balance"].ToString());

                if (retirosuper >= validar)
                {
                    Console.WriteLine("El monto es 40% o menos del balance de su cuenta, intente de nuevo retirando menos cantidad ");
                }
                else
                {
                    retirar();
                }
                 
            }

            else
            {
                Console.WriteLine("No se puede retirar, intente de nuevo");

            }
            
            cone.Close();

        }

        public void retirar()
        {
            cone.Close();
            cone.Open();
            balancex -= retirosuper;
            string query = $"UPDATE SUPER SET balance = {balancex} WHERE numero_cuenta = {numerosuperx}";
            comando = new SqlCommand(query, cone);
            comando.ExecuteNonQuery();

            Console.WriteLine("---------     RETIRO     ---------------");
            Console.WriteLine("Total de retiro:  " + retirosuper);
            Console.WriteLine("Balance: " + balancex);
            Console.WriteLine("-----------------------------------------");


        }

        public void apertura()
        {
            int balancesuper = 0;
            int numerosuper = 0;

            Console.WriteLine("El NUMERO DE CUENTA SERA CREADO AUTOMATICAMENTE");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el monto de apertura");
            int montosuper = Convert.ToInt32(Console.ReadLine());

            
            balancesuper = balancesuper + montosuper;

            var random = new Random();
            var rango = random.Next(1000, 9999);
            numerosuper = rango;

            cone.Open();
            comando = new SqlCommand($"INSERT INTO SUPER VALUES('{numerosuper}','{balancesuper}')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

            Console.WriteLine("Su número de cuenta es: " + numerosuper);

        }

        public void depositos()
        {
            Console.WriteLine("Ingrese el numero de cuenta: ");
            int numerosuper = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a depositar: ");
            int montosuper = Convert.ToInt32(Console.ReadLine());

            int balancesuper = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM SUPER WHERE numero_cuenta ={numerosuper}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                balancesuper = int.Parse(reader["balance"].ToString());
                cone.Close();
                cone.Open();
                balancesuper += montosuper;
                string query = $"UPDATE SUPER SET balance = {balancesuper} WHERE numero_cuenta = {numerosuper}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();

                Console.WriteLine("---------     DEPOSITO   ---------------");
                Console.WriteLine("Total de deposito:  " + montosuper);
                Console.WriteLine("Balance: " + balancesuper);
                Console.WriteLine("-----------------------------------------");

            }
            else
            {
                Console.WriteLine("No se puede actualizar");

            }


            cone.Close();

        }


        public void consulta()
        {

            Console.WriteLine("Ingrese el numero de cuenta: ");
            int cuentanumerox = Convert.ToInt32(Console.ReadLine());

            int balancez = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM super WHERE numero_cuenta ={cuentanumerox}", cone);

            SqlDataReader reader = comando.ExecuteReader();


            if (reader.Read())
            {
                balancez = int.Parse(reader["balance"].ToString());
                cone.Close();
                cone.Open();


                Console.WriteLine("---------     CONSULTA   ---------------");
                Console.WriteLine("Numero de cuenta:  " + cuentanumerox);
                Console.WriteLine("Su balance es: " + balancez);
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se puede encontrar la cuenta, intente de nuevo");

            }


            cone.Close();

        }
    }
}
