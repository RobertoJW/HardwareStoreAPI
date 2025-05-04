using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class DescripcionSobremesa
    {
        [Key]
        public int id_descripcionSobremesa { get; set; }
        public string procesador { get; set; }
        public string ram { get; set; }
        public string almacenamiento { get; set; }
        public string tarjetaGrafica { get; set; }
        public string fuentePoder { get; set; }
        public string motherboard { get; set; }
        public string refrigeracion { get; set; }

        [ForeignKey("Producto")]
        public int id_producto { get; set; } // Foreign key a Producto
        public virtual Producto Producto { get; set; }

        public DescripcionSobremesa(string procesador, string ram, string almacenamiento, string tarjetaGrafica, string fuentePoder, string motherboard, string refrigeracion)
        {
            this.procesador = procesador;
            this.ram = ram;
            this.almacenamiento = almacenamiento;
            this.tarjetaGrafica = tarjetaGrafica;
            this.fuentePoder = fuentePoder;
            this.motherboard = motherboard;
            this.refrigeracion = refrigeracion;
        }
        public DescripcionSobremesa() { }
    }
}
