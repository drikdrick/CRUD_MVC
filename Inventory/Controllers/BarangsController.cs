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
        inventoryEntitiez dbModel = new inventoryEntitiez();
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

            return View("ListBarang");
        }

        public ActionResult ListBarang()
        {
            var res = dbModel.barangs.ToList();
            return View(res);
        }

        public ActionResult Delete(int id)
        {
            var res = dbModel.barangs.Where(x=>x.id==id).First();
            dbModel.barangs.Remove(res);
            dbModel.SaveChanges();

            var list = dbModel.barangs.ToList();

            return View("ListBarang", list);
        }
    }
}