using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Data;


namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestauranteDbContext _context;

        public HomeController(RestauranteDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adicionar()
        {

            var produto = new Item();

            return View(produto);
        }

        [HttpPost]
        public IActionResult Adicionar(Item produto)
        {
            if (ModelState.IsValid)
            {
                _context.Itens.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(produto);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public IActionResult Pedido(string mesa)
        {
            return RedirectToAction("Pedido", new { ID = mesa });
        }

        public IActionResult Pedido(int ID = 0 ,string less = "dn")
        {

            IQueryable<Mesa> consulta = _context.mesas;

            consulta = consulta.Where(m => m.MesaId == ID);
            var selectedmesa = consulta.FirstOrDefault().MesaId;

            if (_context == null)
            {
                Console.WriteLine("O contexto está null");
            }
            else if (_context.mesas == null)
            {
                Console.WriteLine("O DbSet<Mesa> está null");
            }
            else
            {
                Console.WriteLine($"Total de mesas: {_context.mesas.Count()}");
            }





            ViewData["less_class"] = less;

            ViewData["Mesa"] = selectedmesa;
            
            return View();
        }

        public IActionResult Products() { 

            ViewBag.Itens = _context.Itens.ToList();
            var produtos = ViewBag.Itens;


            return View(produtos);
        
        }


        [HttpPost]
        public IActionResult Remover(string remove)
        {
            List<String>nomes = GetAllNames();

            

            if (nomes.Contains(remove))
            {
                var toberemoved = _context.Itens.Where(i => i.Name == remove).ToList();


                _context.Itens.Remove(toberemoved[0]);
                _context.SaveChanges();

                return RedirectToAction("Products");    

            }

            else
            {
                return View();
            }

        }

        public IActionResult Remover()
        {
            return View();
        }


        public List<String> GetAllNames()
        {

            ViewBag.Itens = _context.Itens.ToList();

            List<String> nomes = new List<string>();

            foreach (Item i in ViewBag.Itens)
            {
                string nome = i.Name;
                nomes.Add(nome);
            }

            return nomes;

        }
            


        [HttpPost]
        public IActionResult Validate(string pedido , int ID)
        {

            ViewBag.Itens = _context.Itens.ToList();

            List<String> nomes = new List<string>();

            foreach (Item i in ViewBag.Itens)
            {
                string nome = i.Name;
                nomes.Add(nome);
            }
            
            


            Console.WriteLine(pedido);
            if (nomes.Contains(pedido))
            {
                IQueryable<Item> consulta = _context.Itens.Where(i => i.Name == pedido);
                Item selecteditem = consulta.FirstOrDefault();
                Console.WriteLine(selecteditem.Name);
                IQueryable<Mesa> consultamesa = _context.mesas.Where(m => m.MesaId == ID);
                Mesa selectedmesa = consultamesa.FirstOrDefault();
                Console.WriteLine(selecteditem.Name);


                MesaItem mesaitem = new MesaItem { ItemId = selecteditem.ItemId, item = selecteditem, MesaId = ID , mesa = selectedmesa};
                selecteditem.MesaItens.Add(mesaitem);
                selectedmesa.MesaItens.Add(mesaitem);
                _context.mesasitens.Add(mesaitem);
                _context.SaveChanges();

                

                IEnumerable<MesaItem> mesaitens = _context.mesasitens.Where(m => m.MesaId == selectedmesa.MesaId).ToList();

                ViewData["Mesa"] = selectedmesa;
                ViewData["Pedido"] = pedido;
                return View(mesaitens);
            }
            else
            {
                return RedirectToAction("Pedido" , new { less = "less"});
            }
        }
    }
}
