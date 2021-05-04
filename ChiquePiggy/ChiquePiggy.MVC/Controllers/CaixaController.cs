using ChiquePiggy.Domain;
using ChiquePiggy.Helpers.Views;
using ChiquePiggy.Models;
using ChiquePiggy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChiquePiggy.MVC.Controllers
{
    public class CaixaController : Controller
    {
        private readonly ICaixaService _caixaService;

        public CaixaController(ICaixaService caixaService)
        {
            _caixaService = caixaService;
        }
        [HttpGet]
        public ActionResult Inicio(int id = 0)
        {
            //Exemplo básico de chamada aos serviços e fluxo do sistema         
            //SaldoClienteViewModel saldoModel = _caixaService.ConsultarSaldoPontos(id);
            return View(CaixaViews.Inicio);
        }
        [HttpPost]
        [ActionName("Inicio")]
        public ActionResult Concluir(CaixaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.Nome))
                {
                    Cliente dto = _caixaService.SalvarCliente(new Cliente { nome = model.Nome });
                    model.idCliente = dto.idCliente;
                    TempData["mensagem"] = "cliente cadastrado com sucesso";
                }
                else
                {
                    ClienteViewModel cliente = _caixaService.ConsultarCliente(model.idCliente);

                    if (cliente.idCliente == 0)
                    {
                        TempData["novo_cliente"] = "Está é a primeira compra do cliente, digite o nome do novo cliente ";
                        return View();
                    }
                }
                

                var historico = _caixaService.GerarPontuacao(model);
                if (historico._pontoGanhos >= 100)
                {
                    TempData["pontuacao100"] = "O cliente atingingiu 100 pontos";
                }
                else
                {
                    TempData["mensagem"] += "Pontos adicionados com sucesso";
                }

            }

            return View(model);


        }
        [HttpPost]
        //[ActionName("BaixaPontuacao")]
        public ActionResult BaixaPontuacao(CaixaViewModel model)
        {
            if (_caixaService.BaixaPontos(model.idCliente))
            {
                TempData["mensagem"] = string.Format("Pontos baixados com sucesso, pontuaçao atual: {0}", _caixaService.ConsultarSaldo(model.idCliente));
                return RedirectToAction("Inicio");
            }
            return RedirectToAction("Inicio");
        }


    }
}