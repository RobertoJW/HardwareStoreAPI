using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HardwareStoreAdmin.Enumerado;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardwareStoreAPI.Modelo
{
    public class Portatil : Producto
    {
        public tipoPc tipoPc { get; set; }
        public int pulgadas { get; set; }
        public virtual DescripcionPortatilMovil DescripcionPortatilMovil { get; set; }

        public Portatil(string image, string companyBrand, string nameProduct, string category, double price, tipoPc tipoPc)
            : base(image, companyBrand, nameProduct, category, price)
        {
            this.tipoPc = tipoPc;
        }
        public Portatil() {}
    }
}
