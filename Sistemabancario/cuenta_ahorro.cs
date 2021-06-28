using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class cuenta_ahorro : Iretiro
    {

        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemabancario;Integrated Security=True");
        SqlCommand comando;


        //-------------------------------------------------APERTURA---------------------------------------
        public void apertura()
        {
            int numeroc = 0;
            int balancec = 0;
            int montoc = 0;
       
            
            Console.WriteLine("El NUMERO DE CUENTA SERA CREADO AUTOMATICAMENTE");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el monto de apertura");
            montoc = Convert.ToInt32(Console.ReadLine());

            balancec  = balancec + montoc;

            var random = new Random();
            var rango = random.Next(1000, 9999);
            numeroc = rango;

            cone.Open();
            comando = new SqlCommand($"INSERT INTO AHORRO VALUES('{numeroc}','{balancec}')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

            Console.WriteLine("Su número de cuenta es: "+ numeroc);

        }

        //-------------------------------------------------DEPOSITOS---------------------------------------
        public void depositos()
        {
         
            Console.WriteLine("Ingrese el numero de cuenta: ");
            int cuentanumero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a depositar: ");
            int montodepo = Convert.ToInt32(Console.ReadLine());

            int balancec=0; 

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM AHORRO WHERE numero_cuenta ={cuentanumero}", cone);

            SqlDataReader reader = comando.ExecuteReader();
          
            if (reader.Read())
            {
                balancec = int.Parse(reader["balance"].ToString());
                cone.Close();
                cone.Open();
                balancec += montodepo;
                string query = $"UPDATE AHORRO SET balance = {balancec} WHERE numero_cuenta = {cuentanumero}";
                comando = new SqlCommand(query,cone);
                comando.ExecuteNonQuery();


                Console.WriteLine("---------     DEPOSITO   ---------------");
                Console.WriteLine("Total de deposito:  " + montodepo);
                Console.WriteLine("Balance: " + balancec);
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se puede actualizar");

            }

            cone.Close();
        }
        //-------------------------------------------------RETIROS---------------------------------------
        public void retiros()
        {
       
            Console.WriteLine("Ingrese el numero de cuenta: ");
            int cuentanumerox = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el monto a retirar: ");
            int montoretiro = Convert.ToInt32(Console.ReadLine());

            int balancex = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM AHORRO WHERE numero_cuenta ={cuentanumerox}", cone);

            SqlDataReader reader = comando.ExecuteReader();

            if (reader.Read())
            {
                balancex = int.Parse(reader["balance"].ToString());
                cone.Close();
                cone.Open();
                balancex -= montoretiro;
                string query = $"UPDATE AHORRO SET balance = {balancex} WHERE numero_cuenta = {cuentanumerox}";
                comando = new SqlCommand(query, cone);
                comando.ExecuteNonQuery();

                Console.WriteLine("---------     RETIRO     ---------------");
                Console.WriteLine("Total de retiro:  " + montoretiro);
                Console.WriteLine("Balance: " + balancex);
                Console.WriteLine("-----------------------------------------");
            }
            else
            {
                Console.WriteLine("No se puede retirar, intente de nuevo");

            }

            cone.Close();

        }

        //-------------------------------------------------CONSULTA---------------------------------------
        public void consulta()
        {
            Console.WriteLine("Ingrese el numero de cuenta: ");
            int cuentanumerox = Convert.ToInt32(Console.ReadLine());

            int balancez = 0;

            cone.Open();
            SqlCommand comando = new SqlCommand($"SELECT balance FROM AHORRO WHERE numero_cuenta ={cuentanumerox}", cone);

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
