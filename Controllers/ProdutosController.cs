using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace Loja.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly LojaContext _context;
        Uri baseAddress = new Uri("http://127.0.0.1:5242/api");
        private readonly HttpClient _client;

        public ProdutosController(LojaContext context)
        {
            _context = context;
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        // GET: Produtos
    
        [HttpGet]
        public IActionResult Index()
        {
            List<Produto> productList = new List<Produto>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Produtos").Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Produto>>(data);
            } 
            return View(productList);
        }


        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Preco")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        // public async Task<IActionResult> Edit(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }

        //     var produto = await _context.Produto.FindAsync(id);
        //     if (produto == null)
        //     {
        //         return NotFound();
        //     }
        //     return View(produto);
        // }

           // GET: Produtos/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int ProdutoId)
        {
            try
            {
                Produto produto = null;
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Produtos/" + ProdutoId);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    produto = JsonConvert.DeserializeObject<Produto>(data);
                }
                return View(produto);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Produto model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PutAsync(_client.BaseAddress + "/Produtos/" + model.ProdutoId, content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Detalhes do produto atualizados";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Erro ao atualizar os detalhes do produto";
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(model);
            }
        }


        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Preco")] Produto produto)
        // {
        //     if (id != produto.ProdutoId)
        //     {
        //         return NotFound();
        //     }

        //     if (ModelState.IsValid)
        //     {
        //         try
        //         {
        //             _context.Update(produto);
        //             await _context.SaveChangesAsync();
        //         }
        //         catch (DbUpdateConcurrencyException)
        //         {
        //             if (!ProdutoExists(produto.ProdutoId))
        //             {
        //                 return NotFound();
        //             }
        //             else
        //             {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction(nameof(Index));
        //     }
        //     return View(produto);
        // }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produto
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto != null)
            {
                _context.Produto.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.ProdutoId == id);
        }
    }
}
