﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string ProductCountOfCategoryError = "Bir Kategori de En fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists = "1  den fazla aynı isimde ürün olamaz";
        public static string CategoryLimitExceded = "Kategory Limiti Aşıldı";
    }
}
