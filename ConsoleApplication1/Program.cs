using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try

{


UnicodeEncoding codificador = new
UnicodeEncoding();
string encriptar;
Console.Write("Ingresar texto a encriptar");
encriptar = Console.ReadLine();




byte[] datos = codificador.GetBytes(encriptar);


byte[] resultado;


SHA1 encriptarSHA = new
SHA1CryptoServiceProvider();

resultado = encriptarSHA.ComputeHash(datos);


StringBuilder sBuilder = new
StringBuilder();


// Repite a travez de cada byte de el hash y formatea cada uno como un string hexadecimal.


for (int i = 0; i < resultado.Length; i++)

{

sBuilder.Append(resultado[i].ToString("x2"));

}


Console.WriteLine("Texto a Encriptar: {0}", encriptar);


Console.WriteLine("Texto Encriptado: {0}", sBuilder.ToString());


Console.ReadLine();

}


catch (ArgumentNullException)

{


Console.WriteLine("Fallo en la Encriptacion");


Console.ReadLine();

}
        }
    }
}
