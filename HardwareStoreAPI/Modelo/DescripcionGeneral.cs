using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class DescripcionGeneral
    {
        [Key]
        public int id_descripcionGeneral { get; set; }

        [ForeignKey("Producto")]
        public int id_producto { get; set; } // Foreign key a Producto
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string GPU { get; set; }
        public string Almacenamiento { get; set; }
        public string SistemaOperativo { get; set; }
        public string PlacaBase { get; set; }

        public virtual Producto Producto { get; set; }
        public DescripcionGeneral(string CPU, string RAM, string Almacenamiento, string SistemaOperativo, string PlacaBase)
        {
            this.CPU = CPU;
            this.RAM = RAM;
            this.Almacenamiento = Almacenamiento;
            this.SistemaOperativo = SistemaOperativo;
            this.PlacaBase = PlacaBase;
        }
        public DescripcionGeneral() { }
    }
}
