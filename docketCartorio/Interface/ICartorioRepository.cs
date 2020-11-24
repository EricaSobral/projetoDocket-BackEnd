using docketCartorio.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docketCartorio.Interface
{

    interface ICartorioRepository
    {
        /// <summary>
        /// Lista todos os Cartorios
        /// </summary>
        /// <returns>Uma lista de cartorios</returns>
        List<Cartorio> Listar();

        /// <summary>
        /// Busca um cartorio por ID
        /// </summary>
        /// <param name="id">ID do cartorio que será buscado</param>
        /// <returns>Um cartorio buscado</returns>
        Cartorio BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Cartorio
        /// </summary>
        /// <param name="novoCartorio">Objeto com as informações de cadastro</param>
        void Cadastrar(Cartorio novoCartorio);

        /// <summary>
        /// Atualiza um cartorio existente
        /// </summary>
        /// <param name="id">ID do cartorio que será atualizado</param>
        /// <param name="cartorioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Cartorio cartorioAtualizado);

        /// <summary>
        /// Deleta um cartorio
        /// </summary>
        /// <param name="id">ID do cartorio que será deletado</param>
        void Deletar(int id);

    }
}