using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class DescripcionSobremesa : DescripcionGeneral
    {
        [Key]
        public int id_descripcionSobremesa { get; set; }
        public string fuenteAlimentacion { get; set; }

        [ForeignKey("Producto")]
        public int id_producto { get; set; } // Foreign key a Producto
        public virtual Producto Producto { get; set; }

        public DescripcionSobremesa(string fuenteAlimentacion)
        {
            this.fuenteAlimentacion = fuenteAlimentacion;
        }
        public DescripcionSobremesa() { }
    }
}
