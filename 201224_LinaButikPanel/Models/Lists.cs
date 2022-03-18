using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _201224_LinaButikPanel.Models
{
    public static class Lists
    {
        public static List<SelectListItem> GetPaymentType()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(a => a.FeatureTypeID == 5).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetOrderStatus()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(a => a.FeatureTypeID == 4).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetCities()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.City.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.City,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetCountries(int _CityID)
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Country.Where(x => x.CityID == _CityID).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Country,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetCargoCompanies()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(x => x.FeatureTypeID == 10).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetCustomerAddress(int _CustomerID)
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Address.Where(x => x.CustomerID == _CustomerID).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Address,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetProductCategory()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(x => x.FeatureTypeID == 1).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetGenders()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(x => x.FeatureTypeID == 9).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetColors()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(x => x.FeatureTypeID == 2).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetSizes()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Feature.Where(x => x.FeatureTypeID == 3).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Property,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetBrands()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Brand.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Brand,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetCustomers()
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Customer.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.NameSurname,
                                                 Value = x.Id.ToString()
                                             }).ToList();
                return list;
            }
        }

        public static List<SelectListItem> GetProductColors(string pCode)
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list = (from x in model.Product.Where(x => x.ProductCode == pCode).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Color.Property,
                                                 Value = x.ColorID.ToString()
                                             }).Distinct().ToList();
                return list.GroupBy(x => x.Text).Select(x => x.First()).ToList();
            }
        }

        public static List<SelectListItem> GetProductSize(string pCode, int? cId)
        {
            using (Context model = new Context())
            {
                List<SelectListItem> list;
                if (cId is null)
                {
                    list = (from x in model.Product.Where(x => x.ProductCode == pCode).ToList()
                            select new SelectListItem
                            {
                                Text = x.Size.Property,
                                Value = x.SizeID.ToString()
                            }).ToList();

                }

                else
                {
                    list = (from x in model.Product.Where(x => x.ProductCode == pCode && x.ColorID == cId).ToList()
                            select new SelectListItem
                            {
                                Text = x.Size.Property,
                                Value = x.SizeID.ToString()
                            }).ToList();
                }
                return list;
            }
        }

        public static string CreateProductCode(Products pr)
        {
            using (Context model = new Context())
            {
                string LastPC;
                if (model.Product.Where(x => x.CategoryID == pr.CategoryID).Count() > 0)
                {
                    //Veritabanından aynı kategorideki son ürünün ürün kodunu aldı
                    LastPC = (from x in model.Product
                                  where x.CategoryID == pr.CategoryID
                                  orderby x.Id descending
                                  select x.ProductCode).First().ToString();

                    //Alınan ürün kodunun her bir karakterini char dizisine attı
                    char[] alf = LastPC.ToCharArray();

                    //Girilen kategorinin kısaltmasını aldı
                    string PCCode = (from x in model.Feature
                                     where x.Id == pr.CategoryID
                                     select x.Des).FirstOrDefault().ToString();

                    //alf dizisinin içindeki 2. indisten başlayarak son elemana
                    //kadar tek tek PCNumber içine attı
                    //Burada ama ürün kodunun sadece numara kısmını almak
                    string PCNumbers = "";
                    for (int i = 2; i <= alf.Length - 1; i++)
                    {
                        PCNumbers += alf[i];
                    }

                    //Aynı kategorideki son kaydın ürün kodundaki numara kısmına 1 ekleyip
                    //değişkene attık
                    PCNumbers = (Convert.ToInt32(PCNumbers) + 1).ToString();
                    //Kategori kısaltmasıyla ürün kodunun numara kısmını birleştirdik
                    //Artık yeni ürünümüzün kodu belli oldu
                    return PCCode + PCNumbers;
                }
                else
                {
                    string code =(from x in model.Feature
                              where x.Id == pr.CategoryID
                              select x.Des).First().ToString();
                    code += "100000";
                    return code;
                }
            }
        }
    }
}