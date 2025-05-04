using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class DescripcionPortatilMovil
    {
        [Key]
        public int id_descripcionPortatilMovil { get; set; }
        public string procesador { get; set; }
        public string ram { get; set; }
        public string almacenamiento { get; set; }
        public string pantalla { get; set; }
        public string tarjetaGrafica { get; set; }
        public string sistemaOperativo { get; set; }

        [ForeignKey("Producto")]
        public int id_producto { get; set; } // Foreign key a Producto
        public virtual Producto Producto { get; set; }

        public DescripcionPortatilMovil(string procesador, string ram, string almacenamiento, string pantalla, string tarjetaGrafica, string sistemaOperativo)
        {
            this.procesador = procesador;
            this.ram = ram;
            this.almacenamiento = almacenamiento;
            this.pantalla = pantalla;
            this.tarjetaGrafica = tarjetaGrafica;
            this.sistemaOperativo = sistemaOperativo;
        }
        public DescripcionPortatilMovil() { }
    }
}
