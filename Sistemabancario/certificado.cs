using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Sistemabancario
{
    class certificado
    {

        SqlConnection cone = new SqlConnection("Data Source=DESKTOP-F0HC34O\\SQLSERVER;Initial Catalog=sistemabancario;Integrated Security=True");
        SqlCommand comando;

        //APERTURA
        public void apertura()
        {
            int numero_certi = 0;
            int montocerti = 0;
            int duracion = 0;

            Console.WriteLine("El NUMERO DE CERTIFICADO SERA CREADO AUTOMATICAMENTE");
            Console.WriteLine("");
            Console.WriteLine("Ingrese el monto de apertura");
            montocerti = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingrese el tiempo de duracion (MESES)");
            duracion = Convert.ToInt32(Console.ReadLine());

            var random = new Random();
            var rango = random.Next(1000, 9999);
            numero_certi = rango;

            cone.Open();
            comando = new SqlCommand($"INSERT INTO CERTIFICADO VALUES('{numero_certi}','{montocerti}','{duracion}')", cone);
            comando.ExecuteNonQuery();
            cone.Close();

            Console.WriteLine("Su numero de certificado es: " + numero_certi);

        }

        //CONSULTA INTERES
        public void consulta_interes()
        {
            var random = new Random();
            var valor = random.Next(1000, 9999);

            Console.WriteLine("Valor: "+ valor);


        }



    }
}
