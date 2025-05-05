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

        public tipoPc tipoPc { get; set; }
        public virtual DescripcionSobremesa DescripcionSobremesa { get; set; }

        public Sobremesa(string image, string companyBrand, string nameProduct, string category, tipoPc tipoPc, double price)
            : base(image, companyBrand, nameProduct, category, price)
        {
            this.tipoPc = tipoPc;
        }
        public Sobremesa() {}
    }
}
