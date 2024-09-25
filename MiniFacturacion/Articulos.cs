using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniFacturacion;

namespace MiniFacturacion
{
    /// <summary>
    /// Los Articulos aqui
    /// </summary>
    public class Articulos
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }

        public Articulos(string marca, string modelo, decimal precio)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Precio = precio;
        }
    }
}

/// <summary>
/// FActura
/// </summary>
public class Factura
{
    public string Cliente { get; set; }
    public List<Articulos> Articulos { get; set; }

    public Factura(string cliente)
    {
        this.Cliente = cliente;
        Articulos = new List<Articulos>();
    }

    public void AgregarArticulo(Articulos articulos)
    {
        Articulos.Add(articulos);
    }

    public decimal CalcularTotal()
    {
        decimal total = 0;
        foreach (var articulo in Articulos)
        {
            total += articulo.Precio;
        }
        return total;
    }

    public void AplicarDescuento()
    {
        Dictionary<string, int> contadorModelos = new Dictionary<string, int>();
        foreach (var articulo in Articulos)
        {
            string key = articulo.Marca + " " + articulo.Modelo;

            if (contadorModelos.ContainsKey(key))
            {
                contadorModelos[key]++;
            }
            else
            {
                contadorModelos[key] = 1;
            }

            if (contadorModelos[key] > 2)
            {
                articulo.Precio *= 0.85m; // Aplica 15% de descuento
            }
        }
    }

    //Aqui Impriendo la Factura.
    public void ImprimirFactura()
    {
        Console.WriteLine($"Factura de: {Cliente}");
        Console.WriteLine("Artículos comprados:");

        foreach (var articulo in Articulos)
        {
            Console.WriteLine($"- {articulo.Marca} {articulo.Modelo}: RD${articulo.Precio}");
        }

        Console.WriteLine($"Total: RD${CalcularTotal()}");
        Console.WriteLine("--------------------------");
    }
}


