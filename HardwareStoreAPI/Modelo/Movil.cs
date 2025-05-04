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
    public class Movil : Producto
    {

        public int pulgadas { get; set; }

        public Movil(string imageUrl, string companyBrand, string nameProduct, string category, double price, int pulgadas)
            : base(imageUrl, companyBrand, nameProduct, category, price)
        {
            this.pulgadas = pulgadas;
        }

        public Movil() { }
    }
}
