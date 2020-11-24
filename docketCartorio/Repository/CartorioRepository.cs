using docketCartorio.Domains;
using docketCartorio.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docketCartorio.Repository
{ /// <summary>
  /// Repositório responsável pelos Cartorios
  /// </summary>
    public class CartorioRepository : ICartorioRepository
    {

        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        CartoriosContext ctx = new CartoriosContext();

        /// <summary>
        /// Atualiza um cartorio existente
        /// </summary>
        /// <param name="id">ID do cartorio que será atualizado</param>
        /// <param name="cartorioAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, Cartorio cartorioAtualizado)
        {
            // Busca um cartorio através do id
            Cartorio cartorioBuscado = ctx.Cartorio.Find(id);

            // Verifica se o cartorio foi encontrado
            if (cartorioBuscado != null)
            {
                // Verifica se foi informado um novo nome para o cartorio
                if (cartorioAtualizado.Nome != null)
                {
                    // Atribui o novo valor ao campo
                    cartorioBuscado.Nome = cartorioAtualizado.Nome;
                }

                // Verifica se foi informada um novo endereco para o cartorio o
                if (cartorioAtualizado.Endereco != null)
                {
                    // Atribui o novo valor ao campo
                    cartorioBuscado.Endereco = cartorioAtualizado.Endereco;
                }


                // Verifica se uma nova certidão foi informada
                if (cartorioAtualizado.FkTipoCertidao > 0)
                {
                    // Atribui o novo valor ao campo
                    cartorioBuscado.FkTipoCertidao = cartorioAtualizado.FkTipoCertidao;
                }

                // Atualiza os dados do cartorio que foi buscado
                ctx.Cartorio.Update(cartorioBuscado);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca um cartorio por ID
        /// </summary>
        /// <param name="id">ID do Cartorio será buscado</param>
        /// <returns>Um cartorio buscado</returns>
        public Cartorio BuscarPorId(int id)
        {
            // Busca o primeiro cartorio encontrado para o ID informado e armazena no objeto cartorioBuscado
            Cartorio cartorioBuscado = ctx.Cartorio
                // Adiciona na busca as informações do Tipo de Certidão  deste cartorio
                .Include(c => c.FkTipoCertidaoNavigation)
                .FirstOrDefault(c => c.IdCartorio == id);

            if (cartorioBuscado != null)
            {
                // Retorna o cartorio encontrado
                return cartorioBuscado;
            }
            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo cartorio
        /// </summary>
        /// <param name="novoCartorio">Objeto com as informações de cadastro</param>
        public void Cadastrar(Cartorio novoCartorio)
        {
            // Adiciona um novo cartorio
            ctx.Cartorio.Add(novoCartorio);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um cartorio
        /// </summary>
        /// <param name="id">ID do cartorio que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o cartorio que foi buscado através do id informado
            ctx.Cartorio.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os cartorios
        /// </summary>
        /// <returns>Uma lista de cartorios</returns>
        public List<Cartorio> Listar()
        {
            // Retorna uma lista com todas as informações dos cartorios
            return ctx.Cartorio
                // Adiciona na busca as informações do Tipo de  Certidao deste cartorio
                .Include(c => c.FkTipoCertidaoNavigation)
                .ToList();
        }
    }
}
