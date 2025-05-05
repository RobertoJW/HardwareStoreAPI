using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class DescripcionPortatilMovil : DescripcionGeneral
    {
        [Key]
        public int id_descripcionPortatilMovil { get; set; }
        public int Pulgadas { get; set; }
        public int Bateria { get; set; }

        [ForeignKey("Producto")]
        public int id_producto { get; set; } // Foreign key a Producto
        public virtual Producto Producto { get; set; }

        public DescripcionPortatilMovil(int Pulgadas, int Bateria)
        {
            this.Pulgadas = Pulgadas;
            this.Bateria = Bateria;
        }
        public DescripcionPortatilMovil() { }
    }
}
