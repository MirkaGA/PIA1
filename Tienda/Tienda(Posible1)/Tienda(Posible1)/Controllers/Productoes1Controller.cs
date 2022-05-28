﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tienda_Posible1_.Models.dbModels;

namespace Tienda_Posible1_.Controllers
{
    public class Productoes1Controller : Controller
    {
        private readonly TiendaContext _context;

        public Productoes1Controller(TiendaContext context)
        {
            _context = context;
        }

        // GET: Productoes1
        public async Task<IActionResult> Index()
        {
            var tiendaContext = _context.Productos.Include(p => p.CategoriaNavigation).Include(p => p.ProveedorNavigation);
            return View(await tiendaContext.ToListAsync());
        }

        // GET: Productoes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CategoriaNavigation)
                .Include(p => p.ProveedorNavigation)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes1/Create
        public IActionResult Create()
        {
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias");
            ViewData["Proveedor"] = new SelectList(_context.Proveedores, "ProveId", "ProveId");
            return View();
        }

        // POST: Productoes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductoId,Nombre,Descripcion,Proveedor,Stock,Imagen,Categoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", producto.Categoria);
            ViewData["Proveedor"] = new SelectList(_context.Proveedores, "ProveId", "ProveId", producto.Proveedor);
            return View(producto);
        }

        // GET: Productoes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", producto.Categoria);
            ViewData["Proveedor"] = new SelectList(_context.Proveedores, "ProveId", "ProveId", producto.Proveedor);
            return View(producto);
        }

        // POST: Productoes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductoId,Nombre,Descripcion,Proveedor,Stock,Imagen,Categoria")] Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.ProductoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategorias", "IdCategorias", producto.Categoria);
            ViewData["Proveedor"] = new SelectList(_context.Proveedores, "ProveId", "ProveId", producto.Proveedor);
            return View(producto);
        }

        // GET: Productoes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.CategoriaNavigation)
                .Include(p => p.ProveedorNavigation)
                .FirstOrDefaultAsync(m => m.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.ProductoId == id);
        }
    }
}
