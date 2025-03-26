using System;
using System.Collections.Generic;

namespace crud2.OrdenCompra.Domain.Entidades
{
    public class OrdenCompra
    {
        public int OrdenCompraId { get; private set; }
        public int ProveedorId { get; private set; }
        public decimal MontoTotal { get; private set; }
        public string Estado { get; private set; }
        public DateTime FechaCreacion { get; private set; }
        public string? Comentarios { get; private set; }

        
        public Proveedor Proveedor { get; private set; }

       
        public OrdenCompra(int proveedorId, decimal montoTotal, string estado, string comentarios = null)
        {
            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException("El estado es requerido.", nameof(estado));

            ProveedorId = proveedorId;
            MontoTotal = montoTotal;
            Estado = estado;
            Comentarios = comentarios;
            FechaCreacion = DateTime.UtcNow;
        }
        // En Domain/Entidades/OrdenCompra.cs
        public void ActualizarInformacion(int proveedorId, decimal montoTotal, string estado, string comentarios)
        {
            ProveedorId = proveedorId;
            MontoTotal = montoTotal;
            Estado = estado;
            Comentarios = comentarios;
        }

        
        public void Aprobar()
        {
            if (Estado != "Creada")
                throw new InvalidOperationException("Solo se puede aprobar una orden que esté en estado 'Creada'.");

            Estado = "Aprobada";
        }

       
        public void Cancelar()
        {
            if (Estado == "Aprobada")
                throw new InvalidOperationException("No se puede cancelar una orden que ya ha sido aprobada.");

            Estado = "Cancelada";
        }
    }

    public class Proveedor
    {
        public int ProveedorId { get; private set; }
        public string Nombre { get; private set; }
        public string Contacto { get; private set; }
        public string Telefono { get; private set; }
        public string Email { get; private set; }
        public string Direccion { get; private set; }

        
        public ICollection<OrdenCompra> OrdenesCompra { get; private set; }

        
        public Proveedor(string nombre, string contacto, string telefono, string email, string direccion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es requerido.", nameof(nombre));

            Nombre = nombre;
            Contacto = contacto;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            OrdenesCompra = new List<OrdenCompra>();
        }
        public void Update(string nombre, string contacto, string telefono, string email, string direccion)
        {
            
            Nombre = nombre;
            Contacto = contacto;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
        }

        
        public void AgregarOrden(OrdenCompra orden)
        {
            if (orden == null)
                throw new ArgumentNullException(nameof(orden));

            OrdenesCompra.Add(orden);
        }
    }
}
