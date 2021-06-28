using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistemabancario
{
    class Program
    {
        static void Main(string[] args)
        {

            int opcion1 = 0;

            Iretiro retirarcuenta;

            cuenta_ahorro   ahorrar  = new cuenta_ahorro();
            adaptador       super      = new adaptador();
            
            facade fachada = new facade();

            prestamos       op_presta      =  new prestamos();
            tarjeta_credito op_tarjeta     =  new tarjeta_credito();
            certificado     op_certificado =  new certificado();

            try { 
            do
            {

                 Console.WriteLine("*********************");
                 Console.WriteLine("  SISTEMA BANCARIO   ");
                 Console.WriteLine("*********************");
                 Console.WriteLine("");
                 Console.WriteLine("Seleccione una aplicacion \n" +
                     "\n1.APLICACION DE ESCRITORIO" +
                     "\n2.APLICACION MOVIL" +
                     "\n3.Salir\n"
                     );

                int principal = 0;
                principal = Convert.ToInt32(Console.ReadLine());

                switch (principal) {

                    case 1:
                        Console.Clear();
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("  SISTEMA BANCARIO - APLICACION DE ESCRITORIO  ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("");
                        Console.WriteLine("Seleccione una opción\n" +
                            "\n1.Cuentas de ahorro" +
                            "\n2.Prestamos" +
                            "\n3.Tarjetas de Credito" +
                            "\n4.Certificados Financieros" +
                            "\n5.Volver\n"
                            );

                        int optionNum = 0;
                        optionNum = Convert.ToInt32(Console.ReadLine());


                        //------------------------------------------------------------------------------------------------------

                        switch (optionNum)
                        {
                            //------------------ CUENTAS DE AHORRO ------------------
                            case 1:

                                Console.Clear();
                                Console.WriteLine("Seleccione una opción \n" +
                                "\n1.Apertura" +
                                "\n2.Depositos" +
                                "\n3.Retiros" +
                                "\n4.Consulta" +
                                "\n5.Volver\n");

                                int option2 = 0;
                                option2 = Convert.ToInt32(Console.ReadLine());

                                switch (option2)
                                {
                                    //------------------ APERTURA ------------------
                                    case 1:


                                        Console.Clear();
                                        Console.WriteLine("Seleccione el Tipo de Cuenta de ahorro para arbrir una cuenta\n" +
                                        "\n1.Cuenta de ahorro Normal" +
                                        "\n2.Cuenta de super ahorro" +
                                        "\n3.Volver\n");


                                        int option3 = 0;
                                        option3 = Convert.ToInt32(Console.ReadLine());

                                        switch (option3)
                                        {
                                            case 1:
                                                ahorrar.apertura();
                                                break;
                                            case 2:
                                                super.apertura();
                                                break;
                                            case 3:

                                                break;

                                        }


                                        //------------------ DEPOSITO ------------------

                                        break;

                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("Seleccione el Tipo de Cuenta de ahorro para depositar\n" +
                                        "\n1.Cuenta de ahorro Normal" +
                                        "\n2.Cuenta de super ahorro" +
                                        "\n3.Volver\n");

                                        int option4 = 0;
                                        option4 = Convert.ToInt32(Console.ReadLine());

                                        switch (option4)
                                        {
                                            case 1:
                                                ahorrar.depositos();
                                                break;
                                            case 2:
                                                super.depositos();
                                                break;
                                            case 3:

                                                break;

                                        }

                                        break;


                                    //------------------ RETIROS + ADAPTER ------------------
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("Seleccione el Tipo de Cuenta de ahorro para retirar\n" +
                                        "\n1.Cuenta de ahorro Normal" +
                                        "\n2.Cuenta de super ahorro\n");

                                        int option5 = 0;
                                        option5 = Convert.ToInt32(Console.ReadLine());



                                        if      (option5 == 1)
                                        {
                                            retirarcuenta = new cuenta_ahorro();
                                        }
                                        else if (option5 == 2)
                                        {
                                            retirarcuenta = new adaptador();
                                        }
                                        else
                                        {
                                                break;
                                        }
                                       

                                        retirarcuenta.retiros();



                                        break;

                                    //------------------ CONSULTA ------------------
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("Seleccione el Tipo de Cuenta de ahorro para consultar balance\n" +
                                        "\n1.Cuenta de ahorro Normal" +
                                        "\n2.Cuenta de super ahorro" +
                                        "\n3.Volver\n");

                                        int option6 = 0;
                                        option6 = Convert.ToInt32(Console.ReadLine());

                                        switch (option6)
                                        {
                                            case 1:
                                                ahorrar.consulta();
                                                break;
                                            case 2:
                                                super.consulta();
                                                break;
                                            case 3:

                                                break;



                                        }

                                        break;

                                    case 5:

                                        break;

                                }
                                break;




                            //------------------ PRESTAMOS ------------------
                            case 2:

                                Console.Clear();
                                Console.WriteLine("Seleccione una opcion\n" +
                                "\n1.Solicitud" +
                                "\n2.Pago de prestamos" +
                                "\n3.Volver\n");

                                int optionpresta = 0;
                                optionpresta = Convert.ToInt32(Console.ReadLine());

                                switch (optionpresta)
                                {
                                    //------------------ SOLICITUD ------------------
                                    case 1:

                                        op_presta.solicitud();

                                        break;
                                    //------------------ PAGO DE PRESTAMOS ------------------
                                    case 2:

                                        op_presta.pagopresta();

                                        break;


                                    case 3:
                                        break;


                                }


                                break;



                            //------------------ TARJETA DE CREDITO ------------------
                            case 3:


                                Console.Clear();
                                Console.WriteLine("Seleccione una opcion\n" +
                                "\n1.Expedicion" +
                                "\n2.Consumos" +
                                "\n3.Pagos" +
                                "\n4.Volver\n");

                                int optioncredito = 0;
                                optioncredito = Convert.ToInt32(Console.ReadLine());

                                switch (optioncredito)
                                {
                                    case 1:

                                        op_tarjeta.expedicion();

                                        break;

                                    case 2:

                                        op_tarjeta.consumos();


                                        break;

                                    case 3:

                                        op_tarjeta.pagos();

                                        break;




                                    case 4:
                                        break;




                                }
                                break;

                            //------------------ CERTIFICADOS FINANCIEROS ------------------
                            case 4:

                                Console.Clear();
                                Console.WriteLine("Seleccione una opcion\n" +
                                "\n1.Apertura" +
                                "\n2.Consulta de interes" +
                                "\n3.Volver\n");

                                int optionfinancia = 0;
                                optionfinancia = Convert.ToInt32(Console.ReadLine());

                                switch (optionfinancia)
                                {
                                    case 1:
                                        op_certificado.apertura();
                                        break;

                                    case 2:
                                        op_certificado.consulta_interes();
                                        break;


                                    case 3:
                                        break;

                                }
                                break;




                            //------------------ Volver ------------------
                            case 5:


                                break;

                            default:
                                break;
                        }


                        break;



                    case 2:
                        Console.Clear();
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("  SISTEMA BANCARIO - APLICACION MOVIL (BETA)  ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("");
                        Console.WriteLine("Seleccione una opción\n" +
                            "\n1.Cuentas de ahorro - Ver Balance" +
                            "\n2.Prestamos - Pago" +
                            "\n3.Certificados Financieros - Consulta" +
                            "\n4.Salir\n"
                            );


                        int optionfacade = 0;
                        optionfacade = Convert.ToInt32(Console.ReadLine());

                        switch (optionfacade)
                        {

                            case 1:
                                fachada.movil_ahorro();
                                break;

                            case 2:
                                fachada.movil_prestamo();
                                break;

                            case 3:
                                fachada.movil_certificados();
                                break;


                            case 4:
                                break;

                        }

                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                
                }



                Console.WriteLine("Quieres volver al menu principal? Pulse 1, de lo contrario otro numero ");
                opcion1 = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.ReadKey();

            } while (opcion1 == 1);


            }
            catch(Exception)
            {
                Console.WriteLine("Ha ocurrido un error, vuelva a intentar de nuevo");
            }



        }
    }
}
