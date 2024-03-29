﻿using GrupoAox.Estagio.Domain.Entidades;
using GrupoAox.Estagio.Domain.Interfaces.Repositorios;
using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using GrupoAox.Estagio.Domain.Validations.Categorias;
using System;
using System.Collections.Generic;

namespace GrupoAox.Estagio.Domain.Servicos
{
    public class CategoriaServices : ICategoriaServices
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public CategoriaServices(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public Categoria Adicionar(Categoria categoria)
        {
            categoria.ValidationResult = new CategoriaAptaParaCadastroValidation(_categoriaRepositorio).Validate(categoria);
            if (categoria.ValidationResult.IsValid)
            {
                var categoriaRetorno = _categoriaRepositorio.Adicionar(categoria);
                categoriaRetorno.ValidationResult = categoria.ValidationResult;
                return categoriaRetorno;
            }
            else
            {
                return categoria;
            }
        }

        public Categoria Atualizar(Categoria categoria)
        {
            return _categoriaRepositorio.Atualizar(categoria);
        }

        public void Dispose()
        {
            _categoriaRepositorio.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<Categoria> ObterPorDescricao(string descricao)
        {
            return _categoriaRepositorio.ObterPorDescricao(descricao);
        }

        public Categoria ObterPorId(int id)
        {
            return _categoriaRepositorio.ObterPorId(id);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _categoriaRepositorio.ObterTodos();
        }

        public void Remover(int id)
        {
            _categoriaRepositorio.Remover(id);
        }
    }
}
