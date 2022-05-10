﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaMoedas2.Data;
using SistemaMoedas2.Models;
using SistemaMoedas2.Repositorio.Interface;

namespace SistemaMoedas2.Controllers
{
    public class ParceiroController : Controller
    {
        private readonly BancoContext _context;
        private readonly IParceiroRepositorio _parceiro;

        public ParceiroController(BancoContext context, IParceiroRepositorio aluno)
        {
            _context = context;
            _parceiro = aluno;
        }

        public IActionResult Index()
        {
            return View(_parceiro.BuscarTodos());
        }

        /* IActionResult Criar()
        {
            var list = _context.Instituicao.ToList();
            ViewBag.Instituicao = new SelectList(list, "Id", "Nome");
            return View();
        }*/

        /// <summary>
        /// Id do aluno para editar
        /// </summary>
        /// <param name="id">id aluno</param>
        /// <returns></returns>
        public IActionResult Editar(int id)
        {
            var parceiro = _parceiro.ObterPorId(id);
            return View(parceiro);
        }

        // POST: Aluno/Create
        /// <summary>
        /// Cadastrar um aluno
        /// </summary>
        /// <param name="aluno">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Criar(Parceiro parceiro)
        {
            _parceiro.Adicionar(parceiro);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Editar um aluno
        /// </summary>
        /// <param name="aluno">Model de aluno</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Editar(Parceiro parceiro)
        {
            _parceiro.Atualizar(parceiro);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Deletar um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Apagar(int id)
        {
            _parceiro.Deletar(id);
            return RedirectToAction("Index");
        }
    }
}
