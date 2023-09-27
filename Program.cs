using System;
using System.Collections.Generic;

class Program
{
    const double DESCUENTO = 0.1;

    static void Main()
    {
        string cliente, direccion, producto;
        double precio;
        int cantidad;
        double totalVenta = 0;

        List<string> detallesProductos = new List<string>();

        Console.WriteLine("Bienvenido a la Ferreteria El Constructor\n");

        Console.Write("Nombre del Cliente: \n");
        cliente = Console.ReadLine();

        Console.Write("Direccion: ");
        direccion = Console.ReadLine();

        bool continuar = true;

        while (continuar)
        {
            Console.Write("\nIngrese el nombre del Producto: ");
            producto = Console.ReadLine();
            Console.Write("Ingrese el precio del Producto: ");
            precio = Convert.ToDouble(Console.ReadLine());
            Console.Write("Ingrese la cantidad del Producto: ");
            cantidad = Convert.ToInt32(Console.ReadLine());

            double totalProducto = precio * cantidad;
            totalVenta += totalProducto;

            detallesProductos.Add($"{producto,-12} {precio,-10} {cantidad,-12} {totalProducto,-6}");

            Console.Write("\n¿Desea agregar otro producto? (s/n): ");
            string respuesta = Console.ReadLine();

            continuar = (respuesta.ToLower() == "s");
        }

        double descuentoAplicado = 0;

        if (totalVenta > 100 && detallesProductos.Count > 0)
        {
            descuentoAplicado = totalVenta * DESCUENTO;
            totalVenta -= descuentoAplicado;
            Console.WriteLine($"\nSe aplico un descuento del {DESCUENTO * 100}%. \nTotal despues del descuento: {totalVenta}");
        }
        else
        {
            Console.WriteLine("\nNo se aplicó descuento.");
        }

        string metodoPago;
        bool metodoPagoValido = false;

        while (!metodoPagoValido)
        {
            Console.Write("\nIngrese el metodo de pago (efectivo/tarjeta): ");
            metodoPago = Console.ReadLine().ToLower();

            switch (metodoPago)
            {
                case "efectivo":
                    Console.WriteLine("El pago se realizo en efectivo.");
                    metodoPagoValido = true;
                    break;
                case "tarjeta":
                    Console.WriteLine("El pago se realizo con tarjeta de crédito.");
                    metodoPagoValido = true;
                    break;
                default:
                    Console.WriteLine("Metodo de pago no reconocido. Por favor, ingrese 'efectivo' o 'tarjeta'.");
                    break;
            }
        }

        Console.WriteLine("\nBoleta de Compra:");
        Console.WriteLine($"Cliente: {cliente} \nDirección: {direccion}\n");
        Console.WriteLine("Producto    Precio    Cantidad    Total");
        Console.WriteLine("-------------------------------------");

        foreach (var detalleProducto in detallesProductos)
        {
            Console.WriteLine(detalleProducto);
        }

        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Total de venta: {totalVenta}");
        Console.WriteLine("Atendido por: BRAYAM EDWIN QUISPE APAZA");
        Console.WriteLine("GRACIAS POR SU COMPRA");
        Console.WriteLine("-------------------------------------");

        if (descuentoAplicado > 0)
        {
            Console.WriteLine($"Descuento aplicado: {descuentoAplicado}");
        }
    }
}
