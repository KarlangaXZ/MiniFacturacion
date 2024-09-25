using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniFacturacion;

/*
Se requiere crear una mini facturación donde se pueda crear una Factura y ver una lista de facturas de 
3 facturas.

Dicha factura debe tener un cliente y al menos 2 articulo de bebida Alcoholica y no alcoholica, en 
adición el total del montos de todas las facturas se debe de imprimir por consola o pantalla.

Las marcas de bebidas son...
 Patrón, Brugal, Presidente, 7up, Mott, Gatorade.

 Los costos son:
    -Patrón Silver: 5,500
    -Patrón Platinium : 11,500
    -Brugal XV: 700
    -Brugal Leyenda: 900
    -Presidente ligth normal: 200
    -Presidente Dura normal: 225
    -7up: 50
    -Mott Manzana: 140
    -Gatorade Morado: 100

La meta de facturación es de RD$ 50,000,  los clientes que lleven más de 2 artículos de la misma 
marca y modelo llevan un 15% Off en cada articulo que cumpla con la condición anterior.

Mostrar el total de Articulos vendido y agrupado por marcas y modelo

// OJO una cosa es la marca y otra es su modelo
Ejemplo Marca: Brugal, Modelo: Brugal XV
*/

namespace MiAppPrincipal
{
    public class Program
    {

        public static void Main(string[] args)
        {
            // Crear una lista para guardar las facturas
            List<Factura> facturas = new List<Factura>();

            // Crear 3 facturas
            Factura factura1 = new Factura("Cliente 1");
            factura1.AgregarArticulo(new Articulos("Patrón", "Silver", 5500));
            factura1.AgregarArticulo(new Articulos("7up", "Normal", 50));

            Factura factura2 = new Factura("Cliente 2");
            factura2.AgregarArticulo(new Articulos("Brugal", "Leyenda", 900));
            factura2.AgregarArticulo(new Articulos("Brugal", "XV", 700));
            factura2.AgregarArticulo(new Articulos("Patron", "Platinum", 11500));

            Factura factura3 = new Factura("Cliente 3");
            factura3.AgregarArticulo(new Articulos("Presidente", "Ligth", 200));
            factura3.AgregarArticulo(new Articulos("Presidente", "Dura", 225));

            // Añadir facturas a la lista
            facturas.Add(factura1);
            facturas.Add(factura2);
            facturas.Add(factura3);

            // Calcular el total de todas las facturas
            decimal totalGeneral = 0;
            foreach (var factura in facturas)
            {
                factura.AplicarDescuento(); // Para aplicar el descuento.
                factura.ImprimirFactura(); // Imprime los detalles de cada factura
                totalGeneral += factura.CalcularTotal(); // Suma el total de cada factura
            }

            Console.WriteLine($"El total de todas las facturas es: RD${totalGeneral}");

            // Meta de Facturacion
            decimal metaFacturacion = 50000;
            Console.WriteLine($"Meta de facturación: RD${metaFacturacion}");

            if (totalGeneral >= metaFacturacion)
            {
                Console.WriteLine("¡Meta de facturación alcanzada!");
            }
            else
            {
                Console.WriteLine("Meta no alcanzada.");
            }
        }
    }
}
        

