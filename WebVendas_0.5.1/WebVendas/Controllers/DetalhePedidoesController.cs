using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebVendas.Data;
using WebVendas.Models;

namespace WebVendas.Controllers
{
    public class DetalhePedidoesController : Controller
    {
        private WebVendasContext db = new WebVendasContext();

        // GET: DetalhePedidoes
        public async Task<ActionResult> Index()
        {
            var detalhePedidoes = db.DetalhePedidoes.Include(d => d.Pedido).Include(d => d.Produto);
            return View(await detalhePedidoes.ToListAsync());
        }

        // GET: DetalhePedidoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalhePedido detalhePedido = await db.DetalhePedidoes.FindAsync(id);
            if (detalhePedido == null)
            {
                return HttpNotFound();
            }
            return View(detalhePedido);
        }

        // GET: DetalhePedidoes/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Pedidoes, "Id", "Cliente");
            ViewBag.Id = new SelectList(db.Produtoes, "Id", "NomeProduto");
            return View();
        }

        // POST: DetalhePedidoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdPedido,Id,Quantidade,IdProduto")] DetalhePedido detalhePedido)
        {
            if (ModelState.IsValid)
            {
                db.DetalhePedidoes.Add(detalhePedido);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Pedidoes, "Id", "Cliente", detalhePedido.Id);
            ViewBag.Id = new SelectList(db.Produtoes, "Id", "NomeProduto", detalhePedido.Id);
            return View(detalhePedido);
        }

        // GET: DetalhePedidoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalhePedido detalhePedido = await db.DetalhePedidoes.FindAsync(id);
            if (detalhePedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Pedidoes, "Id", "Cliente", detalhePedido.Id);
            ViewBag.Id = new SelectList(db.Produtoes, "Id", "NomeProduto", detalhePedido.Id);
            return View(detalhePedido);
        }

        // POST: DetalhePedidoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdPedido,Id,Quantidade,IdProduto")] DetalhePedido detalhePedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalhePedido).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Pedidoes, "Id", "Cliente", detalhePedido.Id);
            ViewBag.Id = new SelectList(db.Produtoes, "Id", "NomeProduto", detalhePedido.Id);
            return View(detalhePedido);
        }

        // GET: DetalhePedidoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalhePedido detalhePedido = await db.DetalhePedidoes.FindAsync(id);
            if (detalhePedido == null)
            {
                return HttpNotFound();
            }
            return View(detalhePedido);
        }

        // POST: DetalhePedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DetalhePedido detalhePedido = await db.DetalhePedidoes.FindAsync(id);
            db.DetalhePedidoes.Remove(detalhePedido);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
