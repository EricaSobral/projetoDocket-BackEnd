using docketCartorio.Domains;
using docketCartorio.Interface;
using docketCartorio.Repository;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace docketCartorio.Controllers
{
        [Produces("application/json")]

        // Define que a rota de uma requisição será no formato domínio/api/NomeController
        [Route("api/[controller]")]

        // Define que é um controlador de API
        [ApiController]
    public class CartorioController : Controller
    {
   
            /// <summary>
            /// Cria um objeto _cartorioRepository que irá receber todos os métodos definidos na interface
            /// </summary>
            private ICartorioRepository _cartorioRepository;

            /// <summary>
            /// Instancia este objeto para que haja a referência aos métodos no repositório
            /// </summary>
            public CartorioController()
            {
                _cartorioRepository = new CartorioRepository();
            }

            /// <summary>
            /// Lista todos os cartorios
            /// </summary>
            /// <returns>Uma lista de cartorios e um status code 200 - Ok</returns>
            /// <response code="200">Retorna uma lista de cartorios</response>
            /// <response code="400">Retorna o erro gerado</response>
            /// dominio/api/Cartorio
            [HttpGet]
            public IActionResult Get()
            {
                try
                {
                    // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                    return Ok(_cartorioRepository.Listar());
                }
                catch (Exception error)
                {
                    // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                    return BadRequest(error);
                }
            }

            /// <summary>
            /// Busca um cartorio através do ID
            /// </summary>
            /// <param name="id">ID do cartorio que será buscado</param>
            /// <returns>Um cartorio buscado e um status code 200 - Ok</returns>
            /// <response code="200">Retorna o cartorio buscado</response>
            /// <response code="404">Retorna uma mensagem de erro</response>
            /// <response code="400">Retorna o erro gerado</response>
            /// dominio/api/cartorio/id
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                try
                {
                    // Faz a chamada para o método e armazena em um objeto cartorioBuscado
                    Cartorio cartorioBuscado = _cartorioRepository.BuscarPorId(id);

                    // Verifica se o cartorio foi encontrado
                    if (cartorioBuscado != null)
                    {
                        // Retora a resposta da requisição 200 - OK e o cartorio que foi encontrado
                        return Ok(cartorioBuscado);
                    }

                    // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                    return NotFound("Nenhum cartorio encontrado para o ID informado");
                }
                catch (Exception error)
                {
                    // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                    return BadRequest(error);
                }
            }

            /// <summary>
            /// Cadastra um novo cartorio
            /// </summary>
            /// <param name="novoCartorio">Objeto com as informações</param>
            /// <returns>Um status code 201 - Created</returns>
            /// <response code="201">Retorna apenas o status code Created</response>
            /// <response code="400">Retorna o erro gerado</response>
            /// dominio/api/Cartorio
            [HttpPost]
            public IActionResult Post(Cartorio novoCartorio)
            {
                try
                {
                    // Faz a chamada para o método
                    _cartorioRepository.Cadastrar(novoCartorio);

                    // Retora a resposta da requisição 201 - Created
                    return StatusCode(201);
                }
                catch (Exception error)
                {
                    // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                    return BadRequest(error);
                }
            }

            /// <summary>
            /// Atualiza um cartorio existente
            /// </summary>
            /// <param name="id">ID do cartorio que será atualizado</param>
            /// <param name="cartorioAtualizado">Objeto com as novas informações</param>
            /// <returns>Um status code 204 - No Content</returns>
            /// <response code="204">Retorna apenas o status code No Content</response>
            /// <response code="404">Retorna uma mensagem de erro</response>
            /// <response code="400">Retorna o erro gerado</response>
            /// dominio/api/Cartorio/id
            [HttpPatch("{id}")]
            public IActionResult Put(int id, Cartorio cartorioAtualizado)
            {
                try
                {
                    // Faz a chamada para o método e armazena em um objeto cartorioBuscado
                    Cartorio cartorioBuscado = _cartorioRepository.BuscarPorId(id);

                    // Verifica se o cartorio foi encontrado
                    if (cartorioBuscado != null)
                    {
                        // Faz a chamada para o método
                        _cartorioRepository.Atualizar(id, cartorioAtualizado);

                        // Retora a resposta da requisição 204 - No Content
                        return StatusCode(204);
                    }

                    // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                    return NotFound("Nenhum cartorio encontrado para o ID informado");
                }
                catch (Exception error)
                {
                    // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                    return BadRequest(error);
                }
            }

            /// <summary>
            /// Deleta um cartorio
            /// </summary>
            /// <param name="id">ID do cartorio que será deletado</param>
            /// <returns>Um status code 202 - Accepted</returns>
            /// <response code="202">Retorna apenas o status code Accepted</response>
            /// <response code="404">Retorna uma mensagem de erro</response>
            /// <response code="400">Retorna o erro gerado</response>
            /// dominio/api/Cartorio/id
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    // Faz a chamada para o método e armazena em um objeto cartorioBuscado
                    Cartorio cartorioBuscado = _cartorioRepository.BuscarPorId(id);

                    // Verifica se o cartorio foi encontrado
                    if (cartorioBuscado != null)
                    {
                        // Faz a chamada para o método
                        _cartorioRepository.Deletar(id);

                        // Retora a resposta da requisição 202 - Accepted
                        return StatusCode(202);
                    }

                    // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                    return NotFound("Nenhum cartorio encontrado para o ID informado");
                }
                catch (Exception error)
                {
                    // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                    return BadRequest(error);
                }
            }
        }
}

