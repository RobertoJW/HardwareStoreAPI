using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HardwareStoreAdmin.Enumerado;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HardwareStoreAPI.Modelo
{
    public class Sobremesa : Producto
    {
        [ForeignKey("id_producto")]
        public virtual Producto Producto { get; set; }
        public tipoPc tipoPc { get; set; }

        public Sobremesa(string image, string companyBrand, string nameProduct, string description, string category, double price)
            : base(image, companyBrand, nameProduct, description, category, price)
        {
            this.tipoPc = tipoPc;
        }
        public Sobremesa() {}
    }
}
