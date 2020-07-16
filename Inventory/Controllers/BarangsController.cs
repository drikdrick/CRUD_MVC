using Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory.Controllers
{
    public class BarangsController : Controller
    {
        inventoryEntitiez dbModel = new inventoryEntitiez();
        // GET: Barangs
        public ActionResult Barang(barang objek)
        {
            return View(objek);
        }
        [HttpPost]
        public ActionResult AddBarang(barang model)
        {
            barang obj = new barang();
            obj.id = model.id;
            obj.nama_barang = model.nama_barang;
            obj.jumlah = model.jumlah;
            obj.harga = model.harga;
            obj.deskripsi = model.deskripsi;
            obj.active = model.active;
            obj.gambar = model.gambar;
            obj.created_at = DateTime.Now;

            if(model.id == 0)
            {
                dbModel.barangs.Add(obj);
                dbModel.SaveChanges();
            }
            else
            {
                model.update_at = DateTime.Now;
                dbModel.Entry(obj).State = EntityState.Modified;
                dbModel.SaveChanges();
            }

            var list = dbModel.barangs.ToList();
            return View("ListBarang", list);
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