using Dapper;
using DapperExtensions;
using DemoDapperApi.DML;
using DemoDapperApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDapperApi.Services
{
    public partial class ClientServices
    {
        private SqlConnection _Conn = new();
        //Definir el contexto de EF
        private ClienteIXContext clienteIXContext = new ClienteIXContext();
        //Instalar Dapper y SQL
        private static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-TCHCACV;Initial Catalog=ClienteIX; Integrated Security=True; Pooling=False");
        }
        public Cliente GetClientById(int id)
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var cliente = _Conn.Query<Cliente>("SELECT *  FROM  Cliente").Where(f => f.Id == id).ToList();
            return cliente.Count != 0 ? cliente.First() : null;

        }
        public IEnumerable<Cliente> GetClients()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var clientes = _Conn.Query<Cliente>("SELECT *  FROM  Cliente").ToList();
            return clientes;

        }
        public async Task<IEnumerable<Cliente>> GetClientsAsync()
        {
            _Conn = GetSqlConnection();
            _Conn.Open();
            //Select
            var clientes = await _Conn.QueryAsync<Cliente>("SELECT *  FROM  Cliente");
            return clientes;

        }

        public void AddClient(Cliente cliente)
        {
            try
            {
                //Herencia, Partial, Interfaces, Modularidad
                clienteIXContext.Clientes.Add(cliente);
                clienteIXContext.SaveChanges();
                //_Conn = GetSqlConnection();
                //_Conn.Open();
                //var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                //var clientes = _Conn.Execute(strInsert, cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddClient(Cliente cliente, bool UseDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    _Conn.Insert(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task AddClientAsync(Cliente cliente, bool UseDapper = true)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    await _Conn.InsertAsync(cliente);
                    _Conn.Close();
                }
                else
                {
                    var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void UpdateClient(Cliente cliente, bool UseDapper = true, bool UseEntity = false)
        {
            try
            {
                _Conn = GetSqlConnection();
                _Conn.Open();
                if (UseDapper)
                {
                    _Conn.Update(cliente);
                    _Conn.Close();
                }
                else
                {
                    //TODO
                    var strInsert = DMLGenerator.CreateInsertStatement(cliente);
                    var clientes = _Conn.Execute(strInsert, cliente);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
