using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class BarangsController : Controller
    {
        inventoryEntities dbModel = new inventoryEntities();
        // GET: Barangs
        public ActionResult Barang()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBarang(barang model)
        {
            barang obj = new barang();
            obj.nama_barang = model.nama_barang;
            obj.jumlah = model.jumlah;
            obj.harga = model.harga;
            obj.deskripsi = model.deskripsi;
            obj.active = model.active;
            obj.gambar = model.gambar;
            obj.created_at = DateTime.Now;

            dbModel.barangs.Add(obj);
            dbModel.SaveChanges();

            return View("Barang");
        }
    }
}